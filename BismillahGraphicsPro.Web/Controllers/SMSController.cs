using JqueryDataTables;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    public class SMSController : Controller
    {
        public SMSController()
        {
            
        }


        // Vendor view
        public IActionResult Vendor()
        {
            return View();
        }


        //POST: Vendor
        [HttpPost]
        public IActionResult PostVendor()
        {
            return Json("");
        }


        // Single SMS view
        public IActionResult Single()
        {
            return View();
        }


        //POST: Single SMS
        [HttpPost]
        public IActionResult PostSingle()
        {
            return Json("");
        }

        // Sent Record view
        public IActionResult SentRecord()
        {
            return View();
        }


        //sent data-table
        public IActionResult SentRecordData(DataRequest request)
        {
            return Json("");
        }

    }
}
