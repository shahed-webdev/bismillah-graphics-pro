using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public interface IProductRepository
{
    DbResponse<ProductViewModel> Add(ProductAddModel model);
    DbResponse Edit(ProductEditModel model);
    DbResponse Delete(int id);
    DbResponse<ProductViewModel> Get(int id);
    bool IsExistName(int branchId, string name);
    bool IsExistName(int branchId, string name, int updateId);
    bool IsNull(int id);
    bool IsRelatedDataExist(int id);
    DataResult<ProductViewModel> List(int branchId, DataRequest request);

    Task<List<ProductViewModel>> SearchAsync(int branchId, string key, bool isStock);
    void AddStock(int productId, decimal stock);
    void SubtractStock(int productId, decimal stock);
    bool IsInStock(int productId, decimal sellingSellingQuantity);
    List<ProductReportModel> SaleReport(int branchId, DateTime? sDate, DateTime? eDate);
}