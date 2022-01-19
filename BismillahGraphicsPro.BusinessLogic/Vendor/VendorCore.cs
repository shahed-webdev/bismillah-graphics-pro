using AutoMapper;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public class VendorCore:Core, IVendorCore
{
    public VendorCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
    {
    }
    public Task<DbResponse<VendorViewModel>> AddAsync(string userName, VendorAddModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.VendorName) || string.IsNullOrEmpty(model.SmsNumber))
                return Task.FromResult(new DbResponse<VendorViewModel>(false, "Invalid Data"));
            var branchId = _db.Registration.BranchIdByUserName(userName);

            if (_db.Vendor.IsExistName(branchId, model.SmsNumber))
                return Task.FromResult(new DbResponse<VendorViewModel>(false, $" {model.VendorName} already Exist"));

            return Task.FromResult(_db.Vendor.Add(branchId,model));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<VendorViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse> EditAsync(VendorEditModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.VendorName) || string.IsNullOrEmpty(model.SmsNumber))
                return Task.FromResult(new DbResponse(false, "Invalid Data"));


            if (_db.Vendor.IsExistName(model.BranchId, model.VendorName, model.VendorId))
                return Task.FromResult(new DbResponse(false, $" {model.VendorName} already Exist"));


            return Task.FromResult(_db.Vendor.Edit(model));
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
            if (_db.Vendor.IsRelatedDataExist(id))
                return Task.FromResult(new DbResponse(false, "Failed, already exist in Vendors"));

            return Task.FromResult(_db.Vendor.Delete(id));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<VendorViewModel>> GetAsync(int id)
    {
        try
        {
            return Task.FromResult(_db.Vendor.Get(id));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<VendorViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DataResult<VendorViewModel>> ListAsync(string userName, DataRequest request)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.Vendor.List(branchId, request));
    }

    public Task<List<VendorViewModel>> SearchAsync(string userName, string key)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return _db.Vendor.SearchAsync(branchId, key);
    }
}