using BismillahGraphicsPro.Data;

namespace BismillahGraphicsPro.Repository
{
    public interface IRegistrationRepository
    {
        UserType UserTypeByUserName(string userName);
    }
}