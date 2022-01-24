using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public class PurchaseCore : Core, IPurchaseCore
{
    public PurchaseCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
    {
    }

    public Task<DbResponse<int>> AddAsync(string userName, PurchaseAddModel model)
    {
        try
        {
            if (!model.PurchaseLists.Any())
                return Task.FromResult(new DbResponse<int>(false, "Invalid Data"));

            var branchId = _db.Registration.BranchIdByUserName(userName);
            var registrationId = _db.Registration.RegistrationIdByUserName(userName);
            var purchaseSn = _db.Purchase.GetPurchaseSn(branchId);
            var receiptSn = _db.Purchase.GetReceiptSn(branchId);

            var purchaseResponse = _db.Purchase.Add(branchId, registrationId, purchaseSn, receiptSn, model);
            if (!purchaseResponse.IsSuccess)
                return Task.FromResult(new DbResponse<int>(false, purchaseResponse.Message));

            _db.Supplier.UpdatePaidDue(model.SupplierId, model.PurchaseTotalPrice, model.PurchaseDiscountAmount,
                model.PurchasePaidAmount);

            foreach (var item in model.PurchaseLists)
            {
                _db.Product.AddStock(item.ProductId, item.PurchaseQuantity);
            }

            //-----------Account and Account log added-----------------------------
            if (model.PurchasePaidAmount > 0)
            {
                _db.Account.BalanceSubtract(model.AccountId, model.PurchasePaidAmount);

                var accountLog = new AccountLogAddModel
                {
                    AccountId = model.AccountId,
                    BranchId = branchId,
                    RegistrationId = registrationId,
                    IsAdded = false,
                    Amount = model.PurchasePaidAmount,
                    Details = $"Receipt No:{receiptSn}, {model.Description}",
                    Type = AccountLogType.Purchase,
                    TableName = AccountLogTableName.PurchasePaymentRecord,
                    TableId = purchaseResponse.Data,
                    LogDate = model.PurchaseDate
                };

                _db.AccountLog.Add(accountLog);
            }

            return Task.FromResult(purchaseResponse);
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse<int>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<PurchaseReceiptViewModel>> GetAsync(int id)
    {
        try
        {
            return Task.FromResult(_db.Purchase.Get(id));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<PurchaseReceiptViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<int>> EditAsync(PurchaseEditModel model)
    {
        try
        {
            if (!model.PurchaseLists.Any())
                return Task.FromResult(new DbResponse<int>(false, "Invalid Data"));

            return Task.FromResult(_db.Purchase.Edit(model));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse<int>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DataResult<PurchaseRecordViewModel>> ListAsync(string userName, DataRequest request)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.Purchase.List(branchId, request));
    }

    public Task<DbResponse<int>> DuePayAsync(string userName, PurchaseDuePayModel model)
    {
        try
        {
            if (model.PaidAmount <= 0) return Task.FromResult(new DbResponse<int>(false, "Paid amount must be greater than zero"));
            var branchId = _db.Registration.BranchIdByUserName(userName);
            var registrationId = _db.Registration.RegistrationIdByUserName(userName);

            var receiptSn = _db.Purchase.GetReceiptSn(branchId);


            var purchaseResponse = _db.Purchase.UpdateDiscountAndPaid(model.Bills);
            if (!purchaseResponse.IsSuccess)
                return Task.FromResult(new DbResponse<int>(purchaseResponse.IsSuccess, purchaseResponse.Message));

            var purchasePaymentResponse = _db.Purchase.DuePay(branchId, registrationId, receiptSn, model);

            if (!purchasePaymentResponse.IsSuccess)
                return Task.FromResult(new DbResponse<int>(purchasePaymentResponse.IsSuccess, purchasePaymentResponse.Message));
            //-----------Account and Account log added-----------------------------

            _db.Supplier.UpdatePaidDue(model.SupplierId, model.PaidAmount, purchaseResponse.Data, model.PaidAmount);

            _db.Account.BalanceSubtract(model.AccountId, model.PaidAmount);


            var accountLogs = purchasePaymentResponse.Data.PurchasePaymentRecords.Select(p =>
                new AccountLogAddModel
                {
                    AccountId = model.AccountId,
                    BranchId = branchId,
                    RegistrationId = registrationId,
                    IsAdded = false,
                    Amount = p.PurchasePaidAmount,
                    Details = $"Receipt No:{receiptSn}, {model.Description}",
                    Type = AccountLogType.Purchase,
                    TableName = AccountLogTableName.PurchasePaymentRecord,
                    TableId = p.PurchasePaymentRecordId,
                    LogDate = p.PurchasePaidDate
                }).ToList();

            _db.AccountLog.AddRange(accountLogs);

            return Task.FromResult(new DbResponse<int>(true,$"Paid Successfully", purchasePaymentResponse.Data.PurchaseReceiptId));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse<int>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }
}