using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace BismillahGraphicsPro.Repository;

public class BranchRepository : Repository, IBranchRepository
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public BranchRepository(ApplicationDbContext db, IMapper mapper, RoleManager<IdentityRole> roleManager) : base(db, mapper)
    {
        this._roleManager = roleManager;
    }

    public void AddWithRegistration(BranchCreateModel model)
    {
        var registration = _mapper.Map<Registration>(model);
        registration.Type = UserType.Admin;
        Db.Registrations.Add(registration);
        Db.SaveChanges();
    }

    public void AddSubAdmin(SubAdminCreateModel model, int branchId)
    {
        var registration = _mapper.Map<Registration>(model);
        registration.BranchId = branchId;
        registration.Type = UserType.SubAdmin;
        Db.Registrations.Add(registration);
        Db.SaveChanges();
    }

    public List<DDL> SubAdminDdl(int branchId)
    {
        return Db.Registrations.Where(r => r.BranchId == branchId && r.Type == UserType.SubAdmin)
            .Select(r =>
                new DDL
                {
                    value = r.RegistrationId.ToString(), 
                    label = r.Name + " (" + r.UserName + ")"
                }).ToList();
        ;
    }

    public List<BranchListModel> BranchList()
    {
        return Db.Branches
            .ProjectTo<BranchListModel>(_mapper.ConfigurationProvider)
            .ToList();
    }

    public List<SubAdminListModel> SubAdminList(int branchId)
    {
        return Db.Registrations.Where(r => r.BranchId == branchId && r.Type == UserType.SubAdmin)
            .ProjectTo<SubAdminListModel>(_mapper.ConfigurationProvider)
            .ToList();
    }

    public bool IsBranchActive(int branchId)
    {
        return Db.Branches.Find(branchId)!.IsActive;
    }

    public void Activate(int branchId)
    {
        var branch = Db.Branches.Find(branchId);
        if (branch == null) return;
        branch.IsActive = true;
        Db.Branches.Update(branch);
        Db.SaveChanges();
    }

    public void Deactivate(int branchId)
    {
        var branch = Db.Branches.Find(branchId);
        if (branch == null) return;
        branch.IsActive = false;
        Db.Branches.Update(branch);
        Db.SaveChanges();
    }

    public BranchDetailsModel? BranchDetails(int branchId)
    {
        return Db.Branches.Where(b => b.BranchId == branchId)
            .ProjectTo<BranchDetailsModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();
    }

    public ICollection<PageCategoryWithPageModel> SubAdminPageLinks(int registrationId)
    {

        var userDll = (from c in Db.PageLinkCategories
            select new PageCategoryWithPageModel
            {
                Category = c.Category,
                Links = (from l in Db.PageLinks
                    join r in _roleManager.Roles.ToList()
                        on l.RoleId equals r.Id
                    where l.LinkCategoryId == c.LinkCategoryId
                    select new PageLinkViewModel
                    {
                        LinkId = l.LinkId,
                        Title = l.Title,
                        RoleName = r.Name,
                        IsAssign = Db.PageLinkAssigns.Any(a => a.LinkId == l.LinkId && a.RegistrationId == registrationId)
                            
                    }).ToList()
            }).ToList();
        return userDll;
    }
}