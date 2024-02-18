using Microsoft.AspNetCore.Mvc;

namespace KatmanliSiteYonetim.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ErrorPage(int code)
        {
            return View();
        }
    }
}
