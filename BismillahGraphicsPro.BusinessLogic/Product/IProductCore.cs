using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public interface IProductCore
{

    Task<DbResponse<ProductViewModel>> AddAsync(string userName, ProductAddModel model);
    Task<DbResponse> EditAsync(ProductEditModel model);
    Task<DbResponse> DeleteAsync(int id);
    Task<DbResponse<ProductViewModel>> GetAsync(int id);
    Task<DataResult<ProductViewModel>> ListAsync(string userName, DataRequest request);
    Task<List<ProductViewModel>> SearchAsync(string userName, string key, bool isStock);
    //Product category
    Task<DbResponse<ProductCategoryCrudModel>> CategoryAddAsync(string categoryName, string userName);
    Task<DbResponse> CategoryEditAsync(ProductCategoryCrudModel model);
    Task<DbResponse> CategoryDeleteAsync(int id);
    Task<DbResponse<ProductCategoryCrudModel>> CategoryGetAsync(int id);
    Task<List<ProductCategoryCrudModel>> CategoryListAsync(string userName);
    Task<List<DDL>> CategoryDdlAsync(string userName);
    Task<List<ProductReportModel>> SaleReportAsync(string userName, DateTime? sDate, DateTime? eDate);
}