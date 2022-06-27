using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
using SmsServices;

namespace BismillahGraphicsPro.Repository;

public class SmsRepository : Repository, ISmsRepository
{
    public SmsRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public DbResponse SendMultipleToVendor(int branchId, SmsSendMultipleModel model)
    {
        var massageLength = SmsValidator.MassageLength(model.TextSms);
        var smsCount = SmsValidator.TotalSmsCount(model.TextSms);
        var vendorCount = model.Vendors.Count();

        var totalSms = smsCount * vendorCount;

        var numbers = string.Join(",", model.Vendors.Select(v => v.SmsNumber));
        var smsProvider = new SmsProviderBuilder();

        var smsBalance = smsProvider.SmsBalance();
        if (smsBalance < totalSms) return new DbResponse(false, $"No SMS Balance");

        var providerSendId = smsProvider.SendSms(model.TextSms, numbers);

        if (!smsProvider.IsSuccess) return new DbResponse(false, smsProvider.Error);

        var smsRecord = model.Vendors.Select(v => new SmsSendRecord
        {
            BranchId = branchId,
            PhoneNumber = v.SmsNumber,
            TextSms = model.TextSms,
            TextCount = massageLength,
            Smscount = smsCount,
            VendorId = v.VendorId,
            SmsProviderSendId = providerSendId,
            SendDate = DateTime.Now
        }).ToList();
        Db.SmsSendRecords.AddRange(smsRecord);
        Db.SaveChanges();
        return new DbResponse(true, "SMS send Successfully");
    }

    public DbResponse SendSingleSms(int branchId, SmsSendSingleModel model)
    {
        var massageLength = SmsValidator.MassageLength(model.TextSms);
        var smsCount = SmsValidator.TotalSmsCount(model.TextSms);

        var smsProvider = new SmsProviderBuilder();

        var smsBalance = smsProvider.SmsBalance();
        if (smsBalance < smsCount) return new DbResponse(false, $"No SMS Balance");

        var providerSendId = smsProvider.SendSms(model.TextSms, model.PhoneNumber);

        if (!smsProvider.IsSuccess) return new DbResponse(false, smsProvider.Error);

        var smsRecord = new SmsSendRecord
        { 
            BranchId = branchId,
            PhoneNumber = model.PhoneNumber,
            TextSms = model.TextSms,
            TextCount = massageLength,
            Smscount = smsCount,
            SmsProviderSendId = providerSendId,
            SendDate = DateTime.Now
        };
        Db.SmsSendRecords.Add(smsRecord);
        Db.SaveChanges();
        return new DbResponse(true, "SMS send Successfully");
    }

    public DataResult<SmsSendRecordViewModel> SendRecords(int branchId, DataRequest request)
    {
        return Db.SmsSendRecords.Where(s=> s.BranchId == branchId)
            .ProjectTo<SmsSendRecordViewModel>(_mapper.ConfigurationProvider)
            .ToDataResult(request);
    }

    public DbResponse<int> SmsBalance()
    {
        var smsProvider = new SmsProviderBuilder();
        return new DbResponse<int>(true, "Sms Balance Get Successfully", smsProvider.SmsBalance());
    }

    public DbResponse<int> SmsSentCount(int branchId, DateTime? sDate, DateTime? eDate)
    {
        var startDate = sDate ?? new DateTime(1970, 1, 1);
        var endDate = eDate ?? new DateTime(3000, 1, 1);

        var smsCount = Db.SmsSendRecords.Where(p => p.BranchId == branchId && p.SendDate <= endDate && p.SendDate >= startDate)
            .Sum(v =>v.Smscount);
        return new DbResponse<int>(true, $"get successfully",smsCount);
    }
}