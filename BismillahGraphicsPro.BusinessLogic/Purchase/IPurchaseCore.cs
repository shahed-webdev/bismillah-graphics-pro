using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public interface IPurchaseCore
{
    Task<DbResponse<int>> AddAsync(string userName, PurchaseAddModel model);
    Task<DbResponse<PurchaseReceiptViewModel>> GetAsync(int id);
    Task<DbResponse<int>> EditAsync(PurchaseEditModel model);
    Task<DataResult<PurchaseRecordViewModel>> ListAsync(string userName, DataRequest request);
    Task<DbResponse<int>> DuePayAsync(string userName, PurchaseDuePayModel model);
}