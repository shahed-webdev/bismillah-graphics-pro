using AutoMapper;
using BismillahGraphicsPro.Data;
using System.Linq;
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
    }
}