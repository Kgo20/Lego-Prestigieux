using Lego_Prestigieux.Data;
using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
            return View("Cart");
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
