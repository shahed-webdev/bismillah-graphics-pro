using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
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

        //account view
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


        //get account
        public IActionResult GetWithdraw()
        {
            var response = _account.List(User.Identity.Name);
            return Json(response);
        }

        //deposit view
        public IActionResult Deposit(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");

            var model = _account.Get(id.GetValueOrDefault());
            return View(model.Data);
        }

        //get deposit data-table
        public IActionResult GetDepositData(DataRequest request)
        {
            var response = _account.DepositList(request);
            return Json(response);
        }

        //post deposit account
        [HttpPost]
        public IActionResult PostDeposit([FromBody] AccountDepositViewModel model)
        {
            var response = _account.Deposit(User.Identity.Name,model);
            return Json(response);
        }


        //withdraw view
        public IActionResult Withdraw(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");

            var model = _account.Get(id.GetValueOrDefault());
            return View(model.Data);
        }

        //get Withdraw data-table
        public IActionResult GetWithdrawData(DataRequest request)
        {
            var response = _account.WithdrawList(request);
            return Json(response);
        }

        //post Withdraw account
        [HttpPost]
        public IActionResult PostWithdraw([FromBody] AccountWithdrawViewModel model)
        {
            var response = _account.Withdraw(User.Identity.Name, model);
            return Json(response);
        }
    }
}
