namespace BismillahGraphicsPro.ViewModel;

public class PurchasePaymentRecordViewModel
{
    public int PurchasePaymentRecordId { get; set; }
    public int AccountId { get; set; }
    public string AccountName { get; set; } = null!;
    public string? Description { get; set; }
    public decimal PurchasePaidAmount { get; set; }
    public DateTime PurchasePaidDate { get; set; }
}