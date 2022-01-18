namespace BismillahGraphicsPro.ViewModel;

public class ProductEditModel
{
    public int ProductId { get; set; }
    public int BranchId { get; set; }
    public int ProductCategoryId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal ProductPrice { get; set; }
}