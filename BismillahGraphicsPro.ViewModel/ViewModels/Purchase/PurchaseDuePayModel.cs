namespace BismillahGraphicsPro.ViewModel;

public class PurchaseDuePayModel
{
    public PurchaseDuePayModel()
    {
        Bills = new List<PurchaseDuePayRecord>();
    }
    public int SupplierId { get; set; }
    public int AccountId { get; set; }
    public decimal PaidAmount { get; set; }
    public DateTime PaidDate { get; set; }
    public string? Description { get; set; }

    public List<PurchaseDuePayRecord> Bills { get; set; }
}
public class PurchaseDuePayRecord
{
    public int PurchaseId { get; set; }
    public decimal PurchasePaidAmount { get; set; }
    public decimal PurchaseDiscountAmount { get; set; }
}