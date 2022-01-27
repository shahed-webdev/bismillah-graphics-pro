using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
using Microsoft.EntityFrameworkCore;

namespace BismillahGraphicsPro.Repository;

public class ExpenseRepository : Repository, IExpenseRepository
{
    public ExpenseRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public DbResponse<ExpenseViewModel> Add(ExpenseAddModel model)
    {
        var expense = _mapper.Map<Expense>(model);
        Db.Expenses.Add(expense);
        Db.SaveChanges();
        
        var expenseView = _mapper.Map<ExpenseViewModel>(Db.Expenses.Find(expense.ExpenseId));

        return new DbResponse<ExpenseViewModel>(true, $"{model.ExpenseAmount} Added Successfully", expenseView);
    }

    public DbResponse<ExpenseViewModel> Get(int id)
    {
        var expense = Db.Expenses.Where(r => r.ExpenseId == id)
            .ProjectTo<ExpenseViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();
        return expense == null
            ? new DbResponse<ExpenseViewModel>(false, "Data not found")
            : new DbResponse<ExpenseViewModel>(true, $"{expense!.AccountName} Get Successfully", expense);
    }

    public DataResult<ExpenseViewModel> List(DataRequest request, int branchId)
    {
        return Db.Expenses
            .Where(e => e.BranchId == branchId)
            .ProjectTo<ExpenseViewModel>(_mapper.ConfigurationProvider)
            .OrderByDescending(a => a.ExpenseDate)
            .ToDataResult(request);
    }

    public List<int> GetYears(int branchId)
    {
        var years = Db.Expenses.Where(e => e.BranchId == branchId)
            .GroupBy(e => new
            {
                e.ExpenseDate.Year
            })
            .Select(g => g.Key.Year)
            .OrderBy(o => o)
            .ToList();

        var currentYear = DateTime.Now.Year;

        if (!years.Contains(currentYear)) years.Add(currentYear);
        return years;
    }

    public List<ExpenseCategoryWiseViewModel> CategoryWiseExpense(int branchId, DateTime? sDate, DateTime? eDate)
    {
        var startDate = sDate ?? new DateTime(1000, 1, 1);
        var endDate = eDate ?? new DateTime(3000, 1, 1);

        var ex = Db.Expenses
            .Include(e => e.ExpenseCategory)
            .Where(e => e.ExpenseDate <= endDate && e.ExpenseDate >= startDate)
            .GroupBy(e => new
            {
                ExpanseCategoryId = e.ExpenseCategoryId,
                CategoryName = e.ExpenseCategory.CategoryName
            })
            .Select(g => new ExpenseCategoryWiseViewModel
            {
                ExpanseCategoryId = g.Key.ExpanseCategoryId,
                CategoryName = g.Key.CategoryName,
                TotalExpanse = Math.Round(g.Sum(e => e.ExpenseAmount), 2)
            })
            .OrderByDescending(e => e.TotalExpanse)
            .ToList();

        return ex;
    }

    public decimal TotalExpense(int branchId, DateTime? sDate, DateTime? eDate)
    {
        var startDate = sDate ?? new DateTime(1000, 1, 1);
        var endDate = eDate ?? new DateTime(3000, 1, 1);
        return Db.Expenses
            .Where(p => p.BranchId == branchId && p.ExpenseDate <= endDate && p.ExpenseDate >= startDate)
            .Sum(s => s.ExpenseAmount);
    }

    public DbResponse Delete(int id)
    {
        var Expense = Db.Expenses.Find(id);
        if (Expense == null) return new DbResponse(false, "data Not Found");

        Db.Expenses.Remove(Expense);
        Db.SaveChanges();
        return new DbResponse(true, $"{Expense.ExpenseAmount} Deleted Successfully");
    }

    public bool IsNull(int id)
    {
        return !Db.Expenses.Any(r => r.ExpenseId == id);
    }

    public decimal YearlyAmount(int branchId, int year)
    {
       return Db.Expenses
            .Where(s => s.BranchId == branchId && s.ExpenseDate.Year == year)
            .Sum(s => s.ExpenseAmount);
    }

    public List<MonthlyAmount> MonthlyAmounts(int branchId, int year)
    {
        var months = Db.Expenses.Where(e => e.BranchId == branchId && e.ExpenseDate.Year == year)
            .GroupBy(e => new
            {
                number = e.ExpenseDate.Month
            })
            .Select(g => new MonthlyAmount
            {
                MonthNumber = g.Key.number,
                Amount = Math.Round(g.Sum(e => e.ExpenseAmount), 2)
            })
            .ToList();

        return months;
    }
}