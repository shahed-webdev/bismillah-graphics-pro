using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public interface IExpenseCore
{
    Task<DbResponse<ExpenseViewModel>> AddAsync(string userName, ExpenseAddModel model);
    Task<DataResult<ExpenseViewModel>> ListAsync(string userName, DataRequest request);
    Task<DbResponse> DeleteAsync(int id);

    Task<DbResponse<ExpanseCategoryCrudModel>> CategoryAddAsync(string categoryName, string userName);
    Task<DbResponse> CategoryEditAsync(ExpanseCategoryCrudModel model);
    Task<DbResponse> CategoryDeleteAsync(int id);
    Task<DbResponse<ExpanseCategoryCrudModel>> CategoryGetAsync(int id);
    Task<List<ExpanseCategoryCrudModel>> CategoryListAsync(string userName);
    Task<List<DDL>> CategoryDdlAsync(string userName);
}