namespace BismillahGraphicsPro.ViewModel;

public class PurchaseEditModel
{
    public int PurchaseId { get; set; }
    public int SupplierId { get; set; }
    public decimal PurchaseTotalPrice { get; set; }
    public decimal PurchaseDiscountAmount { get; set; }
    public string? Description { get; set; }
    public List<PurchaseListAddModel> PurchaseLists { get; set; }
}