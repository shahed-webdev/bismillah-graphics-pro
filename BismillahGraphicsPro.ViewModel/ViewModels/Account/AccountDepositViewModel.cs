namespace BismillahGraphicsPro.ViewModel;

public class AccountDepositViewModel
{
    public int AccountDepositId { get; set; }
    public int AccountId { get; set; }
    public decimal DepositAmount { get; set; }
    public string? Description { get; set; }
    public DateTime DepositDate { get; set; }
}