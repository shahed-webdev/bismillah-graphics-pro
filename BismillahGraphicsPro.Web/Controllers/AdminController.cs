using BismillahGraphicsPro.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    [Authorize(Roles = "Admin,SubAdmin")]
    public class AdminController : Controller
    {
        private readonly IDashboardCore _dashboard;
        public AdminController(IDashboardCore dashboard)
        {
            _dashboard = dashboard;
        }

        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.yearDropdown = await _dashboard.GetYearsAsync(User.Identity.Name);
            var response = await _dashboard.GetAsync(User.Identity.Name, year:id);

            return View(response);
        }
    }
}
