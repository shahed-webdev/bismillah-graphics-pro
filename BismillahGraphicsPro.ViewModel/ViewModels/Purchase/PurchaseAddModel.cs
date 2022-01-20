namespace BismillahGraphicsPro.ViewModel;

public class PurchaseAddModel
{
    public PurchaseAddModel()
    {
        PurchaseLists = new List<PurchaseListAddModel>();
    }

    public int SupplierId { get; set; }
    public int AccountId { get; set; }
    public decimal PurchaseTotalPrice { get; set; }
    public decimal PurchaseDiscountAmount { get; set; }
    public decimal PurchasePaidAmount { get; set; }
    public decimal PurchaseDueAmount { get; set; }
    public string? Description { get; set; }
    public DateTime PurchaseDate { get; set; }
    public List<PurchaseListAddModel> PurchaseLists { get; set; }
}

public class PurchaseListAddModel
{
    public int ProductId { get; set; }
    public int MeasurementUnitId { get; set; }
    public decimal PurchaseQuantity { get; set; }
    public decimal PurchaseUnitPrice { get; set; }
    public decimal? PurchasePrice { get; set; }
}