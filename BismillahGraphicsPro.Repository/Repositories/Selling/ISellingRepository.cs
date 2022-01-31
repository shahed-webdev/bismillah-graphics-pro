using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public interface ISellingRepository
{
    int GetSellingSn(int branchId);
    int GetReceiptSn(int branchId);
    DbResponse<int> Add(int branchId, int registrationId, int sellingSn, int receiptSn, SellingAddModel model);
    DbResponse<SellingReceiptViewModel> Get(int id);
    DbResponse<int> Delete(int branchId, int id);
    List<int> GetYears(int branchId);
    DbResponse<int> Edit(SellingEditModel model);
    DbResponse<decimal> UpdateDiscountAndPaid(List<SellingDuePayRecord> bills);
    DataResult<SellingRecordViewModel> List(int branchId, DataRequest request);
    DataResult<SellingPaymentViewModel> PaymentList(int branchId, DataRequest request);
    DbResponse<SellingPaymentReceiptViewModel> GetPaymentDetails(int branchId, int sellingReceiptId);

    DbResponse<SellingPaymentReceipt> DueCollection(int branchId, int registrationId, int receiptSn,
        SellingDuePayModel model);

    DbResponse<SellingDueViewModel> GetVendorWiseDue(int supplierId, DateTime? sDate, DateTime? eDate);

    decimal TotalDue(int branchId, DateTime? sDate, DateTime? eDate);
    decimal TotalPaid(int branchId, DateTime? sDate, DateTime? eDate);
    decimal TotalSale(int branchId, DateTime? sDate, DateTime? eDate);

    decimal YearlyAmount(int branchId, int year);
    List<MonthlyAmount> MonthlyAmounts(int branchId, int year);
}