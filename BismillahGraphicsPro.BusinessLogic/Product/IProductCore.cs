using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.BusinessLogic;

public interface IProductCore
{
    Task<DbResponse<ProductCategoryCrudModel>> CategoryAddAsync(string categoryName, string userName);
    Task<DbResponse> CategoryEditAsync(ProductCategoryCrudModel model);
    Task<DbResponse> CategoryDeleteAsync(int id);
    Task<DbResponse<ProductCategoryCrudModel>> CategoryGetAsync(int id);
    Task<List<ProductCategoryCrudModel>> CategoryListAsync(string userName);
    Task<List<DDL>> CategoryDdlAsync(string userName);
}