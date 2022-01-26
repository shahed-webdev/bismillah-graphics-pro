using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public interface IPurchaseCore
{
    Task<DbResponse<int>> AddAsync(string userName, PurchaseAddModel model);
    Task<DbResponse<PurchaseReceiptViewModel>> GetAsync(string userName, int id);
    Task<DbResponse<int>> EditAsync(PurchaseEditModel model);
    Task<DataResult<PurchaseRecordViewModel>> ListAsync(string userName, DataRequest request);
    Task<DataResult<PurchasePaymentViewModel>> PaymentListAsync(string userName, DataRequest request);
    Task<DbResponse<PurchasePaymentReceiptViewModel>> GetPaymentDetailsAsync(string userName, int purchaseReceiptId);
    Task<DbResponse<int>> DuePayAsync(string userName, PurchaseDuePayModel model);
    Task<DbResponse<PurchaseDueViewModel>> GetSupplierWiseDueAsync(int supplierId, DateTime? sDate, DateTime? eDate);
    Task<DbResponse<decimal>> GetTotalDueAsync(string userName, DateTime? sDate, DateTime? eDate);
    Task<DbResponse<decimal>> GetTotalPaidAsync(string userName, DateTime? sDate, DateTime? eDate);
}