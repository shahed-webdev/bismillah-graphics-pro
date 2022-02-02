using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
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
        private readonly IRegistrationCore _registration;

        public CommonController(IMeasurementUnitCore measurementUnit, IAccountCore account, IProductCore productCore, ISupplierCore supplierCore, IVendorCore vendorCore, IRegistrationCore registration)
        {
            _measurementUnit = measurementUnit;
            _account = account;
            _productCore = productCore;
            _supplierCore = supplierCore;
            _vendorCore = vendorCore;
            _registration = registration;
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


        //profile update(authority, admin, sub-admin)
        public async Task<IActionResult> UpdateProfile()
        {
            var model =await _registration.GetUserAsync(User.Identity.Name);
            return View(model.Data);
        }

        //post update Branch
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(RegistrationEditModel model)
        {
            var response = await _registration.EditAsync(User.Identity.Name,model);

            if (!response.IsSuccess) return View();

            var isAuthority = User.IsInRole("Authority");
            return isAuthority ? RedirectToAction("Index", "Authority"): RedirectToAction("Index","Admin");
        }
    }
}
