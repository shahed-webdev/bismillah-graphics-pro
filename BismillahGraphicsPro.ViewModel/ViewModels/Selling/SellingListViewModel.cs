namespace BismillahGraphicsPro.ViewModel;

public class SellingListViewModel
{
    public int SellingListId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public int MeasurementUnitId { get; set; }
    public string MeasurementUnitName { get; set; } = null!;
    public decimal SellingQuantity { get; set; }
    public decimal SellingUnitPrice { get; set; }
    public double Length { get; set; }
    public double Width { get; set; }
    public decimal? SellingPrice { get; set; }
}