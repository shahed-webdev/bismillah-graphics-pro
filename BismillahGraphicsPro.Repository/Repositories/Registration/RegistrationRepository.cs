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
        public UserType UserTypeByUserName(string userName)
        {
            return Db.Registrations.FirstOrDefault(r => r.UserName == userName).Type;
        }
    }
}