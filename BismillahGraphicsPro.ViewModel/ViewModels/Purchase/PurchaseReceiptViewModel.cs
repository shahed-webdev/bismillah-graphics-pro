namespace BismillahGraphicsPro.ViewModel;

public class PurchaseReceiptViewModel
{
    public PurchaseReceiptViewModel()
    {
        PurchaseLists = new List<PurchaseListViewModel>();
        PurchasePaymentRecords = new List<PurchasePaymentViewModel>();
    }

    public int PurchaseId { get; set; }
    public int BranchId { get; set; }
    public string? SoldByUserName { get; set; }
    public int SupplierId { get; set; }
    public int PurchaseSn { get; set; }
    public decimal PurchaseTotalPrice { get; set; }
    public decimal PurchaseDiscountAmount { get; set; }
    public decimal PurchasePaidAmount { get; set; }
    public decimal PurchaseDueAmount { get; set; }
    public string? Description { get; set; }
    public DateTime PurchaseDate { get; set; }
    public SupplierViewModel Supplier { get; set; }
    public List<PurchaseListViewModel> PurchaseLists { get; set; }
    public List<PurchasePaymentViewModel> PurchasePaymentRecords { get; set; }
}