namespace BismillahGraphicsPro.ViewModel;

public class SellingDueViewModel
{
    public SellingDueViewModel()
    {
        Sellings = new List<SellingDueBillsViewModel>();
    }
    public int VendorId { get; set; }
    public int BranchId { get; set; }
    public string VendorCompanyName { get; set; } = null!;
    public string? VendorAddress { get; set; }
    public string? SmsNumber { get; set; }
    public decimal Amount { get; set; }
    public decimal Discount { get; set; }
    public decimal Paid { get; set; }
    public decimal Due { get; set; }
    public decimal TotalDue { get; set; }
    public List<SellingDueBillsViewModel> Sellings { get; set; }
}

public class SellingDueBillsViewModel
{
    public int SellingId { get; set; }
    public int SellingSn { get; set; }
    public decimal SellingTotalPrice { get; set; }
    public decimal SellingDiscountAmount { get; set; }
    public decimal SellingPaidAmount { get; set; }
    public decimal SellingDueAmount { get; set; }
    public DateTime SellingDate { get; set; }
}