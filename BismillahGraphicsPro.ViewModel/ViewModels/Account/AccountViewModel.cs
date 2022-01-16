namespace BismillahGraphicsPro.ViewModel;

public class AccountViewModel
{
    public int AccountId { get; set; }
    public int BranchId { get; set; }
    public string AccountName { get; set; } = null!;
    public decimal Balance { get; set; }
}