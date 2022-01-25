using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public interface ISupplierRepository
{
    DbResponse<SupplierViewModel> Add(int branchId, SupplierAddModel model);
    DbResponse Edit(SupplierEditModel model);
    DbResponse Delete(int id);
    DbResponse<SupplierViewModel> Get(int id);
    bool IsExistName(int branchId, string smsNumber);
    bool IsExistName(int branchId, string smsNumber, int updateId);
    bool IsNull(int id);
    bool IsRelatedDataExist(int id);
    DataResult<SupplierViewModel> List(int branchId, DataRequest request);
    Task<List<SupplierViewModel>> SearchAsync(int branchId, string key);
    void UpdatePaidDue(int id);
}