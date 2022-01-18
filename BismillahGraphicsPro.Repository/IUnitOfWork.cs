using System;

namespace BismillahGraphicsPro.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Account { get; }
        IAccountLogRepository AccountLog { get; }
        IBranchRepository Branch { get; }
        IExpenseRepository Expense { get; }
        IExpanseCategoryRepository ExpanseCategory { get; }
        IProductCategoryRepository ProductCategory { get; }
        IMeasurementUnitRepository MeasurementUnit { get; }
        IRegistrationRepository Registration { get; }

        int SaveChanges();
    }
}