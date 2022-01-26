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
        private readonly IRegistrationCore _registration;

        public PurchaseController(ISupplierCore supplierCore, IPurchaseCore purchaseCore, IMeasurementUnitCore measurementUnit, IRegistrationCore registration)
        {
            _supplierCore = supplierCore;
            _purchaseCore = purchaseCore;
            _registration = registration;
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
            
            //branch info
            var branch = await _registration.GetAsync(User.Identity.Name);
            ViewBag.branchInfo = branch.Data;
            
            var model = await _purchaseCore.GetAsync(User.Identity.Name, id.GetValueOrDefault());
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
            
            var response = await _purchaseCore.GetAsync(User.Identity.Name, id.GetValueOrDefault());
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


        #region Pay Due
        
        //pay due single view
        public async Task<IActionResult> PayDueSingle(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");

            var model = await _purchaseCore.GetAsync(User.Identity.Name, id.GetValueOrDefault());
            return View(model.Data);
        }

        //post single due
        [HttpPost]
        public async Task<IActionResult> PostSingleDue([FromBody] PurchaseDuePayModel model)
        {
            var response = await _purchaseCore.DuePayAsync(User.Identity.Name, model);
            return Json(response);
        }



        //pay due multiple view
        public async Task<IActionResult> PayDueMultiple(int id, DateTime? from, DateTime? to)
        {
            var model = await _purchaseCore.GetSupplierWiseDueAsync(id, from,to);
            ViewBag.dueModel = model.Data;
           
            //for ajax call
            if (from != null || to != null)
            {
                return Json(model);
            }

            return View();
        }


        //post multiple due
        [HttpPost]
        public async Task<IActionResult> PostDues([FromBody] PurchaseDuePayModel model)
        {
            var response = await _purchaseCore.DuePayAsync(User.Identity.Name, model);
            return Json(response);
        }

        #endregion


        public IActionResult DueReport()
        {
            return View();
        } 
        
        //get total due
        //public IActionResult GetSupplierDue()
        //{
        //    var response = _supplierCore.GetAsync()
        //    return Json();
        //}
    }
}
