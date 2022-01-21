namespace BismillahGraphicsPro.ViewModel;

public class SellingRecordViewModel
{
    public int SellingId { get; set; }
    public int BranchId { get; set; }
    public string? SoldByUserName { get; set; }
    public int VendorId { get; set; }
    public string VendorCompanyName { get; set; } = null!;
    public string? VendorSmsNumber { get; set; }
    public int SellingSn { get; set; }
    public decimal SellingTotalPrice { get; set; }
    public decimal SellingPaidAmount { get; set; }
    public decimal SellingDueAmount { get; set; }
    public string? Description { get; set; }
    public DateTime SellingDate { get; set; }
}