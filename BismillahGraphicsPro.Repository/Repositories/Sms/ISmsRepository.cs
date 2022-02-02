using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public interface ISmsRepository
{
    DbResponse SendMultipleToVendor(SmsSendMultipleModel model);
    DbResponse SendSingleSms(SmsSendSingleModel model);
    DataResult<SmsSendRecordViewModel> SendRecords(DataRequest request);
    DbResponse<int> SmsBalance();
}