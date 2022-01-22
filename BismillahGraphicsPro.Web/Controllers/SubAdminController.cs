using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        //[HttpPost]
        //public async Task<IActionResult> PostUserValidation(int registrationId)
        //{
        //    var response = await _registration.SubAdminValidation(registrationId);
        //    return Json();
        //}


        public IActionResult PageAccess()
        {
            return View();
        }


        //[HttpPost]
        //public IActionResult PostPageAccess()
        //{
        //    return Json();
        //}
    }
}
