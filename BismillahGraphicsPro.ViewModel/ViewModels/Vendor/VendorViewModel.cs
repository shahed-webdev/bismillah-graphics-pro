namespace BismillahGraphicsPro.ViewModel;

public class VendorViewModel
{
    public int VendorId { get; set; }
    public int BranchId { get; set; }
    public string VendorCompanyName { get; set; } = null!;
    public string? VendorName { get; set; }
    public string? VendorAddress { get; set; }
    public string? VendorPhone { get; set; }
    public string? SmsNumber { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal VendorPaid { get; set; }
    public decimal? VendorDue { get; set; }
}