using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.BusinessLogic;

public interface IDashboardCore
{
    Task<List<DDL>> GetYearsAsync(string userName);
    Task<DashboardViewModel> GetAsync(string userName, int? year);
    Task<List<MonthIncomeExpenseViewModel>> GetMonthlyNetReports(string userName, int? year);
}