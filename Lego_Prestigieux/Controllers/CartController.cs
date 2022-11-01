using Lego_Prestigieux.Data;
using Lego_Prestigieux.Models;
using Lego_Prestigieux.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lego_Prestigieux.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId == null)
                    return RedirectToAction("Login", "Account", null);

                List<CartItemModel> cartItems = new List<CartItemModel>();
                cartItems = await _context.CartItems.Where(ci => ci.UserId == userId).ToListAsync();

                return View("Cart",cartItems);
            }
            catch (System.Exception)
            {
                return NotFound();
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
                    itemcart.Quantity = itemcart.Quantity - 1;

                _context.CartItems.Update(itemcart);
                await _context.SaveChangesAsync();
            }
            

            return RedirectToAction("Index");
        }
    }
}
