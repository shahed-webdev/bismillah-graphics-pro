using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    [Authorize (Roles = "Authority")]
    public class AuthorityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
