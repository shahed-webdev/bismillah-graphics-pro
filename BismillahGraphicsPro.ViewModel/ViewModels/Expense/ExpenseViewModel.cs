namespace BismillahGraphicsPro.ViewModel;

public class ExpenseViewModel
{
    public int ExpanseId { get; set; }
    public int BranchId { get; set; }
    public int RegistrationId { get; set; }
    public int ExpanseCategoryId { get; set; }
    public int AccountId { get; set; }
    public string ExpenseByUserName { get; set; }
    public string CategoryName { get; set; }
    public string AccountName { get; set; }
    public decimal ExpanseAmount { get; set; }
    public string? ExpanseFor { get; set; }
    public DateTime ExpanseDate { get; set; }
}