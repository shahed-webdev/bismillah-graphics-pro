using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    [Authorize]
    public class SMSController : Controller
    {
        private readonly ISmsCore _sms;
        public SMSController(ISmsCore sms)
        {
            _sms = sms;
        }


        // Vendor view
        public IActionResult Vendor()
        {
            return View();
        }


        //Get Balance
        public async Task<IActionResult> GetBalance()
        {
            var response = await _sms.SmsBalanceAsync();
            return Json(response.Data);
        }  

        
        //POST: Vendor
        [HttpPost]
        public async Task<IActionResult> PostVendor(SmsSendMultipleModel model)
        {
            var response = await _sms.SendMultipleToVendorAsync(User.Identity.Name, model);
            return Json(response);
        }


        // Single SMS view
        public IActionResult Single()
        {
            return View();
        }


        //POST: Single SMS
        [HttpPost]
        public async Task<IActionResult> PostSingle(SmsSendSingleModel model)
        {
            var response = await _sms.SendSingleSmsAsync(User.Identity.Name, model);
            return Json(response);
        }

        // Sent Record view
        public IActionResult SentRecord()
        {
            return View();
        }


        //sent data-table
        public async Task<IActionResult> SentRecordData(DataRequest request)
        {
            var response = await _sms.SendRecordsAsync(User.Identity.Name, request);
            return Json(response);
        }

    }
}
