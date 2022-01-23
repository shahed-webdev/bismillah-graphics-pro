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
        public IActionResult Index()
        {
            var model = _registration.SubAdminList(User.Identity.Name);
            return View(model);
        }


        //SignUp view
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


        //todo
        //Post User Validation
        //[HttpPost]
        //public async Task<IActionResult> PostUserValidation(int registrationId)
        //{
        //    var response = await _registration.SubAdminValidation(registrationId);
        //    return Json();
        //}


        //page access view
        public IActionResult PageAccess()
        {
            //ViewBag.SubAdmins = new SelectList(_registrations.SubAdmins(), "value", "label");
            return View();
        }


        //todo
        //get page links
        //public IActionResult GetPageLinks(int registrationId)
        //{
        //    var response = _registration
        //    return Json(response);
        //}


        //post page links
        //[HttpPost]
        //public IActionResult PostPageAccess()
        //{
        //    return Json();
        //}
    }
}
