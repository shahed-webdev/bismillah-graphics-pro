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
        private readonly ISellingCore _sellingCore;
        private readonly IRegistrationCore _registration;

        public SellingController(IVendorCore vendorCore, ISellingCore sellingCore, IRegistrationCore registration)
        {
            _vendorCore = vendorCore;
            _sellingCore = sellingCore;
            _registration = registration;
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


        #region Selling

        public IActionResult Index()
        {
            return View();
        }


        //post Selling
        [HttpPost]
        public async Task<IActionResult> PostSelling([FromBody] SellingAddModel model)
        {
            var response = await _sellingCore.AddAsync(User.Identity.Name, model);
            return Json(response);
        }


        //Selling receipt
        public async Task<IActionResult> Receipt(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Records");

            //branch info
            var branch = await _registration.GetAsync(User.Identity.Name);
            ViewBag.branchInfo = branch.Data;

            var model = await _sellingCore.GetAsync(id.GetValueOrDefault());
            return View(model.Data);
        }


        //Selling records view
        public IActionResult Records()
        {
            return View();
        }


        //Selling records (data-table)
        public async Task<IActionResult> GetRecordsData(DataRequest request)
        {
            var response = await _sellingCore.ListAsync(User.Identity.Name, request);
            return Json(response);
        }

        //view update Selling
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");

            var response = await _sellingCore.GetAsync(id.GetValueOrDefault());
            ViewBag.updateData = response.Data;

            return View();
        }


        //post update purchase
        [HttpPut]
        public async Task<IActionResult> UpdateSelling([FromBody] SellingEditModel model)
        {
            var response = await _sellingCore.EditAsync(model);
            return Json(response);
        }
        #endregion


        #region Due Collection

        //due collection view
        public IActionResult DueCollection()
        {
            return View();
        }


        //post Due Collection
        //[HttpPost]
        //public async Task<IActionResult> PostDueCollection([FromBody] SellingAddModel model)
        //{
        //    var response = await _sellingCore.AddAsync(User.Identity.Name, model);
        //    return Json(response);
        //}


        #endregion
    }
}
