using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
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

        //expense view
        public async Task<IActionResult> Index()
        {
            //category dropdown list
            var category = await _expenseCore.CategoryDdlAsync(User.Identity.Name);
            ViewBag.categoryDropdown = new SelectList(category, "value", "label");

            //account dropdown list
            var account = _account.ListDdl(User.Identity.Name);
            ViewBag.accountDropdown = new SelectList(account, "value", "label");


            return View();
        }


        //Get Expense
        public async Task<IActionResult> GetExpense()
        {
            //category dropdown list
            var data = await _expenseCore.CategoryDdlAsync(User.Identity.Name);
           
            return Json(data);
        }


        //category view
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
        public async Task<IActionResult> PostCategory([FromBody] ExpanseCategoryCrudModel model)
        {
            var response = await _expenseCore.CategoryAddAsync(model.CategoryName, User.Identity.Name);
            return Json(response);
        }


        //Update Category
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] ExpanseCategoryCrudModel model)
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
    }
}