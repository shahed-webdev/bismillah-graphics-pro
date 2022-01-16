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
            Branch = new BranchRepository(_db, mapper);
            MeasurementUnit = new MeasurementUnitRepository(_db, mapper);
            Registration = new RegistrationRepository(_db, mapper);

        }

        public IBranchRepository Branch { get; }
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