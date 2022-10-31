using Lego_Prestigieux.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lego_Prestigieux.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Cart");
        }
    }
}
