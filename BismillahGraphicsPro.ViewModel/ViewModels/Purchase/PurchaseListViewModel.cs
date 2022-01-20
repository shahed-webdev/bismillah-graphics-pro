namespace BismillahGraphicsPro.ViewModel;

public class PurchaseListViewModel
{
    public int PurchaseListId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public int MeasurementUnitId { get; set; }
    public string MeasurementUnitName { get; set; } = null!;
    public decimal PurchaseQuantity { get; set; }
    public decimal PurchaseUnitPrice { get; set; }
    public decimal? PurchasePrice { get; set; }
}