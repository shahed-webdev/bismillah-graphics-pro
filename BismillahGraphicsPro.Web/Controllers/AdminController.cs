using BismillahGraphicsPro.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    [Authorize(Roles = "Admin,SubAdmin")]
    public class AdminController : Controller
    {
        private readonly IDashboardCore _dashboard;
        private readonly IRegistrationCore _registration;
        
        public AdminController(IDashboardCore dashboard, IRegistrationCore registration)
        {
            _dashboard = dashboard;
            _registration = registration;
        }

        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.yearDropdown = await _dashboard.GetYearsAsync(User.Identity.Name);
            var response = await _dashboard.GetAsync(User.Identity.Name, year:id);

            return View(response);
        }


        //reset data
        public IActionResult Reset()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> PostReset()
        {
            var response = await _registration.ResetAsync(User.Identity.Name);
            return Json(response);
        }
    }
}
