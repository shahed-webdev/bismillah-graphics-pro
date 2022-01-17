using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public interface IExpanseCategoryRepository
{
    DbResponse<ExpanseCategoryCrudModel> Add(ExpanseCategoryCrudModel model);
    DbResponse Edit(ExpanseCategoryCrudModel model);
    DbResponse Delete(int id);
    DbResponse<ExpanseCategoryCrudModel> Get(int id);
    bool IsExistName(int branchId, string name);
    bool IsExistName(int branchId, string name, int updateId);
    bool IsNull(int id);
    bool IsRelatedDataExist(int id);
    List<ExpanseCategoryCrudModel> List(int branchId);
    List<DDL> ListDdl(int branchId);
}