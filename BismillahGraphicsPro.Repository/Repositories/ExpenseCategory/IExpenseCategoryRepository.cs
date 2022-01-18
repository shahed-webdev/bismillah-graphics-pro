using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public interface IExpenseCategoryRepository
{
    DbResponse<ExpenseCategoryCrudModel> Add(ExpenseCategoryCrudModel model);
    DbResponse Edit(ExpenseCategoryCrudModel model);
    DbResponse Delete(int id);
    DbResponse<ExpenseCategoryCrudModel> Get(int id);
    bool IsExistName(int branchId, string name);
    bool IsExistName(int branchId, string name, int updateId);
    bool IsNull(int id);
    bool IsRelatedDataExist(int id);
    List<ExpenseCategoryCrudModel> List(int branchId);
    List<DDL> ListDdl(int branchId);
}