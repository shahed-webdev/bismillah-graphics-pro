using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public interface IVendorCore
{
    Task<DbResponse<VendorViewModel>> AddAsync(string userName, VendorAddModel model);
    Task<DbResponse> EditAsync(VendorEditModel model);
    Task<DbResponse> DeleteAsync(int id);
    Task<DbResponse<VendorViewModel>> GetAsync(int id);
    Task<DataResult<VendorViewModel>> ListAsync(string userName, DataRequest request);
    Task<List<VendorViewModel>> SearchAsync(string userName, string key);
}