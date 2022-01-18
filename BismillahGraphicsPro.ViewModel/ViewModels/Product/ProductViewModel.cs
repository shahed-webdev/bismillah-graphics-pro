namespace BismillahGraphicsPro.ViewModel;

public class ProductViewModel
{
    public int ProductId { get; set; }
    public int ProductCategoryId { get; set; }
    public string ProductCategoryName { get; set; }
    public int BranchId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal ProductPrice { get; set; }
    public decimal Stock { get; set; }
}