using AutoMapper;
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

    public bool IsBranchActive(int branchId)
    {
        return Db.Branches.Find(branchId).IsActive ?? false;
    }

    public void Activate(int branchId)
    {
        var branch = Db.Branches.Find(branchId);
        if (branch == null) return;
        branch.IsActive = true;
        Db.Branches.Update(branch);
    }

    public void Deactivate(int branchId)
    {
        var branch = Db.Branches.Find(branchId);
        if (branch == null) return;
        branch.IsActive = false;
        Db.Branches.Update(branch); 
    }

    public BranchDetailsModel? BranchDetails(int branchId)
    {
        return Db.Branches.Where(b=> b.BranchId == branchId)
            .ProjectTo<BranchDetailsModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();
    }
}