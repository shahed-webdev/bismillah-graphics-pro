using AutoMapper;
using BismillahGraphicsPro.Data;
using System.Linq;

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
    }
}