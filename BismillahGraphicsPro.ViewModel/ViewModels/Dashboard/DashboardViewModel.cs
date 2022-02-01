namespace BismillahGraphicsPro.ViewModel;

public class DashboardViewModel
{
    public DashboardViewModel()
    {
        MonthlyReports = new List<MonthIncomeExpenseViewModel>();
    }

    public decimal SaleYearly { get; set; }
    public decimal ExpenseYearly { get; set; }
    public decimal NetYearly { get; set; }
    public decimal TotalDue { get; set; }
    public List<MonthIncomeExpenseViewModel> MonthlyReports { get; set; }
}

public class MonthIncomeExpenseViewModel
{
    public string Month { get; set; } = null!;
    public decimal Income { get; set; }
    public decimal Expense { get; set; }
}