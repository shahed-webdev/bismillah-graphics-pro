namespace BismillahGraphicsPro.ViewModel;

public class SellingEditModel
{
    public int SellingId { get; set; }
    public int VendorId { get; set; }
    public decimal SellingTotalPrice { get; set; }
    public decimal SellingDiscountAmount { get; set; }
    public string? Description { get; set; }
    public List<SellingListAddModel> SellingLists { get; set; }
}