using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    [Authorize]
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

        [Authorize(Roles = "Admin, Vendors")]
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
        public async Task<IActionResult> PostVendor([FromBody] VendorAddModel model)
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


        //Vendor details
        public async Task<IActionResult> VendorDetails(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Vendors");

            var response = await _vendorCore.GetAsync(id.GetValueOrDefault());
            ViewBag.vendor = response.Data;

            return View();
        }

        //get total amount
        public async Task<IActionResult> VendorDetailsAmount(int? id, DateTime from, DateTime to)
        {
            var response = await _vendorCore.GetAsync(id.GetValueOrDefault());
            return Json(response);
        }

        #endregion


        #region Selling

        [Authorize(Roles = "Admin, Selling")]
        public IActionResult Index()
        {
            return View();
        }


        //post Selling
        [HttpPost]
        public async Task<IActionResult> PostSelling(SellingAddModel model)
        {
            var response = await _sellingCore.AddAsync(User.Identity.Name, model);
            return Json(response);
        }


        //Selling receipt
        public async Task<IActionResult> Receipt(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Records");

            //branch info
            var branch = await _registration.GetBranchAsync(User.Identity.Name);
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


        //post update Selling
        [HttpPut]
        public async Task<IActionResult> UpdateSelling([FromBody] SellingEditModel model)
        {
            var response = await _sellingCore.EditAsync(model);
            return Json(response);
        }


        //Delete Bill
        public async Task<IActionResult> DeleteBill(int id)
        {
            var response = await _sellingCore.DeleteAsync(User.Identity.Name, id);
            return Json(response);
        }

        #endregion


        #region Due Collection

        //due Collection single view
        [Authorize(Roles = "Admin, SellingDueCollectionSingle")]
        public async Task<IActionResult> DueCollectionSingle(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");

            var model = await _sellingCore.GetAsync(id.GetValueOrDefault());
            return View(model.Data);
        }


        //post single due Collection
        [HttpPost]
        public async Task<IActionResult> PostSingleDue(SellingDuePayModel model)
        {
            var response = await _sellingCore.DueCollectionAsync(User.Identity.Name, model);
            return Json(response);
        }



        //due Collection multiple view
        [Authorize(Roles = "Admin, SellingDueCollectionMultiple")]
        public async Task<IActionResult> DueCollectionMultiple(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Vendors");

            var model = await _sellingCore.GetVendorWiseDueAsync(id.GetValueOrDefault(), null, null);
            ViewBag.dueModel = model.Data;

            return View();
        }


        //get due bills by dates
        public async Task<IActionResult> GetDueBills(int id, DateTime? from, DateTime? to)
        {
            var model = await _sellingCore.GetVendorWiseDueAsync(id, from, to);
            return Json(model);
        }


        //post multiple due Collection
        [HttpPost]
        public async Task<IActionResult> PostDues(SellingDuePayModel model)
        {
            var response = await _sellingCore.DueCollectionAsync(User.Identity.Name, model);
            return Json(response);
        }


        //payment receipt view
        public async Task<IActionResult> PaymentReceipt(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Vendors");
            var model = await _sellingCore.GetPaymentDetailsAsync(User.Identity.Name, id.GetValueOrDefault());

            return View(model.Data);
        }

        #endregion


        #region Report

        //payment report
        [Authorize(Roles = "Admin, SellingPaymentReport")]
        public IActionResult PaymentReport()
        {
            return View();
        }

        //get payment data table
        public async Task<IActionResult> GetPaymentData(DataRequest request)
        {
            var response = await _sellingCore.PaymentListAsync(User.Identity.Name, request);
            return Json(response);
        }


        //get total paid
        public async Task<IActionResult> GetPaid(DateTime from, DateTime to)
        {
            var response = await _sellingCore.GetTotalPaidAsync(User.Identity.Name, from, to);
            return Json(response);
        }


        //due report view
        [Authorize(Roles = "Admin, SellingDueReport")]
        public IActionResult DueReport()
        {
            return View();
        }


        //get total due
        public async Task<IActionResult> GetDue()
        {
            var response = await _sellingCore.GetTotalDueAsync(User.Identity.Name, null, null);
            return Json(response);
        }


        //payment report view
        [Authorize(Roles = "Admin, SellingReport")]
        public IActionResult SellingReport()
        {
            return View();
        }


        //get total sales
        public async Task<IActionResult> GetTotalSales(DateTime from, DateTime to)
        {
            var response = await _sellingCore.GetTotalSaleAsync(User.Identity.Name, from, to);
            return Json(response);
        }

        #endregion
    }
}
