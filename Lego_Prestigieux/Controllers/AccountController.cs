using Lego_Prestigieux.Data;
using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lego_Prestigieux.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private static readonly PasswordHasher<ApplicationUser> PASSWORD_HASHER = new();


        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult LogIn()
        {
            return View();
        }
        //Post : LogIn
        [HttpPost]
        public async Task<IActionResult> LogIn(LogIn model, string returnurl = "Index")
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName, model.Password, false, false);

                if (result.IsLockedOut)
                {
                    return View("Lockout");
                }

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Connexion échouée!");
                    return View(model);
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return StatusCode(500, "ERROR: The System cannot log the user. Please try again.");
            }

        }

        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _signInManager.SignOutAsync();

                return RedirectToAction("LogIn", "Account");
            }
            catch
            {
                return StatusCode(500, "ERROR: The System cannot logout the user. Please try again.");
            }

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CreateCustomerWithAddress model = new CreateCustomerWithAddress();

            return View(model);
        }

        // POST: LogIn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCustomerWithAddress createmodel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(createmodel);

                var user = new ApplicationUser
                {
                    UserName = createmodel.EMail,
                    NormalizedUserName = createmodel.EMail.ToUpper(),
                    Email = createmodel.EMail,
                    NormalizedEmail = createmodel.EMail.ToUpper(),
                    FirstName = createmodel.FirstName,
                    LastName = createmodel.LastName,
                    PhoneNumber = createmodel.PhoneNumber,
                };

                var address = new AddressModel
                {
                    Address = createmodel.Address,
                    Country = createmodel.Country,
                    Province = createmodel.Province,
                    PostalCode = createmodel.PostalCode,
                    CustomerId = user.Id,
                };

                user.PasswordHash = PASSWORD_HASHER.HashPassword(user, createmodel.Password);

                var listrole = _roleManager.Roles.ToList();

                if (createmodel.Password != createmodel.ConfirmPassword)
                    return View(createmodel);

                var result = await _userManager.CreateAsync(user, createmodel.Password);


                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Création échouée");
                    return View(createmodel);
                }

                //Ajouter les roles aux users
                IdentityRole roles = listrole.Where(r => r.Name == "Customer").FirstOrDefault();

                var role = new IdentityUserRole<string>()
                {
                    RoleId = roles.Id,
                    UserId = user.Id
                };
                var resultRole = _context.Add(role);

                if (ModelState.IsValid)
                {
                    _context.Add(address);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("CreateMoreAddressId", new { user.Id });
                }
                return View(createmodel);

            }
            catch (Exception e)
            {
                return StatusCode(500, "ERROR: The System cannot create the user. Please try again." + "\r\n" + e);
            }
        }

        public IActionResult CreateMoreAddressId(string id)
        {
            CreateMoreAddress model = new CreateMoreAddress();
            model.CustomerId = id;
            return View("CreateMoreAddress", model);
        }

        public IActionResult CreateMoreAddress()
        {
            CreateMoreAddress model = new CreateMoreAddress();
            var user = _userManager.GetUserId(HttpContext.User);
            model.CustomerId = user;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMoreAddress(string id, CreateMoreAddress cMA)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(cMA);
              
                var address = new AddressModel
                {
                    Address = cMA.Address,
                    Country = cMA.Country,
                    Province = cMA.Province,
                    PostalCode = cMA.PostalCode,
                    CustomerId = id,
                };
                cMA.CustomerId = id;

                if (ModelState.IsValid)
                {
                    _context.Add(address);
                    await _context.SaveChangesAsync();
                    return View("ConfirmAddress", cMA);
                }

                return View(cMA);
            }
            catch (Exception e)
            {
                return StatusCode(500, "ERROR: The System cannot create the address. Please try again." + "\r\n" + e);
            }

        }

        public IActionResult ConfirmAddress(string id, CreateMoreAddress cMA)
        {
            if (cMA == null)
            {
                return NotFound();
            }

            if (id == null)
            {
                return NotFound();
            }
            cMA.CustomerId = id;

            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("CreateMoreAddressId", new { id = id });
            else
                return RedirectToAction("CreateMoreAddress");

        }
    }
}
