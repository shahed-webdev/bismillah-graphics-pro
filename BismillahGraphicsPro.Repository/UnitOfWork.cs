using AutoMapper;
using BismillahGraphicsPro.Data;

namespace BismillahGraphicsPro.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            Account = new AccountRepository(_db, mapper);
            AccountLog = new AccountLogRepository(_db, mapper);
            Branch = new BranchRepository(_db, mapper);
            Expense = new ExpenseRepository(_db, mapper);
            ExpanseCategory = new ExpanseCategoryRepository(_db,mapper);
            MeasurementUnit = new MeasurementUnitRepository(_db, mapper);
            ProductCategory = new ProductCategoryRepository(_db, mapper);
            Registration = new RegistrationRepository(_db, mapper);

        }

        public IAccountRepository Account { get; }
        public IAccountLogRepository AccountLog { get; }
        public IBranchRepository Branch { get; }
        public IExpenseRepository Expense { get; }
        public IExpanseCategoryRepository ExpanseCategory { get; }
        public IProductCategoryRepository ProductCategory { get; }
        public IMeasurementUnitRepository MeasurementUnit { get; }
        public IRegistrationRepository Registration { get; }


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