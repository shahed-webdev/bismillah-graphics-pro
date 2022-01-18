using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public class ExpenseRepository: Repository, IExpenseRepository
{
    public ExpenseRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public DbResponse<ExpenseViewModel> Add(ExpenseAddModel model)
    {
        var Expense = _mapper.Map<Expense>(model);
        Db.Expenses.Add(Expense);
        Db.SaveChanges();
        
        var expenseView = _mapper.Map<ExpenseViewModel>(Db.Expenses.Find(Expense.ExpenseId));

        return new DbResponse<ExpenseViewModel>(true, $"{model.ExpenseAmount} Added Successfully", expenseView);

    }
    public DbResponse<ExpenseViewModel> Get(int id)
    {
        var expense = Db.Expenses.Where(r => r.ExpenseId == id)
            .ProjectTo<ExpenseViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();
        return expense == null ? new DbResponse<ExpenseViewModel>(false, "Data not found") 
            : new DbResponse<ExpenseViewModel>(true, $"{expense!.AccountName} Get Successfully", expense);
    }
    public DataResult<ExpenseViewModel> List(DataRequest request, int branchId)
    {
        return Db.Expenses
            .Where(e=> e.BranchId == branchId)
            .ProjectTo<ExpenseViewModel>(_mapper.ConfigurationProvider)
            .OrderByDescending(a => a.ExpenseDate)
            .ToDataResult(request);
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
}