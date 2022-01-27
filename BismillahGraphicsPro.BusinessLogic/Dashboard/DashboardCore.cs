using AutoMapper;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.BusinessLogic;

public class DashboardCore : Core, IDashboardCore
{
    public DashboardCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
    {
    }

    public Task<List<DDL>> GetYearsAsync(string userName)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        var years = _db.Expense.GetYears(branchId);
        years = years.Union(_db.Selling.GetYears(branchId)).ToList();
        years = years.Union(_db.Purchase.GetYears(branchId)).ToList();

        return Task.FromResult(years.Select(y => new DDL
        {
            value = y.ToString(),
            label = "Year: " + y.ToString()
        }).ToList());
    }

    public Task<DashboardViewModel> GetAsync(string userName, int? year)
    {
        var getYear = year ?? DateTime.Now.Year;
        var branchId = _db.Registration.BranchIdByUserName(userName);

        var sale = _db.Selling.YearlyAmount(branchId, getYear);
        var expense = _db.Expense.YearlyAmount(branchId, getYear);
        var dashboardModel = new DashboardViewModel
        {
            SaleYearly = sale,
            ExpenseYearly = expense,
            NetYearly = sale - expense,
            TotalDue = _db.Selling.TotalDue(branchId, null, null),
            MonthlyReports = GetMonthlyReports(branchId, getYear)
        };


        return Task.FromResult(dashboardModel);
    }

    public Task<List<MonthIncomeExpenseViewModel>> GetMonthlyNetReports(string userName, int? year)
    {
        var getYear = year ?? DateTime.Now.Year;
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(GetMonthlyReports(branchId, getYear));
    }

    private List<MonthIncomeExpenseViewModel> GetMonthlyReports(int branchId, int year)
    {
        var months = new AllMonth();

        var a = months.AllMonthNames;
        var b = _db.Expense.MonthlyAmounts(branchId, year);
        var c = _db.Selling.MonthlyAmounts(branchId, year);

        var result = (from m in months.AllMonthNames
            join e in _db.Expense.MonthlyAmounts(branchId, year) on m.MonthNumber equals e.MonthNumber
                into expanse
            from e in expanse.DefaultIfEmpty()
            join s in _db.Selling.MonthlyAmounts(branchId, year) on m.MonthNumber equals s.MonthNumber
                into sell
            from s in sell.DefaultIfEmpty()
            select new MonthIncomeExpenseViewModel
            {
                Month = m.Month,
                Income = s?.Amount ?? 0,
                Expense = e?.Amount ?? 0
            }).ToList();

        return result;
    }
}