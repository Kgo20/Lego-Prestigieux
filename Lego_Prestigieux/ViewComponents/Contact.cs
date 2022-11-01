using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lego_Prestigieux.ViewComponents
{
    public class Contact : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Contact");
        }
    }
}
