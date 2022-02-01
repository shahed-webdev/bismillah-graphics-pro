using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
   [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountCore _account;
        public AccountController(IAccountCore account)
        {
            _account = account;
        }


        #region Account

        //account view
        [Authorize(Roles = "Admin, Account")]
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

        #endregion


        #region Deposit

        //deposit view
        [Authorize(Roles = "Admin, Account")]
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

        #endregion


        #region Withdraw

        //withdraw view
        [Authorize(Roles = "Admin, Account")]
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

        #endregion


        #region Transaction Log

        //TransactionLog view
        [Authorize(Roles = "Admin, TransactionLog")]
        public IActionResult TransactionLog()
        {
            return View();
        }

        //get transaction Log data-table
        public async Task<IActionResult> GetTransactionLogData(DataRequest request)
        {
            var response = await _account.LogListAsync(User.Identity.Name,request);
            return Json(response);
        }

        #endregion


        #region Balance Sheet

        //Balance Sheet view
        [Authorize(Roles = "Admin, BalanceSheet")]
        public IActionResult BalanceSheet()
        {
            return View();
        }

        //get transaction Log data-table
        public async Task<IActionResult> GetBalanceSheet(int accountId, DateTime from, DateTime to)
        {
            var response = await _account.BalanceSheetAsync(User.Identity.Name, accountId, from, to);
            return Json(response);
        }

        #endregion
    }
}
