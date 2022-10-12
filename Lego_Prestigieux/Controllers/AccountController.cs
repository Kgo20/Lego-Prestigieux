using Lego_Prestigieux.Data;
using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lego_Prestigieux.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

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
    }
}
