using System;

namespace BismillahGraphicsPro.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Account { get; }
        IBranchRepository Branch { get; }
        IMeasurementUnitRepository MeasurementUnit { get; }
        IRegistrationRepository Registration { get; }

        int SaveChanges();
    }
}