namespace BismillahGraphicsPro.ViewModel;

public class DailyCashModel
{
    public DailyCashModel()
    {
        DailyIncomes = new List<SellingPaymentViewModel>();
        DailyExpenses = new List<ExpenseViewModel>();
    }
    public decimal IncomeDaily { get; set; }
    public decimal ExpenseDaily { get; set; }
    public decimal NetDaily { get; set; }

    public List<SellingPaymentViewModel> DailyIncomes { get; set; }
    public List<ExpenseViewModel> DailyExpenses { get; set; }
}