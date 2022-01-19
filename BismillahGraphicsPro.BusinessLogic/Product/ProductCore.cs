using AutoMapper;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public class ProductCore : Core, IProductCore
{
    public ProductCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
    {
    }

    public Task<DbResponse<ProductViewModel>> AddAsync(string userName, ProductAddModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.ProductName))
                return Task.FromResult(new DbResponse<ProductViewModel>(false, "Invalid Data"));

            var branchId = _db.Registration.BranchIdByUserName(userName);
            model.BranchId = branchId;
            if (_db.Product.IsExistName(model.BranchId, model.ProductName))
                return Task.FromResult(new DbResponse<ProductViewModel>(false, $" {model.ProductName} already Exist"));

            return Task.FromResult(_db.Product.Add(model));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<ProductViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse> EditAsync(ProductEditModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.ProductName))
                return Task.FromResult(new DbResponse(false, "Invalid Data"));


            if (_db.Product.IsExistName(model.BranchId, model.ProductName, model.ProductId))
                return Task.FromResult(new DbResponse(false, $" {model.ProductName} already Exist"));


            return Task.FromResult(_db.Product.Edit(model));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse> DeleteAsync(int id)
    {
        try
        {
            if (_db.Product.IsRelatedDataExist(id))
                return Task.FromResult(new DbResponse(false, "Failed, already exist in products"));

            return Task.FromResult(_db.Product.Delete(id));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<ProductViewModel>> GetAsync(int id)
    {
        try
        {
            return Task.FromResult(_db.Product.Get(id));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<ProductViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DataResult<ProductViewModel>> ListAsync(string userName, DataRequest request)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.Product.List(branchId, request));
    }

    public Task<List<ProductViewModel>> SearchAsync(string userName, string key)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return  _db.Product.SearchAsync(branchId, key);
    }

    public Task<DbResponse<ProductCategoryCrudModel>> CategoryAddAsync(string categoryName, string userName)
    {
        try
        {
            if (string.IsNullOrEmpty(categoryName))
                return Task.FromResult(new DbResponse<ProductCategoryCrudModel>(false, "Invalid Data"));

            var model = new ProductCategoryCrudModel
            {
                BranchId = _db.Registration.BranchIdByUserName(userName),
                ProductCategoryName = categoryName
            };

            if (_db.ProductCategory.IsExistName(model.BranchId, model.ProductCategoryName))
                return Task.FromResult(
                    new DbResponse<ProductCategoryCrudModel>(false, $" {model.ProductCategoryName} already Exist"));

            return Task.FromResult(_db.ProductCategory.Add(model));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<ProductCategoryCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse> CategoryEditAsync(ProductCategoryCrudModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.ProductCategoryName))
                return Task.FromResult(new DbResponse(false, "Invalid Data"));

            if (_db.ProductCategory.IsNull(model.ProductCategoryId))
                return Task.FromResult(new DbResponse(false, "No Data Found"));

            if (_db.ProductCategory.IsExistName(model.BranchId, model.ProductCategoryName, model.ProductCategoryId))
                return Task.FromResult(new DbResponse(false, $" {model.ProductCategoryName} already Exist"));


            return Task.FromResult(_db.ProductCategory.Edit(model));
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
            if (_db.ProductCategory.IsNull(id))
                return Task.FromResult(new DbResponse(false, "No data Found"));

            if (_db.ProductCategory.IsRelatedDataExist(id))
                return Task.FromResult(new DbResponse(false, "Failed, already exist in products"));

            return Task.FromResult(_db.ProductCategory.Delete(id));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<ProductCategoryCrudModel>> CategoryGetAsync(int id)
    {
        try
        {
            if (_db.ProductCategory.IsNull(id))
                return Task.FromResult(new DbResponse<ProductCategoryCrudModel>(false, "No data Found"));

            return Task.FromResult(_db.ProductCategory.Get(id));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<ProductCategoryCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<List<ProductCategoryCrudModel>> CategoryListAsync(string userName)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.ProductCategory.List(branchId));
    }

    public Task<List<DDL>> CategoryDdlAsync(string userName)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.ProductCategory.ListDdl(branchId));
    }
}