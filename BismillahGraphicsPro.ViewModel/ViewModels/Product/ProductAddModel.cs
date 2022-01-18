namespace BismillahGraphicsPro.ViewModel;

public class ProductAddModel
{
    public int ProductCategoryId { get; set; }
    public int BranchId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal ProductPrice { get; set; }
}