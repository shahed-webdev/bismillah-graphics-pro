using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public interface IExpenseRepository
{
    DbResponse<ExpenseViewModel> Add(ExpenseAddModel model);
    DbResponse<ExpenseViewModel> Get(int id);
    DataResult<ExpenseViewModel> List(DataRequest request, int branchId);
    DbResponse Delete(int id);
    bool IsNull(int id);
}