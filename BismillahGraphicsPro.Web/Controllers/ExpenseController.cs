using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseCore _expenseCore;
        public ExpenseController(IExpenseCore expenseCore)
        {
            this._expenseCore = expenseCore;
        }

        //expense view
        public IActionResult Index()
        {
            return View();
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
