using BismillahGraphicsPro.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    [Authorize]
    public class CommonController : Controller
    {
        private readonly IMeasurementUnitCore _measurementUnit;
        private readonly IAccountCore _account;
        private readonly IProductCore _productCore;

        public CommonController(IMeasurementUnitCore measurementUnit, IAccountCore account, IProductCore productCore)
        {
            _measurementUnit = measurementUnit;
            _account = account;
            _productCore = productCore;
        }


        //account dropdown
        public IActionResult GetAccount()
        {
            var response = _account.ListDdl(User.Identity.Name);
            return Json(response);
        }


        //measurement unit dropdown
        public IActionResult GetMeasurementUnit()
        {
            var response = _measurementUnit.ListDdl(User.Identity.Name);
            return Json(response);
        }


        //find product autocomplete
        public async Task<IActionResult> FindProduct(string prefix)
        {
            var response = await _productCore.SearchAsync(User.Identity.Name, prefix);
            return Json(response);
        }
    }
}
