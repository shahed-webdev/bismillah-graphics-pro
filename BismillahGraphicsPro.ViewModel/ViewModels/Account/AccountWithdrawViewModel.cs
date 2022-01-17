namespace BismillahGraphicsPro.ViewModel;

public class AccountWithdrawViewModel
{
    public int AccountWithdrawId { get; set; }
    public int AccountId { get; set; }
    public decimal WithdrawAmount { get; set; }
    public string? Description { get; set; }
    public DateTime WithdrawDate { get; set; }
}