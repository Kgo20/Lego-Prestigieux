using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lego_Prestigieux.ViewComponents
{
    public class Contacts : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Views/Shared/Components/Contact/Contact.cshtml");
        }
    }
}
