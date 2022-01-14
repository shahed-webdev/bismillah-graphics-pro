using BismillahGraphicsPro.Data;

namespace BismillahGraphicsPro.BusinessLogic
{
    public interface IRegistrationCore
    {
        UserType UserTypeByUserName(string userName);
    }
}