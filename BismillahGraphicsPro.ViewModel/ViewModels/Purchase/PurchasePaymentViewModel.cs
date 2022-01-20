namespace BismillahGraphicsPro.ViewModel;

public class PurchasePaymentViewModel
{
    public int PurchasePaymentRecordId { get; set; }
    public int AccountId { get; set; }
    public string AccountName { get; set; } = null!;
    public string? Description { get; set; }
    public decimal PurchasePaidAmount { get; set; }
    public DateTime PurchasePaidDate { get; set; }
}