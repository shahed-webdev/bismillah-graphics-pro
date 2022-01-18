using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
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
    }
}