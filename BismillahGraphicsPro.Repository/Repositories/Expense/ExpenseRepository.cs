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
        var expanse = _mapper.Map<Expanse>(model);
        Db.Expanses.Add(expanse);
        Db.SaveChanges();
        
        var expenseView = _mapper.Map<ExpenseViewModel>(Db.Expanses.Find(expanse.ExpanseId));

        return new DbResponse<ExpenseViewModel>(true, $"{model.ExpanseAmount} Added Successfully", expenseView);

    }
    public DbResponse<ExpenseViewModel> Get(int id)
    {
        var expense = Db.Expanses.Where(r => r.ExpanseId == id)
            .ProjectTo<ExpenseViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();
        return expense == null ? new DbResponse<ExpenseViewModel>(false, "Data not found") 
            : new DbResponse<ExpenseViewModel>(true, $"{expense!.AccountName} Get Successfully", expense);
    }
    public DataResult<ExpenseViewModel> List(DataRequest request, int branchId)
    {
        return Db.Expanses
            .Where(e=> e.BranchId == branchId)
            .ProjectTo<ExpenseViewModel>(_mapper.ConfigurationProvider)
            .OrderByDescending(a => a.ExpanseDate)
            .ToDataResult(request);
    }

    public DbResponse Delete(int id)
    {
        var expanse = Db.Expanses.Find(id);
        if (expanse == null) return new DbResponse(false, "data Not Found");

        Db.Expanses.Remove(expanse);
        Db.SaveChanges();
        return new DbResponse(true, $"{expanse.ExpanseAmount} Deleted Successfully");
    }
    public bool IsNull(int id)
    {
        return !Db.Expanses.Any(r => r.ExpanseId == id);
    }
}