using BismillahGraphicsPro.Data;
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

        //Create Branch
        public IActionResult CreateBranch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBranch(Branch model)
        {
            return View();
        }

        //Branch list
        public IActionResult BranchList()
        {
            return View();
        }

        //Branch Access Control
        public IActionResult BranchAccessControl()
        {
            return View();
        }
    }
}
