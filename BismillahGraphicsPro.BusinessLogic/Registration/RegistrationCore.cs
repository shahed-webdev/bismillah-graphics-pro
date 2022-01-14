using AutoMapper;
using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.Repository;

namespace BismillahGraphicsPro.BusinessLogic.Registration
{
    public class RegistrationCore : Core, IRegistrationCore
    {
        public RegistrationCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }

        public UserType UserTypeByUserName(string userName)
        {
            return _db.Registration.UserTypeByUserName(userName);
        }
    }
}