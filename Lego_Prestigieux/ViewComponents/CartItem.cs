using Lego_Prestigieux.Data;
using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lego_Prestigieux.ViewComponents
{
    public class CartItem : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public CartItem(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var IteminCart = _context.CartItems.Where(p => p.Id == id).FirstOrDefault();
            var Product = _context.Produits.Where(p => p.Id == IteminCart.ProductId).FirstOrDefault();

            float Price = (float)(100 - Product.Reduction) * (float)0.01 * Product.Price;
            var ProductInfoCart = new ProductInfoCart
            {
                URL = Product.URL,
                Name = Product.Name,
                Price = Price,
                Quantity = IteminCart.Quantity,
                Total = Price * IteminCart.Quantity,
                ProductId = Product.Id,
                CartItemId = id,
                Selected = IteminCart.Selected
            };

            return View("CartItem", ProductInfoCart);
        }
    }
}
