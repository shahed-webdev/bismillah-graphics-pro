using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public interface ISmsCore
{
    Task<DbResponse> SendMultipleToVendorAsync(SmsSendMultipleModel model);
    Task<DbResponse> SendSingleSmsAsync(SmsSendSingleModel model);
    Task<DataResult<SmsSendRecordViewModel>> SendRecordsAsync(DataRequest request);
    Task<DbResponse<int>> SmsBalanceAsync();
}