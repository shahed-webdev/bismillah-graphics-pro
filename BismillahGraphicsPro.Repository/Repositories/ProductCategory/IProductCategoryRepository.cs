using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public interface IProductCategoryRepository
{
    DbResponse<ProductCategoryCrudModel> Add(ProductCategoryCrudModel model);
    DbResponse Edit(ProductCategoryCrudModel model);
    DbResponse Delete(int id);
    DbResponse<ProductCategoryCrudModel> Get(int id);
    bool IsExistName(int branchId, string name);
    bool IsExistName(int branchId, string name, int updateId);
    bool IsNull(int id);
    bool IsRelatedDataExist(int id);
    List<ProductCategoryCrudModel> List(int branchId);
    List<DDL> ListDdl(int branchId);
}