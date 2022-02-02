using System;

namespace BismillahGraphicsPro.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Account { get; }
        IAccountLogRepository AccountLog { get; }
        IBranchRepository Branch { get; }
        IExpenseRepository Expense { get; }
        IExpenseCategoryRepository ExpenseCategory { get; }
        IProductCategoryRepository ProductCategory { get; }
        IProductRepository Product { get; }
        IPurchaseRepository Purchase { get; }
        IMeasurementUnitRepository MeasurementUnit { get; }
        IRegistrationRepository Registration { get; }
        ISellingRepository Selling { get; }
        ISupplierRepository Supplier { get; }
        ISmsRepository Sms { get; }
        IVendorRepository Vendor { get; }
        int SaveChanges();
    }
}