namespace BismillahGraphicsPro.ViewModel;

public class ExpenseAddModel
{
    public int BranchId { get; set; }
    public int RegistrationId { get; set; }
    public int ExpanseCategoryId { get; set; }
    public int AccountId { get; set; }
    public decimal ExpanseAmount { get; set; }
    public string? ExpanseFor { get; set; }
    public DateTime ExpanseDate { get; set; }
}