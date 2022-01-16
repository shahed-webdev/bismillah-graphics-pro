﻿using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMeasurementUnitCore _measurementUnit;
        public ProductController(IMeasurementUnitCore measurementUnit)
        {
            _measurementUnit = measurementUnit;
        }

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
            var response = _measurementUnit.Add(model);
            return Json(response);
        } //post Measurement unit


        //Update MeasurementUnit
        [HttpPut]
        public IActionResult UpdateMeasurementUnit([FromBody] MeasurementUnitCrudModel model)
        {
            var response = _measurementUnit.Edit(model);
            return Json(response);
        }
    }
}
