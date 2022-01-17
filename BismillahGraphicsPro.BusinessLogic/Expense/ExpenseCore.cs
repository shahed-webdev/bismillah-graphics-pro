using AutoMapper;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.BusinessLogic;

public class ExpenseCore: Core, IExpenseCore
{
    public ExpenseCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
    {
    }

    public Task<DbResponse<ExpanseCategoryCrudModel>> CategoryAddAsync(string categoryName, string userName)
    {
        try
        {

            if (string.IsNullOrEmpty(categoryName))
                return Task.FromResult(new DbResponse<ExpanseCategoryCrudModel>(false, "Invalid Data"));

            var model = new ExpanseCategoryCrudModel
            {
                BranchId = _db.Registration.BranchIdByUserName(userName),
                CategoryName = categoryName
            };

            if (_db.ExpanseCategory.IsExistName(model.BranchId, model.CategoryName))
                return Task.FromResult(new DbResponse<ExpanseCategoryCrudModel>(false, $" {model.CategoryName} already Exist"));

            return Task.FromResult(_db.ExpanseCategory.Add(model));

        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse<ExpanseCategoryCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse> CategoryEditAsync(ExpanseCategoryCrudModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.CategoryName))
                return Task.FromResult(new DbResponse(false, "Invalid Data"));

            if (_db.ExpanseCategory.IsNull(model.ExpanseCategoryId))
                return Task.FromResult(new DbResponse(false, "No Data Found"));

            if (_db.ExpanseCategory.IsExistName(model.BranchId, model.CategoryName, model.ExpanseCategoryId))
                return Task.FromResult(new DbResponse(false, $" {model.CategoryName} already Exist"));


            return Task.FromResult(_db.ExpanseCategory.Edit(model));

        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse> CategoryDeleteAsync(int id)
    {
        try
        {
            if (_db.ExpanseCategory.IsNull(id))
                return Task.FromResult(new DbResponse(false, "No data Found"));

            if (_db.ExpanseCategory.IsRelatedDataExist(id))
                return Task.FromResult(new DbResponse(false, "Failed, already exist in products"));

            return Task.FromResult(_db.ExpanseCategory.Delete(id));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<ExpanseCategoryCrudModel>> CategoryGetAsync(int id)
    {
        try
        {
            if (_db.ExpanseCategory.IsNull(id))
                return Task.FromResult(new DbResponse<ExpanseCategoryCrudModel>(false, "No data Found"));

            return Task.FromResult(_db.ExpanseCategory.Get(id));

        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse<ExpanseCategoryCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<List<ExpanseCategoryCrudModel>> CategoryListAsync(string userName)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.ExpanseCategory.List(branchId));
    }

    public Task<List<DDL>> CategoryDdlAsync(string userName)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.ExpanseCategory.ListDdl(branchId));
    }
}