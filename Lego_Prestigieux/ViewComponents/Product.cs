using Lego_Prestigieux.Data;
using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
           int page = 1,
           bool descending = true,
           int nbResult = int.MaxValue,
           float maxPrice = float.MaxValue,
           float minPrice = 0,
           Status? status = null,
           Category? category = null,
           string searchName = "",
           float minReduction = 0)
        {
            List<ProductModel> products = new List<ProductModel>();

            if (searchName != null && searchName != "")
                products = await _context.Produits
                    .Where(p => p.Name.Contains(searchName))
                    .ToListAsync();
            else
                products = await _context.Produits.ToListAsync();

            if (descending)
            {
                products = products
                    .Where(product => (maxPrice >= product.Price) &&
                                      (minPrice <= product.Price) &&
                                      (status == null || status == product.Status) &&
                                      (category == null || category == product.Category) &&
                                      (minReduction <= product.Reduction))
                    .OrderByDescending(p => p.Price).Take(nbResult).Take(page * 12).ToList();
            }
            else
            {
                products = products
                    .Where(product => (maxPrice >= product.Price) &&
                                      (minPrice <= product.Price) &&
                                      (status == null || status == product.Status) &&
                                      (category == null || category == product.Category) &&
                                      (minReduction <= product.Reduction))
                    .OrderBy(p => p.Price).Take(nbResult).Take(page * 12).ToList();
            }

            while (products.Count > 12)
                products.RemoveAt(0);

            return View("Products", products);
        }
    }
}
