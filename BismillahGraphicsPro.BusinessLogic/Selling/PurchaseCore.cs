using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public class SellingCore: Core, ISellingCore
{
    public SellingCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
    {
    }

    public Task<DbResponse<int>> AddAsync(string userName, SellingAddModel model)
    {
        try
        {
            if (!model.SellingLists.Any())
                return Task.FromResult(new DbResponse<int>(false, "Invalid Data"));
            
            var branchId = _db.Registration.BranchIdByUserName(userName);
            var registrationId = _db.Registration.RegistrationIdByUserName(userName);
            var sellingSn = _db.Selling.GetSellingSn(branchId);
            var receiptSn = _db.Selling.GetReceiptSn(branchId);

            var sellingResponse = _db.Selling.Add(branchId, registrationId,sellingSn, receiptSn, model);
            if(!sellingResponse.IsSuccess) return Task.FromResult(new DbResponse<int>(false, sellingResponse.Message));

            _db.Vendor.UpdatePaidDue(model.VendorId, model.SellingTotalPrice, model.SellingDiscountAmount, model.SellingPaidAmount);

            foreach (var item in model.SellingLists)
            {
                _db.Product.SubtractStock(item.ProductId, item.SellingQuantity);
            }
            //-----------Account and Account log added-----------------------------
            if (model.SellingPaidAmount>0)
            {
                _db.Account.BalanceSubtract(model.AccountId, model.SellingPaidAmount);

                var accountLog = new AccountLogAddModel
                {
                    AccountId = model.AccountId,
                    BranchId = branchId,
                    RegistrationId = registrationId,
                    IsAdded = true,
                    Amount = model.SellingPaidAmount,
                    Details = $"Receipt No:{receiptSn}, {model.Description}",
                    Type = AccountLogType.Sale,
                    TableName = AccountLogTableName.SellingPaymentRecord,
                    TableId = sellingResponse.Data,
                    LogDate = model.SellingDate
                };

                _db.AccountLog.Add(accountLog);
            }
            return Task.FromResult(sellingResponse);
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse<int>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<SellingReceiptViewModel>> GetAsync(int id)
    {
        try
        {
            return Task.FromResult(_db.Selling.Get(id));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<SellingReceiptViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }
    public Task<DbResponse> EditAsync(SellingEditModel model)
    {
        try
        {
            if (!model.SellingLists.Any())
                return Task.FromResult(new DbResponse(false, "Invalid Data"));

            return Task.FromResult(_db.Selling.Edit(model));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }
    public Task<DataResult<SellingRecordViewModel>> ListAsync(string userName, DataRequest request)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.Selling.List(branchId, request));
    }
}