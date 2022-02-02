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

    public Task<DbResponse> SendMultipleToVendorAsync(SmsSendMultipleModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.TextSms))
                return Task.FromResult(new DbResponse(false, "No text to send"));

            return Task.FromResult(_db.Sms.SendMultipleToVendor(model));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse> SendSingleSmsAsync(SmsSendSingleModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.TextSms))
                return Task.FromResult(new DbResponse(false, "No text to send"));

            return Task.FromResult(_db.Sms.SendSingleSms(model));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DataResult<SmsSendRecordViewModel>> SendRecordsAsync(DataRequest request)
    {
        return Task.FromResult(_db.Sms.SendRecords(request));
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
}