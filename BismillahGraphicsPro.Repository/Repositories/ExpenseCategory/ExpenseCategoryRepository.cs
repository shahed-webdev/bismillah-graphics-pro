using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class ExpenseCategoryRepository : Repository, IExpenseCategoryRepository
{
    public ExpenseCategoryRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public DbResponse<ExpenseCategoryCrudModel> Add(ExpenseCategoryCrudModel model)
    {
        var ExpenseCategory = _mapper.Map<ExpenseCategory>(model);
        Db.ExpenseCategories.Add(ExpenseCategory);
        Db.SaveChanges();
        model.ExpenseCategoryId = ExpenseCategory.ExpenseCategoryId;

        return new DbResponse<ExpenseCategoryCrudModel>(true, $"{model.CategoryName} Added Successfully", model);
    }

    public DbResponse Edit(ExpenseCategoryCrudModel model)
    {
        var ExpenseCategory = Db.ExpenseCategories.Find(model.ExpenseCategoryId);
        ExpenseCategory!.CategoryName = model.CategoryName;
        Db.ExpenseCategories.Update(ExpenseCategory);
        Db.SaveChanges();
        return new DbResponse(true, $"{ExpenseCategory.CategoryName} Updated Successfully");
    }

    public DbResponse Delete(int id)
    {
        var ExpenseCategory = Db.ExpenseCategories.Find(id);
        if (ExpenseCategory == null) return new DbResponse(false, "data Not Found");

        Db.ExpenseCategories.Remove(ExpenseCategory);
        Db.SaveChanges();
        return new DbResponse(true, $"{ExpenseCategory.CategoryName} Deleted Successfully");
    }

    public DbResponse<ExpenseCategoryCrudModel> Get(int id)
    {
        var measurementUnit = Db.ExpenseCategories.Where(r => r.ExpenseCategoryId == id)
            .ProjectTo<ExpenseCategoryCrudModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();
        return new DbResponse<ExpenseCategoryCrudModel>(true, $"{measurementUnit!.CategoryName} Get Successfully",
            measurementUnit);
    }

    public bool IsExistName(int branchId, string name)
    {
        return Db.ExpenseCategories.Any(r => r.BranchId == branchId && r.CategoryName == name);
    }

    public bool IsExistName(int branchId, string name, int updateId)
    {
        return Db.ExpenseCategories.Any(r =>
            r.BranchId == branchId && r.CategoryName == name && r.ExpenseCategoryId != updateId);
    }

    public bool IsNull(int id)
    {
        return !Db.ExpenseCategories.Any(r => r.ExpenseCategoryId == id);
    }

    public bool IsRelatedDataExist(int id)
    {
        return Db.Expenses.Any(m => m.ExpenseCategoryId == id);
    }

    public List<ExpenseCategoryCrudModel> List(int branchId)
    {
        return Db.ExpenseCategories.Where(m => m.BranchId == branchId)
            .ProjectTo<ExpenseCategoryCrudModel>(_mapper.ConfigurationProvider)
            .OrderBy(a => a.CategoryName)
            .ToList();
    }

    public List<DDL> ListDdl(int branchId)
    {
        return Db.ExpenseCategories
            .OrderBy(a => a.CategoryName)
            .Select(m => new DDL
            {
                value = m.ExpenseCategoryId.ToString(),
                label = m.CategoryName
            }).ToList();
    }
}