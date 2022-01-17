using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class ExpanseCategoryRepository:Repository, IExpanseCategoryRepository
{
    public ExpanseCategoryRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public DbResponse<ExpanseCategoryCrudModel> Add(ExpanseCategoryCrudModel model)
    {
        var expanseCategory = _mapper.Map<ExpanseCategory>(model);
        Db.ExpanseCategories.Add(expanseCategory);
        Db.SaveChanges();
        model.ExpanseCategoryId = expanseCategory.ExpanseCategoryId;

        return new DbResponse<ExpanseCategoryCrudModel>(true, $"{model.CategoryName} Added Successfully", model);
    }

    public DbResponse Edit(ExpanseCategoryCrudModel model)
    {
        var expanseCategory = Db.ExpanseCategories.Find(model.ExpanseCategoryId);
        expanseCategory!.CategoryName = model.CategoryName;
        Db.ExpanseCategories.Update(expanseCategory);
        Db.SaveChanges();
        return new DbResponse(true, $"{expanseCategory.CategoryName} Updated Successfully");
    }

    public DbResponse Delete(int id)
    {
        var expanseCategory = Db.ExpanseCategories.Find(id);
        Db.ExpanseCategories.Remove(expanseCategory!);
        Db.SaveChanges();
        return new DbResponse(true, $"{expanseCategory.CategoryName} Deleted Successfully");
    }

    public DbResponse<ExpanseCategoryCrudModel> Get(int id)
    {
        var measurementUnit = Db.ExpanseCategories.Where(r => r.ExpanseCategoryId == id)
            .ProjectTo<ExpanseCategoryCrudModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();
        return new DbResponse<ExpanseCategoryCrudModel>(true, $"{measurementUnit!.CategoryName} Get Successfully", measurementUnit);
    }

    public bool IsExistName(int branchId, string name)
    {
        return Db.ExpanseCategories.Any(r => r.BranchId == branchId && r.CategoryName == name);
    }

    public bool IsExistName(int branchId, string name, int updateId)
    {
        return Db.ExpanseCategories.Any(r => r.BranchId == branchId && r.CategoryName == name && r.ExpanseCategoryId != updateId);
    }

    public bool IsNull(int id)
    {
        return !Db.ExpanseCategories.Any(r => r.ExpanseCategoryId == id);
    }

    public bool IsRelatedDataExist(int id)
    {
        return Db.Expanses.Any(m => m.ExpanseCategoryId == id);
    }

    public List<ExpanseCategoryCrudModel> List(int branchId)
    {
        return Db.ExpanseCategories.Where(m => m.BranchId == branchId)
            .ProjectTo<ExpanseCategoryCrudModel>(_mapper.ConfigurationProvider)
            .OrderBy(a => a.CategoryName)
            .ToList();
    }

    public List<DDL> ListDdl(int branchId)
    {
        return Db.ExpanseCategories
            .OrderBy(a => a.CategoryName)
            .Select(m => new DDL
            {
                value = m.ExpanseCategoryId.ToString(),
                label = m.CategoryName
            }).ToList();
    }
}