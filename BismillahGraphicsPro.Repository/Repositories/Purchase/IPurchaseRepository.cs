using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public interface IPurchaseRepository
{
    int GetPurchaseSn(int branchId);
    int GetReceiptSn(int branchId);
    DbResponse<int> Add(int branchId, int registrationId, int purchaseSn, int receiptSn, PurchaseAddModel model);
    DbResponse<PurchaseReceiptViewModel> Get(int id);
    DbResponse<int> Edit(PurchaseEditModel model);
    DataResult<PurchaseRecordViewModel> List(int branchId, DataRequest request);
}