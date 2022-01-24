namespace BismillahGraphicsPro.ViewModel;

public class SellingDuePayModel
{
    public SellingDuePayModel()
    {
        Bills = new List<SellingDuePayRecord>();
    }
    public int VendorId { get; set; }
    public int AccountId { get; set; }
    public decimal PaidAmount { get; set; }
    public DateTime PaidDate { get; set; }
    public string? Description { get; set; }

    public List<SellingDuePayRecord> Bills { get; set; }
}
public class SellingDuePayRecord
{
    public int SellingId { get; set; }
    public decimal SellingPaidAmount { get; set; }
    public decimal SellingDiscountAmount { get; set; }
}