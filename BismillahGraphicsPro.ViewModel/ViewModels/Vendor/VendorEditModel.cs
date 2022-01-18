namespace BismillahGraphicsPro.ViewModel;

public class VendorEditModel
{
    public int VendorId { get; set; }
    public int BranchId { get; set; }
    public string VendorCompanyName { get; set; } = null!;
    public string? VendorName { get; set; }
    public string? VendorAddress { get; set; }
    public string? VendorPhone { get; set; }
    public string? SmsNumber { get; set; }
}