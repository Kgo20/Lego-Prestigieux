using Lego_Prestigieux.Data;
using Lego_Prestigieux.Models;
using Lego_Prestigieux.ViewComponents;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lego_Prestigieux.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId == null)
                    return RedirectToAction("Login", "Account", null);

                List<CartItemModel> cartItems = new List<CartItemModel>();
                cartItems = await _context.CartItems.Where(ci => ci.UserId == userId && ci.CommandModel == null).ToListAsync();

                return View("Cart", cartItems);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCartItem(int cartItemId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId == null)
                    return RedirectToAction("Login", "Account", null);

                CartItemModel cartItem = await _context.CartItems.FindAsync(cartItemId);

                if (cartItem == null)
                    return RedirectToAction("Index");

                if (cartItem.UserId != userId)
                    return RedirectToAction("Index");

                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> UpdateQuantity(int id, bool moreless)
        {
            var itemcart = _context.CartItems.Where(p => p.Id == id).FirstOrDefault();
            if (itemcart != null)
            {
                if (moreless == true)
                    itemcart.Quantity = itemcart.Quantity + 1;
                else
                {
                    if (itemcart.Quantity > 1)
                        itemcart.Quantity = itemcart.Quantity - 1;
                }

                _context.CartItems.Update(itemcart);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateSelected(int id)
        {
            var itemcart = _context.CartItems.Where(p => p.Id == id).FirstOrDefault();
            if (itemcart != null)
            {
                if (itemcart.Selected == true)
                    itemcart.Selected = false;
                else
                    itemcart.Selected = true;


                _context.CartItems.Update(itemcart);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateCommand()
        {
            try
            {
                var userId = _userManager.GetUserId(HttpContext.User);

                var cartItems = await _context.CartItems.Where(p => p.UserId == userId && p.Selected == true && p.CommandModel == null).ToListAsync();

                var address = _context.Addresses.Where(i => i.CustomerId == userId).FirstOrDefault();

                if(cartItems.Count == 0)
                    return RedirectToAction("Index");

                foreach (var item in cartItems)
                {
                    var product = await _context.Produits.FindAsync(item.ProductId);

                    if (item.Quantity > product.Quantity)
                        return RedirectToAction("Index");

                    product.Quantity -= item.Quantity;

                    if (product.Quantity == 0)
                        product.Status = Status.Indisponible;
                }

                var command = new CommandModel
                {
                    Products = cartItems,
                    CommandCreationDate = DateTime.Now,
                    ExpectedDeliveryDate = DateTime.Now.AddDays(14),
                    Status = CommandStatus.Confirmed,
                    AddressId = address.Id,
                    UserId = userId
                };



                if (ModelState.IsValid)
                {

                    _context.Add(command);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("CommandForm", new { command.Id });
                }
                return View();
            }
            catch (Exception)
            {
                return StatusCode(500, "ERROR: Could not create the command, try again");
            }
        }

        public async Task<IActionResult> CommandForm(int id)
        {
            var command = _context.Commands.Where(p => p.Id == id).FirstOrDefault();
            if (command == null)
            {
                return StatusCode(500, "ERROR: try again");
            }

            var user = _context.Users.Where(p => p.Id == command.UserId).FirstOrDefault();
            if (user == null)
            {
                return StatusCode(500, "ERROR: try again");

            }
            var addresses = _context.Addresses.Where(p => p.CustomerId == command.UserId).ToList();
            if (addresses == null)
            {
                return StatusCode(500, "ERROR: try again");

            }


            var form = new FormConfirmationAddressCommand
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EMail = user.Email,
                PhoneNumber = user.PhoneNumber,
                Addresses = addresses,
                CommandId = command.Id
            };


            return View("CommandForm", form);
        }





    }
}
