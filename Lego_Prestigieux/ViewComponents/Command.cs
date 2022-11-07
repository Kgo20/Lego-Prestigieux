using Lego_Prestigieux.Data;
using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lego_Prestigieux.ViewComponents
{
    public class Command : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public Command(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            CommandModel Command = _context.Commands.Include("Products").Where(c => c.Id == id).FirstOrDefault();

            var CommandVM = new CommandInfo
            {
                CommandId = Command.Id,
                CommandCreationDate = DateTime.Now,
                ExpectedDeliveryDate = DateTime.Now.AddDays(14),
                CommandTotal = Command.Products.Sum(p => p.PriceUnit * p.Quantity),
                ProductAmount = Command.Products.Count(),
                Status = Command.Status
            };

            return View("Command", CommandVM);
        }
    }
}
