using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    [Authorize(Roles = "Authority")]
    public class AuthorityController : Controller
    {
        private readonly IRegistrationCore _registration;

        public AuthorityController(IRegistrationCore registration)
        {
            _registration = registration;
        }

        public IActionResult Index()
        {
            var branchList = _registration.BranchList();
            return View(branchList);
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
            var branchList = _registration.BranchList();
            return View(branchList);
        }

        //Branch Access Control
        [HttpPost]
        public IActionResult PostBranchAccessControl(int branchId)
        {
            var response = _registration.ToggleBranchActivation(branchId);

            return Json(response);
        }


        //update Branch
        public async Task<IActionResult> UpdateBranch(int? id)
        {
            if (!id.HasValue) return RedirectToAction("BranchList");
            var model =await _registration.GetBranchAsync(id.GetValueOrDefault());
           
            return View(model.Data);
        }


        //post update Branch
        [HttpPost]
        public async Task<IActionResult> UpdateBranch(BranchEditModel model)
        {
            var response = await _registration.EditBranchAsync(model);
           
            if(response.IsSuccess) return RedirectToAction("BranchList");

            return View();
        }
    }
}
