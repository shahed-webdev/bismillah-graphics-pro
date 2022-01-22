namespace BismillahGraphicsPro.ViewModel;

public class SellingReceiptViewModel
{
    public SellingReceiptViewModel()
    {
        SellingLists = new List<SellingListViewModel>();
        SellingPaymentRecords = new List<SellingPaymentViewModel>();
    }

    public int SellingId { get; set; }
    public int BranchId { get; set; }
    public string? SoldByUserName { get; set; }
    public int VendorId { get; set; }
    public int SellingSn { get; set; }
    public decimal SellingTotalPrice { get; set; }
    public decimal SellingDiscountAmount { get; set; }
    public decimal SellingPaidAmount { get; set; }
    public decimal SellingDueAmount { get; set; }
    public string? Description { get; set; }
    public DateTime SellingDate { get; set; }
    public VendorViewModel Vendor { get; set; }
    public List<SellingListViewModel> SellingLists { get; set; }
    public List<SellingPaymentViewModel> SellingPaymentRecords { get; set; }
}