using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public interface ISmsRepository
{
    DbResponse SendMultipleToVendor(int branchId, SmsSendMultipleModel model);
    DbResponse SendSingleSms(int branchId, SmsSendSingleModel model);
    DataResult<SmsSendRecordViewModel> SendRecords(int branchId, DataRequest request);
    DbResponse<int> SmsBalance();
}