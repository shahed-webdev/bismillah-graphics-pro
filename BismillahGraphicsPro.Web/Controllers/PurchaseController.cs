using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ISupplierCore _supplierCore;
        public PurchaseController(ISupplierCore supplierCore)
        {
            _supplierCore = supplierCore;
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
    }
}
