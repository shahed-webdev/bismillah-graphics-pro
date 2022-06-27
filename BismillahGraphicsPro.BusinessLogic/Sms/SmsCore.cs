using AutoMapper;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public class SmsCore : Core, ISmsCore
{
    public SmsCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
    {
    }

    public Task<DbResponse> SendMultipleToVendorAsync(string userName, SmsSendMultipleModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.TextSms))
                return Task.FromResult(new DbResponse(false, "No text to send"));
           
            var branchId = _db.Registration.BranchIdByUserName(userName);
            return Task.FromResult(_db.Sms.SendMultipleToVendor(branchId, model));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse> SendSingleSmsAsync(string userName, SmsSendSingleModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.TextSms))
                return Task.FromResult(new DbResponse(false, "No text to send"));
            var branchId = _db.Registration.BranchIdByUserName(userName);
            return Task.FromResult(_db.Sms.SendSingleSms(branchId, model));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DataResult<SmsSendRecordViewModel>> SendRecordsAsync(string userName, DataRequest request)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.Sms.SendRecords(branchId, request));
    }

    public Task<DbResponse<int>> SmsBalanceAsync()
    {
        try
        {
            return Task.FromResult(_db.Sms.SmsBalance());
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse<int>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<int>> SmsSentCountAsync(string userName, DateTime? sDate, DateTime? eDate)
    {
        try
        {
            var branchId = _db.Registration.BranchIdByUserName(userName);
            return Task.FromResult(new DbResponse<int>(true, "Success",
                _db.Sms.SmsSentCount(branchId, sDate, eDate)));
            
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse<int>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }
}