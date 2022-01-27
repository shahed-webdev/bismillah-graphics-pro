using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BismillahGraphicsPro.Web.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ExpenseController : Controller
    {
        private readonly IExpenseCore _expenseCore;
        private readonly IAccountCore _account;

        public ExpenseController(IExpenseCore expenseCore, IAccountCore account)
        {
            this._expenseCore = expenseCore;
            _account = account;
        }


        #region Expense

        //expense view
        public async Task<IActionResult> Index()
        {
            //category dropdown list
            ViewBag.categoryDropdown = await _expenseCore.CategoryDdlAsync(User.Identity.Name);

            //account dropdown list
            ViewBag.accountDropdown = _account.ListDdl(User.Identity.Name);


            return View();
        }


        //get expense
        public async Task<IActionResult> GetExpense(DataRequest request)
        {
            var data = await _expenseCore.ListAsync(User.Identity.Name, request);
            return Json(data);
        }


        //post expense
        [HttpPost]
        public async Task<IActionResult> PostExpense([FromBody] ExpenseAddModel model)
        {
            var response = await _expenseCore.AddAsync(User.Identity.Name,model);
            return Json(response);
        }


        //delete expense
        [HttpDelete]
        public async Task <IActionResult> DeleteExpense(int id)
        {
            var response = await _expenseCore.DeleteAsync(id);
            return Json(response);
        }

        #endregion


        #region Category

        //**category view**//
        public IActionResult Category()
        {
            return View();
        }


        //get Category
        public async Task<IActionResult> GetCategory()
        {
            var data = await _expenseCore.CategoryListAsync(User.Identity.Name);
            return Json(data);
        }

        //post Category
        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] ExpenseCategoryCrudModel model)
        {
            var response = await _expenseCore.CategoryAddAsync(model.CategoryName, User.Identity.Name);
            return Json(response);
        }


        //Update Category
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] ExpenseCategoryCrudModel model)
        {
            var response = await _expenseCore.CategoryEditAsync(model);
            return Json(response);
        }

        //delete Category
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = await _expenseCore.CategoryDeleteAsync(id);
            return Json(response);
        }

        #endregion


        //expense report view
        public IActionResult Report()
        {
            return View();
        }

        //get category
        public async Task<IActionResult> GetCategoryExpense(DateTime from, DateTime to)
        {
            var response =await _expenseCore.CategoryWiseExpenseAsync(User.Identity.Name,from,to);
            return Json(response);
        } 
        
        
        //get total expense
        public async Task<IActionResult> GetTotal(DateTime from, DateTime to)
        {
            var response =await _expenseCore.TotalExpenseAsync(User.Identity.Name,from,to);
            return Json(response);
        }

    }
}