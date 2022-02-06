using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class MeasurementUnitRepository: Repository, IMeasurementUnitRepository
{
    public MeasurementUnitRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public DbResponse<MeasurementUnitCrudModel> Add(MeasurementUnitCrudModel model)
    {
        var measurementUnit = _mapper.Map<MeasurementUnit>(model); 
        Db.MeasurementUnits.Add(measurementUnit);
        Db.SaveChanges();
        model.MeasurementUnitId = measurementUnit.MeasurementUnitId;

        return new DbResponse<MeasurementUnitCrudModel>(true, $"{model.MeasurementUnitName} Added Successfully", model);
    }

    public DbResponse Edit(MeasurementUnitCrudModel model)
    {
        var measurementUnit = Db.MeasurementUnits.Find(model.MeasurementUnitId);
        measurementUnit!.MeasurementUnitName = model.MeasurementUnitName;
        Db.MeasurementUnits.Update(measurementUnit);
        Db.SaveChanges();
        return new DbResponse(true, $"{measurementUnit.MeasurementUnitName} Updated Successfully");
    }

    public DbResponse Delete(int id)
    {
        var measurementUnit = Db.MeasurementUnits.Find(id);
        Db.MeasurementUnits.Remove(measurementUnit!);
        Db.SaveChanges();
        return new DbResponse(true, $"{measurementUnit.MeasurementUnitName} Deleted Successfully");
    }

    public DbResponse<MeasurementUnitCrudModel> Get(int id)
    {
        var measurementUnit = Db.MeasurementUnits.Where(r => r.MeasurementUnitId == id)
            .ProjectTo<MeasurementUnitCrudModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();
        return new DbResponse<MeasurementUnitCrudModel>(true, $"{measurementUnit!.MeasurementUnitName} Get Successfully", measurementUnit);
    }

    public bool IsExistName(int branchId, string name)
    {
        return Db.MeasurementUnits.Any(r => r.BranchId == branchId && r.MeasurementUnitName == name);
    }

    public bool IsExistName(int branchId, string name, int updateId)
    {
        return Db.MeasurementUnits.Any(r => r.BranchId == branchId && r.MeasurementUnitName == name && r.MeasurementUnitId != updateId);
    }

    public bool IsNull(int id)
    {
        return !Db.MeasurementUnits.Any(r => r.MeasurementUnitId == id);
    }

    public bool IsRelatedDataExist(int id)
    {
        return Db.PurchaseLists.Any(m => m.MeasurementUnitId == id)
               || Db.SellingLists.Any(m => m.MeasurementUnitId == id);
    }

    public List<MeasurementUnitCrudModel> List(int branchId)
    {
        return Db.MeasurementUnits.Where(m=> m.BranchId== branchId)
            .ProjectTo<MeasurementUnitCrudModel>(_mapper.ConfigurationProvider)
            .OrderBy(a => a.MeasurementUnitName)
            .ToList();
    }

    public List<DDL> ListDdl(int branchId)
    {
        return Db.MeasurementUnits.Where(m=> m.BranchId == branchId)
            .OrderBy(a => a.MeasurementUnitName)
            .Select(m => new DDL
            {
                value = m.MeasurementUnitId.ToString(),
                label = m.MeasurementUnitName
            }).ToList();
    }
}