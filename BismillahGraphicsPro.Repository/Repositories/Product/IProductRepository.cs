using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public interface IProductRepository
{
    DbResponse<ProductViewModel> Add(ProductAddModel model);
    DbResponse Edit(ProductViewModel model);
    DbResponse Delete(int id);
    DbResponse<ProductViewModel> Get(int id);
    bool IsExistName(int branchId, string name);
    bool IsExistName(int branchId, string name, int updateId);
    bool IsNull(int id);
    bool IsRelatedDataExist(int id);
    List<ProductViewModel> List(int branchId);
}