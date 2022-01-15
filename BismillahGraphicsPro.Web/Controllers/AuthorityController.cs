using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    [Authorize (Roles = "Authority")]
    public class AuthorityController : Controller
    {
        private readonly IRegistrationCore _registration;

        public AuthorityController(IRegistrationCore registration)
        {
            _registration = registration;
        }

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
        public async Task<IActionResult> CreateBranch(BranchCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var response = await _registration.BranchSignUpAsync(model);

            if (response.IsSuccess) return RedirectToAction("BranchList");
      
            ModelState.AddModelError("", response.Message);
            return View(model);
        }

        //Branch list
        public IActionResult BranchList()
        {

            return View();
        }

        //Branch Access Control
        // [HttpPost]
        // public IActionResult PostBranchAccessControl()
        // {
        //     return View();
        // }
    }
}
