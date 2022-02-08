using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class ProductCategoryRepository : Repository, IProductCategoryRepository
{
    public ProductCategoryRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public DbResponse<ProductCategoryCrudModel> Add(ProductCategoryCrudModel model)
    {
        var ProductCategory = _mapper.Map<ProductCategory>(model);
        Db.ProductCategories.Add(ProductCategory);
        Db.SaveChanges();
        model.ProductCategoryId = ProductCategory.ProductCategoryId;

        return new DbResponse<ProductCategoryCrudModel>(true, $"{model.ProductCategoryName} Added Successfully", model);
    }

    public DbResponse Edit(ProductCategoryCrudModel model)
    {
        var ProductCategory = Db.ProductCategories.Find(model.ProductCategoryId);
        ProductCategory!.ProductCategoryName = model.ProductCategoryName;
        Db.ProductCategories.Update(ProductCategory);
        Db.SaveChanges();
        return new DbResponse(true, $"{ProductCategory.ProductCategoryName} Updated Successfully");
    }

    public DbResponse Delete(int id)
    {
        var ProductCategory = Db.ProductCategories.Find(id);
        if (ProductCategory == null) return new DbResponse(false, "data Not Found");

        Db.ProductCategories.Remove(ProductCategory);
        Db.SaveChanges();
        return new DbResponse(true, $"{ProductCategory.ProductCategoryName} Deleted Successfully");
    }

    public DbResponse<ProductCategoryCrudModel> Get(int id)
    {
        var measurementUnit = Db.ProductCategories.Where(r => r.ProductCategoryId == id)
            .ProjectTo<ProductCategoryCrudModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();
        return new DbResponse<ProductCategoryCrudModel>(true, $"{measurementUnit!.ProductCategoryName} Get Successfully",
            measurementUnit);
    }

    public bool IsExistName(int branchId, string name)
    {
        return Db.ProductCategories.Any(r => r.BranchId == branchId && r.ProductCategoryName == name);
    }

    public bool IsExistName(int branchId, string name, int updateId)
    {
        return Db.ProductCategories.Any(r =>
            r.BranchId == branchId && r.ProductCategoryName == name && r.ProductCategoryId != updateId);
    }

    public bool IsNull(int id)
    {
        return !Db.ProductCategories.Any(r => r.ProductCategoryId == id);
    }

    public bool IsRelatedDataExist(int id)
    {
        return Db.Products.Any(m => m.ProductCategoryId == id);
    }

    public List<ProductCategoryCrudModel> List(int branchId)
    {
        return Db.ProductCategories.Where(m => m.BranchId == branchId)
            .ProjectTo<ProductCategoryCrudModel>(_mapper.ConfigurationProvider)
            .OrderBy(a => a.ProductCategoryName)
            .ToList();
    }

    public List<DDL> ListDdl(int branchId)
    {
        return Db.ProductCategories.Where(p=> p.BranchId == branchId)
            .OrderBy(a => a.ProductCategoryName)
            .Select(m => new DDL
            {
                value = m.ProductCategoryId.ToString(),
                label = m.ProductCategoryName
            }).ToList();
    }
}