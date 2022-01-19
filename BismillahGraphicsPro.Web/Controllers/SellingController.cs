using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SellingController : Controller
    {
        private readonly IVendorCore _vendorCore;
        public SellingController(IVendorCore vendorCore)
        {
            _vendorCore = vendorCore;
        }


        #region Vendor

        public IActionResult Vendors()
        {
            return View();
        }

        //get vendor data-table
        public async Task<IActionResult> GetVendorData(DataRequest request)
        {
            var data = await _vendorCore.ListAsync(User.Identity.Name, request);

            return Json(data);
        }
            

        //post vendor
        [HttpPost]
        public async Task< IActionResult> PostVendor([FromBody] VendorAddModel model)
        {
            var response = await _vendorCore.AddAsync(User.Identity.Name, model);

            return Json(response);
        }


        //get vendor by {id}
        public async Task<IActionResult> GetVendorById(int? id)
        {
            if (!id.HasValue) return NotFound();
        
            var response = await _vendorCore.GetAsync(id.GetValueOrDefault());
            return Json(response);
        }


        //update vendor
        [HttpPut]
        public async Task<IActionResult> UpdateVendor([FromBody] VendorEditModel model)
        {
            var response = await _vendorCore.EditAsync(model);
            return Json(response);
        }


        //delete vendor
        public async Task<IActionResult> DeleteVendor(int id)
        {
            var response = await _vendorCore.DeleteAsync(id);
            return Json(response);
        }

        #endregion
    }
}
