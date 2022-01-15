﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class BranchRepository : Repository, IBranchRepository
{
    public BranchRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public void AddWithRegistration(BranchCreateModel model)
    {
        var registration = _mapper.Map<Registration>(model);
        registration.Type = UserType.Admin;
        Db.Registrations.Add(registration);
        Db.SaveChanges();
    }

    public List<BranchListModel> BranchList()
    {
        return Db.Branches
            .ProjectTo<BranchListModel>(_mapper.ConfigurationProvider)
            .ToList();
    }
}