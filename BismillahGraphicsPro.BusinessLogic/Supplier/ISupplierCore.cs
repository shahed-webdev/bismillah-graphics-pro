using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public interface ISupplierCore
{
    Task<DbResponse<SupplierViewModel>> AddAsync(string userName, SupplierAddModel model);
    Task<DbResponse> EditAsync(SupplierEditModel model);
    Task<DbResponse> DeleteAsync(int id);
    Task<DbResponse<SupplierViewModel>> GetAsync(int id);
    Task<DataResult<SupplierViewModel>> ListAsync(string userName, DataRequest request);
    Task<List<SupplierViewModel>> SearchAsync(string userName, string key);

    Task<DbResponse<SupplierViewModel>> GetReportAsync(int id, DateTime? sDate, DateTime? eDate);
}