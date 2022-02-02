using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public interface ISmsCore
{
    Task<DbResponse> SendMultipleToVendorAsync(string userName, SmsSendMultipleModel model);
    Task<DbResponse> SendSingleSmsAsync(string userName, SmsSendSingleModel model);
    Task<DataResult<SmsSendRecordViewModel>> SendRecordsAsync(string userName, DataRequest request);
    Task<DbResponse<int>> SmsBalanceAsync();
}