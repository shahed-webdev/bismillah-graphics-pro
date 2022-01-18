namespace BismillahGraphicsPro.ViewModel;

public class SupplierViewModel
{
    public int SupplierId { get; set; }
    public int BranchId { get; set; }
    public string SupplierCompanyName { get; set; } = null!;
    public string? SupplierName { get; set; }
    public string? SupplierAddress { get; set; }
    public string? SupplierPhone { get; set; }
    public string? SmsNumber { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal SupplierPaid { get; set; }
    public decimal? SupplierDue { get; set; }
}