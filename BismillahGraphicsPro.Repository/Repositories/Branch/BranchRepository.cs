using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BismillahGraphicsPro.Repository;

public class BranchRepository : Repository, IBranchRepository
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public BranchRepository(ApplicationDbContext db, IMapper mapper, RoleManager<IdentityRole> roleManager) : base(db, mapper)
    {
        _roleManager = roleManager;
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

    public DbResponse<SubAdminListModel> SubAdminGet(int registrationId)
    {
        var registration = Db.Registrations.Where(b => b.RegistrationId == registrationId)
            .ProjectTo<SubAdminListModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();

        return registration == null
            ? new DbResponse<SubAdminListModel>(false, "data Not Found")
            : new DbResponse<SubAdminListModel>(true, $"{registration!.UserName} Get Successfully",
                registration);
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

    public DbResponse<string> SubAdminAssignLinks(int registrationId, List<PageLinkAssignModel> links)
    {
        var pAssigns = links.Select(l => new PageLinkAssign
        {
            LinkId = l.LinkId,
        }).ToList();
        var registration = Db.Registrations
            .Include(r=> r.PageLinkAssigns)
            .FirstOrDefault(p => p.RegistrationId == registrationId);
        if (registration == null) return new DbResponse<string>(false, "Data not found");
            registration.PageLinkAssigns = pAssigns;

            Db.Registrations.Update(registration);
            Db.SaveChanges();
        return new DbResponse<string>(true, "Assigned successfully", registration.UserName);
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

    public DbResponse<BranchDetailsModel> Get(int branchId)
    {
        var branch = Db.Branches.Where(b => b.BranchId == branchId)
            .ProjectTo<BranchDetailsModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();

        return branch == null
            ? new DbResponse<BranchDetailsModel>(false, "data Not Found")
            : new DbResponse<BranchDetailsModel>(true, $"{branch!.BranchName} Get Successfully",
                branch);
    }

    public List<PageCategoryWithPageModel> SubAdminPageLinks(int registrationId)
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


    public bool IsSubAdminActive(int registrationId)
    {
        return Db.Registrations.Find(registrationId)!.Validation;
    }

    public void SubAdminActivate(int registrationId)
    {
        var registration = Db.Registrations.Find(registrationId);
        if (registration == null) return;
        registration.Validation = true;
        Db.Registrations.Update(registration);
        Db.SaveChanges();
    }

    public void SubAdminDeactivate(int registrationId)
    {
        var registration = Db.Registrations.Find(registrationId);
        if (registration == null) return;
        registration.Validation = false;
        Db.Registrations.Update(registration);
        Db.SaveChanges();
    }
}