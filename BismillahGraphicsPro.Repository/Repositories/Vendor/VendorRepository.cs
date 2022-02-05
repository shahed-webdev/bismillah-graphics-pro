using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
using Microsoft.EntityFrameworkCore;

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

        Vendor.SmsNumber = model.SmsNumber;
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

    public Task<List<VendorViewModel>> SearchAsync(int branchId, string key)
    {
        return Db.Vendors.Where(v => v.BranchId == branchId && v.VendorCompanyName.Contains(key) || v.VendorPhone.Contains(key) || v.VendorCompanyName.Contains(key))
            .ProjectTo<VendorViewModel>(_mapper.ConfigurationProvider)
            .OrderBy(a => a.VendorName)
            .Take(5)
            .ToListAsync();
    }

    public void UpdatePaidDue(int id)
    {
        var vendor = Db.Vendors.Find(id);
        if (vendor == null) return;

        var obj = Db.Sellings.Where(s => s.VendorId == vendor.VendorId)
            .GroupBy(s => s.VendorId).Select(s =>
                new
                {
                    TotalAmount = s.Sum(c => c.SellingTotalPrice),
                    TotalDiscount = s.Sum(c => c.SellingDiscountAmount),
                    VendorPaid = s.Sum(c => c.SellingPaidAmount)
                }).FirstOrDefault();

        if (obj != null)
        {
            vendor.TotalAmount = Math.Round(obj.TotalAmount, 2);
            vendor.TotalDiscount = Math.Round(obj.TotalDiscount, 2);
            vendor.VendorPaid = Math.Round(obj.VendorPaid, 2);
        }
        else
        {
            vendor.TotalAmount = 0;
            vendor.TotalDiscount = 0;
            vendor.VendorPaid = 0;
        }


        Db.Vendors.Update(vendor);
        Db.SaveChanges();
    }

    public DbResponse<VendorViewModel> GetReport(int id, DateTime? sDate, DateTime? eDate)
    {
        var startDate = sDate ?? new DateTime(1000, 1, 1);
        var endDate = eDate ?? new DateTime(3000, 1, 1);

        var vendor = Db.Vendors
            .Include(v =>
                v.Sellings.Where(p => p.SellingDate <= endDate && p.SellingDate >= startDate))
            .FirstOrDefault(v => v.VendorId == id);

        if (vendor == null) return new DbResponse<VendorViewModel>(false, $"data not found");

        var vendorView = _mapper.Map<VendorViewModel>(vendor);


        vendorView.TotalAmount = Math.Round(vendor.Sellings.Sum(s => s.SellingTotalPrice), 2);
        vendorView.VendorDue = Math.Round(vendor.Sellings.Sum(s => s.SellingDueAmount), 2);
        vendorView.VendorPaid = Math.Round(vendor.Sellings.Sum(s => s.SellingPaidAmount), 2);
        vendorView.TotalDiscount = Math.Round(vendor.Sellings.Sum(s => s.SellingDiscountAmount), 2);

        return new DbResponse<VendorViewModel>(true, $"{vendorView.VendorCompanyName} get successfully", vendorView);
    }

}