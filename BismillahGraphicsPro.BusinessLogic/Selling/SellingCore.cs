using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public class SellingCore : Core, ISellingCore
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

            var sellingResponse = _db.Selling.Add(branchId, registrationId, sellingSn, receiptSn, model);
            if (!sellingResponse.IsSuccess) return Task.FromResult(new DbResponse<int>(false, sellingResponse.Message));

            _db.Vendor.UpdatePaidDue(model.VendorId);

            foreach (var item in model.SellingLists)
            {
                _db.Product.SubtractStock(item.ProductId, item.SellingQuantity);
            }

            //-----------Account and Account log added-----------------------------
            if (model.SellingPaidAmount > 0)
            {
                _db.Account.BalanceAdd(model.AccountId, model.SellingPaidAmount);

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

    public Task<DbResponse> DeleteAsync(string userName, int id)
    {
        try
        {
            var branchId = _db.Registration.BranchIdByUserName(userName);
            var deleteResponse = _db.Selling.Delete(branchId, id);
            if (!deleteResponse.IsSuccess) return Task.FromResult(new DbResponse(deleteResponse.IsSuccess, deleteResponse.Message));

            var vendorId = deleteResponse.Data;

            _db.Vendor.UpdatePaidDue(vendorId);

            return Task.FromResult(new DbResponse(true, deleteResponse.Message));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<int>> EditAsync(SellingEditModel model)
    {
        try
        {
            if (!model.SellingLists.Any())
                return Task.FromResult(new DbResponse<int>(false, "Invalid Data"));

            return Task.FromResult(_db.Selling.Edit(model));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse<int>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DataResult<SellingRecordViewModel>> ListAsync(string userName, DataRequest request)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.Selling.List(branchId, request));
    }
    public Task<DataResult<SellingPaymentViewModel>> PaymentListAsync(string userName, DataRequest request)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.Selling.PaymentList(branchId, request));
    }

    public Task<DbResponse<SellingPaymentReceiptViewModel>> GetPaymentDetailsAsync(string userName, int SellingReceiptId)
    {
        try
        {
            var branchId = _db.Registration.BranchIdByUserName(userName);
            return Task.FromResult(_db.Selling.GetPaymentDetails(branchId, SellingReceiptId));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<SellingPaymentReceiptViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<int>> DueCollectionAsync(string userName, SellingDuePayModel model)
    {
        try
        {
            if (model.PaidAmount <= 0)
                return Task.FromResult(new DbResponse<int>(false, "Paid amount must be greater than zero"));
            var branchId = _db.Registration.BranchIdByUserName(userName);
            var registrationId = _db.Registration.RegistrationIdByUserName(userName);

            var receiptSn = _db.Selling.GetReceiptSn(branchId);


            var sellingResponse = _db.Selling.UpdateDiscountAndPaid(model.Bills);
            if (!sellingResponse.IsSuccess)
                return Task.FromResult(new DbResponse<int>(sellingResponse.IsSuccess, sellingResponse.Message));

            var sellingPaymentResponse = _db.Selling.DueCollection(branchId, registrationId, receiptSn, model);

            if (!sellingPaymentResponse.IsSuccess)
                return Task.FromResult(new DbResponse<int>(sellingPaymentResponse.IsSuccess,
                    sellingPaymentResponse.Message));
            //-----------Account and Account log added-----------------------------

            _db.Vendor.UpdatePaidDue(model.VendorId);

            _db.Account.BalanceAdd(model.AccountId, model.PaidAmount);


            var accountLogs = sellingPaymentResponse.Data.SellingPaymentRecords.Select(p =>
                new AccountLogAddModel
                {
                    AccountId = model.AccountId,
                    BranchId = branchId,
                    RegistrationId = registrationId,
                    IsAdded = true,
                    Amount = p.SellingPaidAmount,
                    Details = $"Receipt No:{receiptSn}, {model.Description}",
                    Type = AccountLogType.Sale,
                    TableName = AccountLogTableName.SellingPaymentRecord,
                    TableId = p.SellingPaymentRecordId,
                    LogDate = p.SellingPaidDate
                }).ToList();

            _db.AccountLog.AddRange(accountLogs);

            return Task.FromResult(new DbResponse<int>(true, $"Paid Successfully",
                sellingPaymentResponse.Data.SellingReceiptId));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse<int>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<SellingDueViewModel>> GetVendorWiseDueAsync(int vendorId, DateTime? sDate, DateTime? eDate)
    {
        try
        {
            if (vendorId == 0)
                return Task.FromResult(new DbResponse<SellingDueViewModel>(false, "Invalid Data"));

            return Task.FromResult(_db.Selling.GetVendorWiseDue(vendorId, sDate, eDate));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<SellingDueViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<decimal>> GetTotalDueAsync(string userName, DateTime? sDate, DateTime? eDate)
    {
        try
        {
            var branchId = _db.Registration.BranchIdByUserName(userName);
            return Task.FromResult(new DbResponse<decimal>(true, "Success",
                _db.Selling.TotalDue(branchId, sDate, eDate)));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse<decimal>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }
    public Task<DbResponse<decimal>> GetTotalPaidAsync(string userName, DateTime? sDate, DateTime? eDate)
    {
        try
        {
            var branchId = _db.Registration.BranchIdByUserName(userName);
            return Task.FromResult(new DbResponse<decimal>(true, "Success",
                _db.Selling.TotalPaid(branchId, sDate, eDate)));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse<decimal>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<decimal>> GetTotalSaleAsync(string userName, DateTime? sDate, DateTime? eDate)
    {
        try
        {
            var branchId = _db.Registration.BranchIdByUserName(userName);
            return Task.FromResult(new DbResponse<decimal>(true, "Success",
                _db.Selling.TotalSale(branchId, sDate, eDate)));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse<decimal>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }
}