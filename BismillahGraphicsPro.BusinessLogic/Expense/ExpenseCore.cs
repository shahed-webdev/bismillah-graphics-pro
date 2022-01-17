using AutoMapper;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.BusinessLogic;

public class ExpenseCore: Core, IExpenseCore
{
    public ExpenseCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
    {
    }

    public DbResponse<ExpanseCategoryCrudModel> CategoryAdd(string categoryName, string userName)
    {
        try
        {

            if (string.IsNullOrEmpty(categoryName))
                return new DbResponse<ExpanseCategoryCrudModel>(false, "Invalid Data");

            var model = new ExpanseCategoryCrudModel
            {
                BranchId = _db.Registration.BranchIdByUserName(userName),
                CategoryName = categoryName
            };

            if (_db.ExpanseCategory.IsExistName(model.BranchId, model.CategoryName))
                return new DbResponse<ExpanseCategoryCrudModel>(false, $" {model.CategoryName} already Exist");

            return _db.ExpanseCategory.Add(model);

        }
        catch (Exception e)
        {
            return new DbResponse<ExpanseCategoryCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
        }
    }

    public DbResponse CategoryEdit(ExpanseCategoryCrudModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.CategoryName))
                return new DbResponse(false, "Invalid Data");

            if (!_db.ExpanseCategory.IsNull(model.ExpanseCategoryId))
                return new DbResponse(false, "No Data Found");

            if (_db.ExpanseCategory.IsExistName(model.BranchId, model.CategoryName, model.ExpanseCategoryId))
                return new DbResponse(false, $" {model.CategoryName} already Exist");


            return _db.ExpanseCategory.Edit(model);

        }
        catch (Exception e)
        {
            return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
        }
    }

    public DbResponse CategoryDelete(int id)
    {
        try
        {
            if (!_db.ExpanseCategory.IsNull(id))
                return new DbResponse(false, "No data Found");

            if (_db.ExpanseCategory.IsRelatedDataExist(id))
                return new DbResponse(false, "Failed, already exist in products");

            return _db.ExpanseCategory.Delete(id);

        }
        catch (Exception e)
        {
            return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
        }
    }

    public DbResponse<ExpanseCategoryCrudModel> CategoryGet(int id)
    {
        try
        {
            if (_db.ExpanseCategory.IsNull(id))
                return new DbResponse<ExpanseCategoryCrudModel>(false, "No data Found");

            return _db.ExpanseCategory.Get(id);

        }
        catch (Exception e)
        {
            return new DbResponse<ExpanseCategoryCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
        }
    }

    public List<ExpanseCategoryCrudModel> CategoryList(string userName)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return _db.ExpanseCategory.List(branchId);
    }

    public List<DDL> CategoryDdl(string userName)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return _db.ExpanseCategory.ListDdl(branchId);
    }
}