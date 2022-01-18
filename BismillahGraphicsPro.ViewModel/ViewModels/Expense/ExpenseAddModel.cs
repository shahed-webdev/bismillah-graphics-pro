namespace BismillahGraphicsPro.ViewModel;

public class ExpenseAddModel
{
    public int BranchId { get; set; }
    public int RegistrationId { get; set; }
    public int ExpenseCategoryId { get; set; }
    public int AccountId { get; set; }
    public decimal ExpenseAmount { get; set; }
    public string? ExpenseFor { get; set; }
    public DateTime ExpenseDate { get; set; }
}