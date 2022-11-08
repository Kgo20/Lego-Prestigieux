﻿using Lego_Prestigieux.Data;
using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Security.Claims;

namespace Lego_Prestigieux.Controllers
{
    public class CommandController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommandController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public async Task<IActionResult> Details(int commandId)
        {
            return NotFound();
        }

        public async Task<IActionResult> Remove(int commandId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId == null)
                    return RedirectToAction("Login", "Account", null);

                CommandModel command = await _context.Commands.Include("Products").FirstAsync(c=>c.Id == commandId);

                if (!User.IsInRole("Admin") && command.UserId != userId)
                {
                    return RedirectToAction("List");
                }

                foreach (var item in command.Products)
                {
                    item.CommandModel = null;
                }

                command.Status = CommandStatus.Canceled;
                await _context.SaveChangesAsync();

                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> List()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId == null)
                    return RedirectToAction("Login", "Account", null);

                List<CommandModel> commands = new List<CommandModel>();

                if (User.IsInRole("Admin"))
                {
                    commands = await _context.Commands.OrderBy(c=>c.Status).ToListAsync();
                }
                else
                {
                    commands = await _context.Commands.OrderBy(c => c.Status).Where(c => c.UserId == userId).ToListAsync();
                }

                return View("Commands", commands);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> CompleteCommand(int commandId)
        {
            if (commandId == 0)
            {
                return NotFound();
            }

            var command = _context.Commands.Where(c => c.Id == commandId).FirstOrDefault();
            if (command == null)
                return NotFound();

            var address = _context.Addresses.Where(c => c.Id == command.AddressId).FirstOrDefault();
            if (address == null)
                return NotFound();

            var user = _context.Users.Where(c => c.Id == command.UserId).FirstOrDefault();
            if (user == null)
                return NotFound();

            var products = _context.CartItems.Where(c => c.CommandModel.Id == commandId).ToList();
            if (products == null)
                return NotFound();

            List<ProductInfoCart> productsinfo = new List<ProductInfoCart>();
            foreach (var item in products)
            {
                var p = _context.Produits.Where(p => p.Id == item.ProductId).FirstOrDefault();
                float Price = (float)(100 - p.Reduction) * (float)0.01 * p.Price;
                var productinfo = new ProductInfoCart
                {
                    URL = p.URL,
                    Name = p.Name,
                    Price = Price,
                    Quantity = p.Quantity,
                    Total = Price * p.Quantity,
                    ProductId = p.Id,
                    CartItemId = item.Id,
                    Selected = item.Selected
                };

                productsinfo.Add(productinfo);
            }

            float TotalBeforeTaxes = 0;
            float Shippingcost = 0;
            foreach (var product in products)
            {
                TotalBeforeTaxes += (product.PriceUnit * product.Quantity);
            }

            if(TotalBeforeTaxes < 1000)
            {
                Shippingcost = 10;
            }

            var detail = new CompleteCommand
            {
                CommandId = commandId,
                CommandCreationDate = command.CommandCreationDate,
                ExpectedDeliveryDate = command.ExpectedDeliveryDate,

                Products = productsinfo,

                FirstName = user.FirstName,
                LastName = user.LastName,
                EMail = user.Email,
                PhoneNumber = user.PhoneNumber,
                AddressLivraison = address,

                TotalBeforeTaxes = TotalBeforeTaxes,
                Taxes = TotalBeforeTaxes * 0.14975f,
                Total = TotalBeforeTaxes * 1.14975f,
                ShippingCost = Shippingcost
            };

            return View("CommandDetail", detail);
        }


        public async Task<IActionResult> ChangeStatus(int commandId)
        {

            var command = _context.Commands.Where(x => x.Id == commandId).FirstOrDefault();
            if (command == null)
                return NotFound();

            command.Status = CommandStatus.InPreparation;

            _context.Commands.Update(command);
            await _context.SaveChangesAsync();

            return RedirectToAction("List");
        }
    }
}
