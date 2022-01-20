namespace BismillahGraphicsPro.ViewModel;

public class PurchaseRecordViewModel
{
    public int PurchaseId { get; set; }
    public int BranchId { get; set; }
    public string? SoldByUserName { get; set; }
    public int SupplierId { get; set; }
    public string SupplierCompanyName { get; set; } = null!;
    public string? SupplierSmsNumber { get; set; }
    public int PurchaseSn { get; set; }
    public decimal PurchaseTotalPrice { get; set; }
    public decimal PurchasePaidAmount { get; set; }
    public decimal PurchaseDueAmount { get; set; }
    public string? Description { get; set; }
    public DateTime PurchaseDate { get; set; }
}