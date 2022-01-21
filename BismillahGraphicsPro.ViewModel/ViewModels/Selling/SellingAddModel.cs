namespace BismillahGraphicsPro.ViewModel;

public class SellingAddModel
{
    public SellingAddModel()
    {
        SellingLists = new List<SellingListAddModel>();
    }

    public int VendorId { get; set; }
    public int AccountId { get; set; }
    public decimal SellingTotalPrice { get; set; }
    public decimal SellingDiscountAmount { get; set; }
    public decimal SellingPaidAmount { get; set; }
    public decimal SellingDueAmount { get; set; }
    public string? Description { get; set; }
    public DateTime SellingDate { get; set; }
    public List<SellingListAddModel> SellingLists { get; set; }
}

public class SellingListAddModel
{
    public int ProductId { get; set; }
    public int MeasurementUnitId { get; set; }
    public decimal SellingQuantity { get; set; }
    public decimal SellingUnitPrice { get; set; }
    public double Length { get; set; }
    public double Width { get; set; }
    public decimal? SellingPrice { get; set; }
}