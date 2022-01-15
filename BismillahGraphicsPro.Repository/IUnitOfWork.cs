using System;

namespace BismillahGraphicsPro.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IBranchRepository Branch { get; }
        IRegistrationRepository Registration { get; }

        int SaveChanges();
    }
}