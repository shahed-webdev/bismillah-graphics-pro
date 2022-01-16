using BismillahGraphicsPro.Data;

namespace BismillahGraphicsPro.Repository
{
    public interface IRegistrationRepository
    {
        int BranchIdByUserName(string userName);
        UserType UserTypeByUserName(string userName);
    }
}