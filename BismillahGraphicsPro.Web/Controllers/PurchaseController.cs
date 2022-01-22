using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    [Authorize]
    public class PurchaseController : Controller
    {
        private readonly ISupplierCore _supplierCore;
        private readonly IPurchaseCore _purchaseCore;

        public PurchaseController(ISupplierCore supplierCore, IPurchaseCore purchaseCore, IMeasurementUnitCore measurementUnit)
        {
            _supplierCore = supplierCore;
            _purchaseCore = purchaseCore;
        }


        #region Supplier

        public IActionResult Suppliers()
        {
            return View();
        }

        //get supplier data-table
        public async Task<IActionResult> GetSupplierData(DataRequest request)
        {
            var data = await _supplierCore.ListAsync(User.Identity.Name, request);
            return Json(data);
        }


        //post supplier
        [HttpPost]
        public async Task<IActionResult> PostSupplier([FromBody] SupplierAddModel model)
        {
            var response = await _supplierCore.AddAsync(User.Identity.Name, model);
            return Json(response);
        }


        //get supplier by {id}
        public async Task<IActionResult> GetSupplierById(int? id)
        {
            if (!id.HasValue) return NotFound();

            var response = await _supplierCore.GetAsync(id.GetValueOrDefault());
            return Json(response);
        }


        //update supplier
        [HttpPut]
        public async Task<IActionResult> UpdateSupplier([FromBody] SupplierEditModel model)
        {
            var response = await _supplierCore.EditAsync(model);
            return Json(response);
        }


        //delete supplier
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var response = await _supplierCore.DeleteAsync(id);
            return Json(response);
        }

        #endregion


        #region Purchase

        public IActionResult Index()
        {
            return View();
        }


        //post purchase
        [HttpPost]
        public async Task<IActionResult> PostPurchase([FromBody] PurchaseAddModel model)
        {
            var response = await _purchaseCore.AddAsync(User.Identity.Name, model);
            return Json(response);
        }


        //purchase receipt
        public async Task<IActionResult> Receipt(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Records");

            var model = await _purchaseCore.GetAsync(id.GetValueOrDefault());
            return View(model.Data);
        }


        //purchase records view
        public IActionResult Records()
        {
            return View();
        }


        //purchase records (data-table)
        public async Task<IActionResult> GetRecordsData(DataRequest request)
        {
            var response = await _purchaseCore.ListAsync(User.Identity.Name, request);
            return Json(response);
        }

        //view update purchase
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");
            
            var response = await _purchaseCore.GetAsync(id.GetValueOrDefault());
            ViewBag.updateData = response.Data;
           
            return View();
        }


        //post update purchase
        [HttpPut]
        public async Task<IActionResult> UpdatePurchase([FromBody] PurchaseEditModel model)
        {
            var response = await _purchaseCore.EditAsync(model);
            return Json(response);
        }
        #endregion
    }
}
