using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.BusinessLogic;

public interface IExpenseCore
{
    DbResponse<ExpanseCategoryCrudModel> CategoryAdd(string categoryName, string userName);
    DbResponse CategoryEdit(ExpanseCategoryCrudModel model);
    DbResponse CategoryDelete(int id);
    DbResponse<ExpanseCategoryCrudModel> CategoryGet(int id);
    List<ExpanseCategoryCrudModel> CategoryList(string userName);
    List<DDL> CategoryDdl(string userName);
}