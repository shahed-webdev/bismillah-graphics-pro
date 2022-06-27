namespace BismillahGraphicsPro.ViewModel;

public class SmsSendRecordViewModel
{
    public string PhoneNumber { get; set; } = null!;
    public string TextSms { get; set; } = null!;
    public int TextCount { get; set; }
    public int SmsCount { get; set; }
    public DateTime SendDate { get; set; }
}