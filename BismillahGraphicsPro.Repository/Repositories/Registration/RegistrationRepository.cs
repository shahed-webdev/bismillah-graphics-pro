using AutoMapper;
using BismillahGraphicsPro.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository
{
    public class RegistrationRepository : Repository, IRegistrationRepository
    {
        public RegistrationRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public int BranchIdByUserName(string userName)
        {
            return Db.Registrations.FirstOrDefault(r => r.UserName == userName)?.BranchId ?? 0;
        }

        public int RegistrationIdByUserName(string userName)
        {
            return Db.Registrations.FirstOrDefault(r => r.UserName == userName)?.RegistrationId ?? 0;
        }

        public UserType UserTypeByUserName(string userName)
        {
            return Db.Registrations.FirstOrDefault(r => r.UserName == userName)!.Type;
        }

        public void PasswordChanged(string userName, string password)
        {
            var registration = Db.Registrations.FirstOrDefault(r => r.UserName == userName);

            if (registration == null) return;
            registration.Ps = password;
            Db.Registrations.Update(registration);
            Db.SaveChanges();
        }

        public DbResponse Edit(string userName, RegistrationEditModel model)
        {
            var registration = Db.Registrations.FirstOrDefault(r => r.UserName == userName);
            if (registration == null) return new DbResponse(false, "data Not Found");

            registration.Name = model.Name;
            registration.Address = model.Address;
            registration.Phone = model.Phone;
            registration.Email = model.Email;
            registration.Image = model.Image;
            Db.Registrations.Update(registration);
            Db.SaveChanges();
            return new DbResponse(true, $"{registration.UserName} Updated Successfully");
        }

        public DbResponse<RegistrationEditModel> Get(string userName)
        {
            var registration = Db.Registrations.Where(r => r.UserName == userName)
                .ProjectTo<RegistrationEditModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();

            return registration == null
                ? new DbResponse<RegistrationEditModel>(false, "data Not Found")
                : new DbResponse<RegistrationEditModel>(true, $"{registration!.Name} Get Successfully",
                    registration);
        }

        public List<SideNavbarModel> GetSideNavbar(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return new List<SideNavbarModel>();

            var registration = Db.Registrations.FirstOrDefault(r => r.UserName == userName);
            if (registration == null) return new List<SideNavbarModel>();

            if (registration.Type == UserType.Admin)
            {
                var menu = (from p in Db.PageLinkCategories
                    orderby p.Sn
                    select new SideNavbarModel
                    {
                        LinkCategoryId = p.LinkCategoryId,
                        Category = p.Category,
                        IconClass = p.IconClass,
                        Sn = p.Sn,
                        Links = p.PageLinks.Select(l => new SideNavbarLinkModel
                        {
                            LinkId = l.LinkId,
                            Sn = l.Sn,
                            Action = l.Action,
                            Controller = l.Controller,
                            IconClass = l.IconClass,
                            Title = l.Title
                        }).OrderBy(l => l.Sn).ToList()
                    }).ToList();
                return menu;
            }
            else
            {
                var menu = (from p in Db.PageLinkAssigns
                    join c in Db.PageLinkCategories
                        on p.Link.LinkCategory.LinkCategoryId equals c.LinkCategoryId
                    where p.RegistrationId == registration.RegistrationId
                    orderby p.Link.LinkCategory.Sn
                    select new SideNavbarModel
                    {
                        LinkCategoryId = c.LinkCategoryId,
                        Category = c.Category,
                        IconClass = c.IconClass,
                        Sn = c.Sn
                    }).Distinct().ToList();

                foreach (var item in menu)
                {
                    item.Links = Db.PageLinkAssigns
                        .Where(l => l.Link.LinkCategoryId == item.LinkCategoryId &&
                                    l.RegistrationId == registration.RegistrationId).Select(l => new SideNavbarLinkModel
                        {
                            LinkId = l.Link.LinkId,
                            Sn = l.Link.Sn,
                            Action = l.Link.Action,
                            Controller = l.Link.Controller,
                            IconClass = l.Link.IconClass,
                            Title = l.Link.Title
                        }).ToList();
                }

                return menu;
            }
        }
    }
}