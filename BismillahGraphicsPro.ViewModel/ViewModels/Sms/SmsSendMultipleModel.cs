namespace BismillahGraphicsPro.ViewModel;

public class SmsSendMultipleModel
{
    public SmsSendMultipleModel()
    {
        Vendors = new List<SmsSendVendorModel>();
    }

    public string TextSms { get; set; } = null!;
    public ICollection<SmsSendVendorModel> Vendors { get; set; }
   

}

public class SmsSendVendorModel
{
    public int VendorId { get; set; }
    public string SmsNumber { get; set; } = null!;
}