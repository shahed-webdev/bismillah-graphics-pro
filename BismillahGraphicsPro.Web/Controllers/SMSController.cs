using JqueryDataTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    [Authorize]
    public class SMSController : Controller
    {
        public SMSController()
        {
            
        }


        // Vendor view
        [Authorize(Roles = "Admin, SMSVendor")]
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
        [Authorize(Roles = "Admin, SMSSingle")]
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
        [Authorize(Roles = "Admin, SentRecord")]
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
