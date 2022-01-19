using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
using Microsoft.EntityFrameworkCore;

namespace BismillahGraphicsPro.Repository;

public class ProductRepository : Repository, IProductRepository
{
    public ProductRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public DbResponse<ProductViewModel> Add(ProductAddModel model)
    {
        var product = _mapper.Map<Product>(model);
        Db.Products.Add(product);
        Db.SaveChanges();
        var productViewModel = _mapper.Map<ProductViewModel>(product);

        return new DbResponse<ProductViewModel>(true, $"{model.ProductName} Created Successfully", productViewModel);
    }

    public DbResponse Edit(ProductEditModel model)
    {
        var product = Db.Products.Find(model.ProductId);
        if (product == null)
            return new DbResponse(false, "Data not found");

        product.ProductName = model.ProductName;
        product.ProductCategoryId = model.ProductCategoryId;
        product.ProductPrice = model.ProductPrice;
        Db.Products.Update(product);
        Db.SaveChanges();
        return new DbResponse(true, $"{product.ProductName} Updated Successfully");
    }

    public DbResponse Delete(int id)
    {
        var product = Db.Products.Find(id);
        if (product == null)
            return new DbResponse(false, "Data not found");
        Db.Products.Remove(product);
        Db.SaveChanges();
        return new DbResponse(true, $"{product.ProductName} Deleted Successfully");
    }

    public DbResponse<ProductViewModel> Get(int id)
    {
        var product = Db.Products.Where(r => r.ProductId == id)
            .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();
        return product == null
            ? new DbResponse<ProductViewModel>(false, "Data not found")
            : new DbResponse<ProductViewModel>(true, $"{product!.ProductName} Get Successfully", product);
    }

    public bool IsExistName(int branchId, string name)
    {
        return Db.Products.Any(r => r.BranchId == branchId && r.ProductName == name);
    }

    public bool IsExistName(int branchId, string name, int updateId)
    {
        return Db.Products.Any(r => r.BranchId == branchId && r.ProductName == name && r.ProductId != updateId);
    }

    public bool IsNull(int id)
    {
        return !Db.Products.Any(r => r.ProductId == id);
    }

    public bool IsRelatedDataExist(int id)
    {
        return Db.PurchaseLists.Any(m => m.ProductId == id)
               || Db.SellingLists.Any(m => m.ProductId == id);
    }

    public DataResult<ProductViewModel> List(int branchId, DataRequest request)
    {
        return Db.Products.Where(m => m.BranchId == branchId)
            .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider)
            .OrderBy(a => a.ProductName)
            .ToDataResult(request);
    }

    public Task<List<ProductViewModel>> SearchAsync(int branchId, string key)
    {
        return Db.Products.Where(p =>p.BranchId == branchId && p.ProductName.Contains(key))
            .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider)
            .OrderBy(a => a.ProductName)
            .Take(5)
            .ToListAsync();
    }
}