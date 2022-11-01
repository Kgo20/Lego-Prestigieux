using Lego_Prestigieux.Data;
using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lego_Prestigieux.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var productModel = await _context.Produits //.Select(v => v.Vehicles.W)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (productModel == null)
                {
                    return NotFound();
                }

                return View("Detail", productModel);
            }
            catch (Exception)
            {
                return StatusCode(500, "ERROR: Could not load this branch...");
            }
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModel Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Model);
                }

                var product = new ProductModel
                {
                    Name = Model.Name,
                    Detail = Model.Detail,
                    Price = Model.Price,
                    Reduction = Model.Reduction,
                    Status = Model.Status,
                    Category = (Category)Model.Category,
                    Quantity = Model.Quantity,
                    URL = Model.URL
                };
                if (product.Reduction is null)
                    product.Reduction = 0;



                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home" );
                }
                return View(Model);
            }
            catch (Exception)
            {
                return StatusCode(500, "ERROR: Could not create the product, try again");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SearchProduct(string search)
        {
            return RedirectToAction("List", new FilterModel { SearchName = search });
        }

        public async Task<IActionResult> FilterCategory(Category? category)
        {
            return RedirectToAction("List", new FilterModel { Category = category });
        }

        public async Task<IActionResult> List(FilterModel model)
        {
            //0 veut dire que le nombre de pages maximum n'a pas été calculé
            if (model.PageMax == 0)
            {
                List<ProductModel> products = new List<ProductModel>();

                if (model.SearchName != null && model.SearchName != "")
                    products = await _context.Produits
                        .Where(p => p.Name.Contains(model.SearchName))
                        .ToListAsync();
                else
                    products = await _context.Produits.ToListAsync();

                    products = products
                        .Where(product => (model.MaxPrice >= product.Price) &&
                                          (model.MinPrice <= product.Price) &&
                                          (model.Status == null || model.Status == product.Status) &&
                                          (model.Category == null || model.Category == product.Category) &&
                        (model.MinReduction <= product.Reduction))
                        .Take(model.NbResult).ToList();

                model.PageMax = (int)Math.Ceiling((decimal)products.Count / 12);
            }

            return View("List", model);
        }

        [HttpPost]
        public async Task<IActionResult> Filter(int descending = 0,
                                                float maxPrice = float.MaxValue,
                                                float minPrice = 0,
                                                Status? status = null,
                                                Category? category = null,
                                                string searchName = "",
                                                float minReduction = 0)
        {
            FilterModel model = new FilterModel();

            model.MinReduction = minReduction;
            model.MinPrice = minPrice;
            model.MaxPrice = maxPrice;

            model.Status = status;
            model.Category = category;

            if (descending == 1)
                model.Descending = false;

            model.SearchName = searchName;

            return RedirectToAction("List", model);
        }

        [HttpPost]
        public async Task<IActionResult> NextPage(int descending = 0,
                                                int page = 1,
                                                int pageMax = 0,
                                                float maxPrice = float.MaxValue,
                                                float minPrice = 0,
                                                Status? status = null,
                                                Category? category = null,
                                                string searchName = "",
                                                float minReduction = 0)
        {
            FilterModel model = new FilterModel();
            model.MinReduction= minReduction;
            model.MinPrice = minPrice;
            model.MaxPrice = maxPrice;
            model.PageMax = pageMax;
            model.Page = page + 1;
            model.Status = status;
            model.Category = category;
            model.SearchName = searchName;
            model.Descending = descending == 0 ? true : false;
            
            return RedirectToAction("List", model);
        }

        [HttpPost]
        public async Task<IActionResult> LastPage(int descending = 0,
                                                int page = 1,
                                                int pageMax = 0,
                                                float maxPrice = float.MaxValue,
                                                float minPrice = 0,
                                                Status? status = null,
                                                Category? category = null,
                                                string searchName = "",
                                                float minReduction = 0)
        {
            FilterModel model = new FilterModel();
            model.MinReduction = minReduction;
            model.MinPrice = minPrice;
            model.MaxPrice = maxPrice;
            model.PageMax = pageMax;
            model.Page = page - 1;
            model.Status = status;
            model.Category = category;
            model.SearchName = searchName;
            model.Descending = descending == 0 ? true : false;

            return RedirectToAction("List", model);
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // Envoie au formulaire
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var productModel = await _context.Produits.FindAsync(id);
                if (productModel == null)
                {
                    return NotFound();
                }
                return View("Edit", productModel);
            }
            catch (Exception)
            {
                return StatusCode(500, "ERROR: Could not load this branch...");
            }
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductModel productModel)
        {
            // sauvegarde les changements
            try
            {
                if (id != productModel.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(productModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductModelExists(productModel.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
                return View("Edit", productModel);
            }
            catch (Exception)
            {
                return StatusCode(500, "ERROR: Could not edit this branch...");
            }
        }
        private bool ProductModelExists(int id)
        {
            return _context.Produits.Any(e => e.Id == id);
        }

        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var productModel = await _context.Produits
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (productModel == null)
                {
                    return NotFound();
                }

                return View("Delete", productModel);
            }
            catch (Exception)
            {
                return StatusCode(500, "ERROR: Could not find this branch...");
            }
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var productModel = await _context.Produits.FindAsync(id);
                _context.Produits.Remove(productModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return StatusCode(500, "ERROR: Could not delete this branch...");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int quantity, string returnUrl = "/Home/Index")
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId == null)
                    return RedirectToAction("Login", "Account", null);

                ProductModel product = await _context.Produits.FindAsync(productId);

                if (product == null)
                    return NotFound();


                CartItemModel cart = new CartItemModel()
                {
                    ProductId = product.Id,
                    Quantity = quantity,
                    UserId = userId
                };

                await _context.AddAsync(cart);
                await _context.SaveChangesAsync();

                return Redirect(returnUrl);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
