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
                    commands = await _context.Commands.ToListAsync();
                }
                else
                {
                    commands = await _context.Commands.Where(c => c.UserId == userId).ToListAsync();
                }

                return View("Command", commands);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}