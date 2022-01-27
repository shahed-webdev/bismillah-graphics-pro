using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public interface IPurchaseRepository
{
    int GetPurchaseSn(int branchId);
    int GetReceiptSn(int branchId);
    DbResponse<int> Add(int branchId, int registrationId, int purchaseSn, int receiptSn, PurchaseAddModel model);
    DbResponse<PurchaseReceiptViewModel> Get(int branchId,int id);
    List<int> GetYears(int branchId);
    DbResponse<int> Edit(PurchaseEditModel model);
    DbResponse UpdateDiscountAndPaid(List<PurchaseDuePayRecord> bills);
    DataResult<PurchaseRecordViewModel> List(int branchId, DataRequest request);
    DataResult<PurchasePaymentViewModel> PaymentList(int branchId, DataRequest request);
    DbResponse<PurchasePaymentReceiptViewModel> GetPaymentDetails(int branchId, int purchaseReceiptId);
    DbResponse<PurchasePaymentReceipt> DuePay(int branchId, int registrationId, int receiptSn,
        PurchaseDuePayModel model);

    DbResponse<PurchaseDueViewModel> GetSupplierWiseDue(int supplierId, DateTime? sDate, DateTime? eDate);
    decimal TotalDue(int branchId, DateTime? sDate, DateTime? eDate);
    decimal TotalPaid(int branchId, DateTime? sDate, DateTime? eDate);
    decimal TotalPurchase(int branchId, DateTime? sDate, DateTime? eDate);

}