using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public interface IExpenseRepository
{
    DbResponse<ExpenseViewModel> Add(ExpenseAddModel model);
    DbResponse<ExpenseViewModel> Get(int id);
    DataResult<ExpenseViewModel> List(DataRequest request, int branchId);
    List<int> GetYears(int branchId);
    List<ExpenseCategoryWiseViewModel> CategoryWiseExpense(int branchId, DateTime? sDate, DateTime? eDate);
    decimal TotalExpense(int branchId, DateTime? sDate, DateTime? eDate);
    DbResponse Delete(int id);
    bool IsNull(int id);
    decimal YearlyAmount(int branchId, int year);
    List<MonthlyAmount> MonthlyAmounts(int branchId, int year);
}