﻿using AutoMapper;
using BismillahGraphicsPro.Data;

namespace BismillahGraphicsPro.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            Registration = new RegistrationRepository(_db, mapper);
        }

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