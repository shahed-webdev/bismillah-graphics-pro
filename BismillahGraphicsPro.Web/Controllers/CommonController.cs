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
        private readonly ISupplierCore _supplierCore;
        private readonly IVendorCore _vendorCore;

        public CommonController(IMeasurementUnitCore measurementUnit, IAccountCore account, IProductCore productCore, ISupplierCore supplierCore, IVendorCore vendorCore)
        {
            _measurementUnit = measurementUnit;
            _account = account;
            _productCore = productCore;
            _supplierCore = supplierCore;
            _vendorCore = vendorCore;
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



        //find supplier autocomplete
        public async Task<IActionResult> FindSupplier(string prefix)
        {
            var response = await _supplierCore.SearchAsync(User.Identity.Name, prefix);
            return Json(response);
        }

        //find vendor autocomplete
        public async Task<IActionResult> FindVendor(string prefix)
        {
            var response = await _vendorCore.SearchAsync(User.Identity.Name, prefix);
            return Json(response);
        }
    }
}
