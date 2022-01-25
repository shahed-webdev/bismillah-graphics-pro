namespace BismillahGraphicsPro.ViewModel;

public class PurchaseDueViewModel
{
    public PurchaseDueViewModel()
    {
        Purchases = new List<PurchaseDueBillsViewModel>();
    }
    public int SupplierId { get; set; }
    public int BranchId { get; set; }
    public string SupplierCompanyName { get; set; } = null!;
    public string? SupplierAddress { get; set; }
    public string? SmsNumber { get; set; }
    public decimal Amount { get; set; }
    public decimal Discount { get; set; }
    public decimal Paid { get; set; }
    public decimal Due { get; set; }
    public decimal TotalDue { get; set; }
    public List<PurchaseDueBillsViewModel> Purchases { get; set; }
}

public class PurchaseDueBillsViewModel
{
    public int PurchaseId { get; set; }
    public int PurchaseSn { get; set; }
    public decimal PurchaseTotalPrice { get; set; }
    public decimal PurchaseDiscountAmount { get; set; }
    public decimal PurchasePaidAmount { get; set; }
    public decimal PurchaseDueAmount { get; set; }
    public DateTime PurchaseDate { get; set; }
}