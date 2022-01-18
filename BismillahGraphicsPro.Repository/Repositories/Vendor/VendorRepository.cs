using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public class VendorRepository : Repository, IVendorRepository
{
    public VendorRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public DbResponse<VendorViewModel> Add(int branchId, VendorAddModel model)
    {
        var Vendor = _mapper.Map<Vendor>(model);
        Vendor.BranchId = branchId;
        Db.Vendors.Add(Vendor);
        Db.SaveChanges();

        var VendorViewModel = _mapper.Map<VendorViewModel>(Vendor);

        return new DbResponse<VendorViewModel>(true, $"{VendorViewModel.VendorName} Added Successfully",
            VendorViewModel);
    }

    public DbResponse Edit(VendorEditModel model)
    {
        var Vendor = Db.Vendors.Find(model.VendorId);
        if (Vendor == null) return new DbResponse(false, "data Not Found");

        Vendor.SmsNumber = model.VendorName;
        Vendor.VendorName = model.VendorName;
        Vendor.VendorCompanyName = model.VendorCompanyName;
        Vendor.VendorAddress = model.VendorAddress;
        Vendor.VendorPhone = model.VendorPhone;
        Db.Vendors.Update(Vendor);
        Db.SaveChanges();
        return new DbResponse(true, $"{Vendor.VendorName} Updated Successfully");
    }

    public DbResponse Delete(int id)
    {
        var Vendor = Db.Vendors.Find(id);
        if (Vendor == null) return new DbResponse(false, "data Not Found");

        Db.Vendors.Remove(Vendor);
        Db.SaveChanges();
        return new DbResponse(true, $"{Vendor.VendorName} Deleted Successfully");
    }

    public DbResponse<VendorViewModel> Get(int id)
    {
        var measurementUnit = Db.Vendors.Where(r => r.VendorId == id)
            .ProjectTo<VendorViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();

        return measurementUnit == null
            ? new DbResponse<VendorViewModel>(false, "data Not Found")
            : new DbResponse<VendorViewModel>(true, $"{measurementUnit!.VendorName} Get Successfully",
                measurementUnit);
    }

    public bool IsExistName(int branchId, string smsNumber)
    {
        return Db.Vendors.Any(r => r.BranchId == branchId && r.SmsNumber == smsNumber);
    }

    public bool IsExistName(int branchId, string smsNumber, int updateId)
    {
        return Db.Vendors.Any(r => r.BranchId == branchId && r.SmsNumber == smsNumber && r.VendorId != updateId);
    }

    public bool IsNull(int id)
    {
        return !Db.Vendors.Any(r => r.VendorId == id);
    }

    public bool IsRelatedDataExist(int id)
    {
        return Db.Sellings.Any(m => m.VendorId == id);
    }

    public DataResult<VendorViewModel> List(int branchId, DataRequest request)
    {
        return Db.Vendors.Where(m => m.BranchId == branchId)
            .ProjectTo<VendorViewModel>(_mapper.ConfigurationProvider)
            .OrderBy(a => a.VendorName)
            .ToDataResult(request);
    }
}