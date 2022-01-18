using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMeasurementUnitCore _measurementUnit;
        private readonly IProductCore _productCore;

        public ProductController(IMeasurementUnitCore measurementUnit, IProductCore productCore)
        {
            _measurementUnit = measurementUnit;
            _productCore = productCore;
        }

        #region Measurement unit

        //view Measurement unit
        public IActionResult MeasurementUnit()
        {
            return View();
        }

        //get Measurement unit
        public IActionResult GetMeasurementUnit()
        {
            var data = _measurementUnit.List(User.Identity.Name);
            return Json(data);
        }

        //post Measurement unit
        [HttpPost]
        public IActionResult PostMeasurementUnit([FromBody] MeasurementUnitCrudModel model)
        {
            var response = _measurementUnit.Add(model.MeasurementUnitName, User.Identity.Name);
            return Json(response);
        }


        //Update MeasurementUnit
        [HttpPut]
        public IActionResult UpdateMeasurementUnit([FromBody] MeasurementUnitCrudModel model)
        {
            var response = _measurementUnit.Edit(model);
            return Json(response);
        }

        //delete MeasurementUnit
        [HttpDelete]
        public IActionResult DeleteMeasurementUnit(int id)
        {
            var response = _measurementUnit.Delete(id);
            return Json(response);
        }

        #endregion


        #region Product Category
       
        //view product Category
        public IActionResult Category()
        {
            return View();
        }

        //get Measurement unit
        public async Task<IActionResult> GetCategory()
        {
            var data = await _productCore.CategoryListAsync(User.Identity.Name);
            return Json(data);
        }


        //post product Category
        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] string categoryName)
        {
            var response = await _productCore.CategoryAddAsync(categoryName, User.Identity.Name);
            return Json(response);
        }


        //Update Category
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] ProductCategoryCrudModel model)
        {
            var response = await _productCore.CategoryEditAsync(model);
            return Json(response);
        }

        //delete Category
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = await _productCore.CategoryDeleteAsync(id);
            return Json(response);
        }

        #endregion


        #region Product

        //view product
        public async Task<IActionResult> Index()
        {
            ViewBag.productCategory = await _productCore.CategoryDdlAsync(User.Identity.Name);

            return View();
        }

        //get all products
        public async Task<IActionResult> GetProducts(DataRequest request)
        {
            var data = await _productCore.ListAsync(User.Identity.Name, request);
            return Json(data);
        }

        //get product by {id}
        public async Task<IActionResult> GetProduct(int id)
        {
            var response = await _productCore.GetAsync(id);
            return Json(response);
        }


        //post product
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] ProductAddModel model)
        {
            var response = await _productCore.AddAsync(User.Identity.Name, model);
            return Json(response);
        }


        //Update Product
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductEditModel model)
        {
            var response = await _productCore.EditAsync(model);
            return Json(response);
        }

        //delete Product
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productCore.DeleteAsync(id);
            return Json(response);
        }

        #endregion
    }
}