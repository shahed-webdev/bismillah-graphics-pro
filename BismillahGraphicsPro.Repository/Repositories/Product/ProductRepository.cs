using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class ProductRepository:Repository, IProductRepository
{
    public ProductRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }
    public DbResponse<ProductViewModel> Add(ProductAddModel model)
    {
        var Product = _mapper.Map<Product>(model);
        Db.Products.Add(Product);
        Db.SaveChanges();
        var ProductViewModel = _mapper.Map<ProductViewModel>(Product);

        return new DbResponse<ProductViewModel>(true, $"{model.ProductName} Created Successfully", ProductViewModel);

    }

    public DbResponse Edit(ProductViewModel model)
    {
        var Product = Db.Products.Find(model.ProductId);
        Product!.ProductName = model.ProductName;
        Db.Products.Update(Product);
        Db.SaveChanges();
        return new DbResponse(true, $"{Product.ProductName} Updated Successfully");

    }

    public DbResponse Delete(int id)
    {
        var Product = Db.Products.Find(id);
        Db.Products.Remove(Product!);
        Db.SaveChanges();
        return new DbResponse(true, $"{Product.ProductName} Deleted Successfully");

    }

    public DbResponse<ProductViewModel> Get(int id)
    {
        var Product = Db.Products.Where(r => r.ProductId == id)
            .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();
        return new DbResponse<ProductViewModel>(true, $"{Product!.ProductName} Get Successfully", Product);

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

    public List<ProductViewModel> List(int branchId)
    {
        return Db.Products.Where(m => m.BranchId == branchId)
            .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider)
            .OrderBy(a => a.ProductName)
            .ToList();
    }
}