using AutoMapper;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public class SupplierCore:Core, ISupplierCore
{
    public SupplierCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
    {
    }
    public Task<DbResponse<SupplierViewModel>> AddAsync(string userName, SupplierAddModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.SupplierName) || string.IsNullOrEmpty(model.SmsNumber))
                return Task.FromResult(new DbResponse<SupplierViewModel>(false, "Invalid Data"));
            var branchId = _db.Registration.BranchIdByUserName(userName);

            if (_db.Supplier.IsExistName(branchId, model.SmsNumber))
                return Task.FromResult(new DbResponse<SupplierViewModel>(false, $" {model.SupplierName} already Exist"));

            return Task.FromResult(_db.Supplier.Add(branchId,model));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<SupplierViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse> EditAsync(SupplierEditModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.SupplierName) || string.IsNullOrEmpty(model.SmsNumber))
                return Task.FromResult(new DbResponse(false, "Invalid Data"));


            if (_db.Supplier.IsExistName(model.BranchId, model.SupplierName, model.SupplierId))
                return Task.FromResult(new DbResponse(false, $" {model.SupplierName} already Exist"));


            return Task.FromResult(_db.Supplier.Edit(model));
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
            if (_db.Supplier.IsRelatedDataExist(id))
                return Task.FromResult(new DbResponse(false, "Failed, already exist in Suppliers"));

            return Task.FromResult(_db.Supplier.Delete(id));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<SupplierViewModel>> GetAsync(int id)
    {
        try
        {
            return Task.FromResult(_db.Supplier.Get(id));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<SupplierViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DataResult<SupplierViewModel>> ListAsync(string userName, DataRequest request)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.Supplier.List(branchId, request));
    }
}