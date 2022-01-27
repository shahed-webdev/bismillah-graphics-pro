using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public interface IExpenseRepository
{
    DbResponse<ExpenseViewModel> Add(ExpenseAddModel model);
    DbResponse<ExpenseViewModel> Get(int id);
    DataResult<ExpenseViewModel> List(DataRequest request, int branchId);
    List<ExpenseCategoryWiseViewModel> CategoryWiseExpense(int branchId, DateTime? sDate, DateTime? eDate);
    decimal TotalExpense(int branchId, DateTime? sDate, DateTime? eDate);
    DbResponse Delete(int id);
    bool IsNull(int id);
}