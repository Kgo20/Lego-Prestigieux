using Lego_Prestigieux.Data;
using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
    }
}
