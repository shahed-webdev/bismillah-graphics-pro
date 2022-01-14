using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
