using AutoMapper;
using BismillahGraphicsPro.Data;
using Microsoft.AspNetCore.Identity;

namespace BismillahGraphicsPro.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            Account = new AccountRepository(_db, mapper);
            AccountLog = new AccountLogRepository(_db, mapper);
            Branch = new BranchRepository(_db, mapper, roleManager);
            Expense = new ExpenseRepository(_db, mapper);
            ExpenseCategory = new ExpenseCategoryRepository(_db, mapper);
            MeasurementUnit = new MeasurementUnitRepository(_db, mapper);
            Product = new ProductRepository(_db, mapper);
            ProductCategory = new ProductCategoryRepository(_db, mapper);
            Purchase = new PurchaseRepository(_db,mapper);
            Registration = new RegistrationRepository(_db, mapper);
            Selling = new SellingRepository(_db, mapper);
            Supplier = new SupplierRepository(_db, mapper);
            Sms = new SmsRepository(_db, mapper);
            Vendor = new VendorRepository(_db, mapper);
        }

        public IAccountRepository Account { get; }
        public IAccountLogRepository AccountLog { get; }
        public IBranchRepository Branch { get; }
        public IExpenseRepository Expense { get; }
        public IExpenseCategoryRepository ExpenseCategory { get; }
        public IProductRepository Product { get; }
        public IPurchaseRepository Purchase { get; }
        public IProductCategoryRepository ProductCategory { get; }
        public IMeasurementUnitRepository MeasurementUnit { get; }
        public IRegistrationRepository Registration { get; }
        public ISellingRepository Selling { get; }
        public ISupplierRepository Supplier { get; }
        public ISmsRepository Sms { get; }
        public IVendorRepository Vendor { get; }


        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}