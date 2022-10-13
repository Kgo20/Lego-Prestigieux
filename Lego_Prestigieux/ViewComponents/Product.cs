using Lego_Prestigieux.Data;
using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Lego_Prestigieux.ViewComponents
{
    public class Product : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public Product(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(
           bool descending = true,
           int nbResult = int.MaxValue,
           float maxPrice = float.MaxValue,
           float minPrice = 0,
           Status? status = null,
           Category? category = null,
           float minReduction = 0)
        {
            var products = await _context.Produits.ToListAsync();
            if (descending)
            {
                products = await _context.Produits
                    .Where(product => (maxPrice >= product.Price) &&
                                      (minPrice <= product.Price) &&
                                      (status == null || status == product.Status) &&
                                      (category == null || category == product.Category) &&
                                      (minReduction <= product.Reduction))
                    .OrderByDescending(p => p.Price).Take(nbResult).ToListAsync();
            }
            else
            {
                products = await _context.Produits
                    .Where(product => (maxPrice >= product.Price) &&
                                      (minPrice <= product.Price) &&
                                      (status == null || status == product.Status) &&
                                      (category == null || category == product.Category) &&
                                      (minReduction <= product.Reduction))
                    .OrderBy(p => p.Price).Take(nbResult).ToListAsync();
            }


            return View("Products", products);
        }
    }
}
