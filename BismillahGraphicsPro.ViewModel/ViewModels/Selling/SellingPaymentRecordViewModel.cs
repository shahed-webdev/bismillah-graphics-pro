namespace BismillahGraphicsPro.ViewModel;

public class SellingPaymentRecordViewModel
{
    public int SellingPaymentRecordId { get; set; }
    public int AccountId { get; set; }
    public string AccountName { get; set; } = null!;
    public string? Description { get; set; }
    public decimal SellingPaidAmount { get; set; }
    public DateTime SellingPaidDate { get; set; }
}