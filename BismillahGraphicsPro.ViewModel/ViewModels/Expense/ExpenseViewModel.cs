namespace BismillahGraphicsPro.ViewModel;

public class ExpenseViewModel
{
    public int ExpenseId { get; set; }
    public int BranchId { get; set; }
    public int RegistrationId { get; set; }
    public int ExpenseCategoryId { get; set; }
    public int AccountId { get; set; }
    public string ExpenseByUserName { get; set; }
    public string CategoryName { get; set; }
    public string AccountName { get; set; }
    public decimal ExpenseAmount { get; set; }
    public string? ExpenseFor { get; set; }
    public DateTime ExpenseDate { get; set; }
}