using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BismillahGraphicsPro.Web.Controllers
{
    [Authorize]
    public class SubAdminController : Controller
    {
        private readonly IRegistrationCore _registration;

        public SubAdminController(IRegistrationCore registration)
        {
            _registration = registration;
        }

        //view sub admin
        [Authorize(Roles = "Admin, SubAdminList")]
        public IActionResult Index()
        {
            var model = _registration.SubAdminList(User.Identity.Name);
            return View(model);
        }


        //SignUp view
        [Authorize(Roles = "Admin, SubAdminSignUp")]
        public IActionResult SignUp()
        {
            return View();
        }

        //post SignUp
        [HttpPost]
        public async Task<IActionResult> SignUp(SubAdminCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var response = await _registration.SubAdminSignUpAsync(User.Identity.Name, model);
            if (response.IsSuccess) return RedirectToAction("Index");

            ModelState.AddModelError("", response.Message);

            return View(model);
        }



        //Post User Validation
        [HttpPost]
        public IActionResult PostUserValidation(int registrationId)
        {
            var response =  _registration.SubAdminToggleActivation(registrationId);
            return Json(response);
        }


        //page access view
        [Authorize(Roles = "Admin, SubAdminPageAccess")]
        public IActionResult PageAccess()
        {
            ViewBag.SubAdmins =_registration.SubAdminDdl(User.Identity.Name);
            return View();
        }


        //get page links
        public IActionResult GetPageLinks(int id)
        {
            var response = _registration.SubAdminPageLinks(id);
            return Json(response);
        }


        //post page links
        //[HttpPost]
        //public IActionResult PostPageAccess()
        //{
        //    return Json();
        //}
    }
}
