using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lego_Prestigieux.ViewComponents
{
    public class NavBar : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(new NavBarModel());
        }
    }
}
