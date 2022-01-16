using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountCore _account;
        public AccountController(IAccountCore account)
        {
            _account = account;
        }

        public IActionResult Index()
        {
            return View();
        }

        //get account
        public IActionResult GetAccount()
        {
            var response = _account.List(User.Identity.Name);
            return Json(response);
        }

        //insert account
        [HttpPost]
        public IActionResult AddAccount(string accountName)
        {
            var response = _account.Add(accountName, User.Identity.Name);
            return Json(response);
        }

        //Update account
        [HttpPut]
        public IActionResult UpdateAccount([FromBody] AccountViewModel model)
        {
            var response = _account.Edit(model);
            return Json(response);
        }

        //Delete account
        [HttpDelete]
        public IActionResult DeleteAccount(int id)
        {
            var response = _account.Delete(id);
            return Json(response);
        }
    }
}
