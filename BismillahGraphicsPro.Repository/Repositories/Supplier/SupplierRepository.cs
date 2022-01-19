using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public class SupplierRepository : Repository, ISupplierRepository
{
    public SupplierRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public DbResponse<SupplierViewModel> Add(int branchId, SupplierAddModel model)
    {
        var supplier = _mapper.Map<Supplier>(model);
        supplier.BranchId = branchId;
        Db.Suppliers.Add(supplier);
        Db.SaveChanges();

        var supplierViewModel = _mapper.Map<SupplierViewModel>(supplier);

        return new DbResponse<SupplierViewModel>(true, $"{supplierViewModel.SupplierName} Added Successfully",
            supplierViewModel);
    }

    public DbResponse Edit(SupplierEditModel model)
    {
        var supplier = Db.Suppliers.Find(model.SupplierId);
        if (supplier == null) return new DbResponse(false, "data Not Found");

        supplier.SmsNumber = model.SupplierName;
        supplier.SupplierName = model.SmsNumber;
        supplier.SupplierCompanyName = model.SupplierCompanyName;
        supplier.SupplierAddress = model.SupplierAddress;
        supplier.SupplierPhone = model.SupplierPhone;
        Db.Suppliers.Update(supplier);
        Db.SaveChanges();
        return new DbResponse(true, $"{supplier.SupplierName} Updated Successfully");
    }

    public DbResponse Delete(int id)
    {
        var supplier = Db.Suppliers.Find(id);
        if (supplier == null) return new DbResponse(false, "data Not Found");

        Db.Suppliers.Remove(supplier);
        Db.SaveChanges();
        return new DbResponse(true, $"{supplier.SupplierName} Deleted Successfully");
    }

    public DbResponse<SupplierViewModel> Get(int id)
    {
        var measurementUnit = Db.Suppliers.Where(r => r.SupplierId == id)
            .ProjectTo<SupplierViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();

        return measurementUnit == null
            ? new DbResponse<SupplierViewModel>(false, "data Not Found")
            : new DbResponse<SupplierViewModel>(true, $"{measurementUnit!.SupplierName} Get Successfully",
                measurementUnit);
    }

    public bool IsExistName(int branchId, string smsNumber)
    {
        return Db.Suppliers.Any(r => r.BranchId == branchId && r.SmsNumber == smsNumber);
    }

    public bool IsExistName(int branchId, string smsNumber, int updateId)
    {
        return Db.Suppliers.Any(r => r.BranchId == branchId && r.SmsNumber == smsNumber && r.SupplierId != updateId);
    }

    public bool IsNull(int id)
    {
        return !Db.Suppliers.Any(r => r.SupplierId == id);
    }

    public bool IsRelatedDataExist(int id)
    {
        return Db.Purchases.Any(m => m.SupplierId == id);
    }

    public DataResult<SupplierViewModel> List(int branchId, DataRequest request)
    {
        return Db.Suppliers.Where(m => m.BranchId == branchId)
            .ProjectTo<SupplierViewModel>(_mapper.ConfigurationProvider)
            .OrderBy(a => a.SupplierName)
            .ToDataResult(request);
    }
}