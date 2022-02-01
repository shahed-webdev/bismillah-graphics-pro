using BismillahGraphicsPro.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly IAccountCore _account;
        private readonly IDashboardCore _dashboard;
        private readonly IProductCore _product;

        public ReportController(IAccountCore account, IDashboardCore dashboard, IProductCore product)
        {
            _account = account;
            _dashboard = dashboard;
            _product = product;
        }


        public async Task<IActionResult> DailyCash()
        {

            ViewBag.date = DateTime.Now.ToString("d MMMM, yyyy");

            var response = await _account.DailyCashReportAsync(User.Identity.Name,null);
            return View(response.Data);
        }

        //search by date
        [HttpPost]
        public async Task<IActionResult> DailyCash(DateTime? date)
        {
            ViewBag.date = DateTime.Now.ToString("d MMMM, yyyy");
            var defaultDate = date ?? DateTime.Now;

            var response = await _account.DailyCashReportAsync(User.Identity.Name, defaultDate);
            return View(response.Data);
        }


        //product sales report
        public IActionResult ProductSales()
        {
            return View();
        }

        //get sales report by date
        public async Task<IActionResult> GetProductSales(DateTime from, DateTime to)
        {
            var response = await _product.SaleReportAsync(User.Identity.Name, from, to);
            return Json(response);
        }


        //net report
        public async Task<IActionResult> Net(int? id)
        {
            ViewBag.yearDropdown = await _dashboard.GetYearsAsync(User.Identity.Name);
            var response = await _dashboard.GetAsync(User.Identity.Name, year:id);

            return View(response);
        }
    }
}
