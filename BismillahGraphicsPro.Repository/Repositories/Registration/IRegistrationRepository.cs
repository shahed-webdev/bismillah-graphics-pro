using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository
{
    public interface IRegistrationRepository
    {
        int BranchIdByUserName(string userName);
        int RegistrationIdByUserName(string userName);
        UserType UserTypeByUserName(string userName);
        void PasswordChanged(string userName, string password);
        DbResponse Edit(string userName, RegistrationEditModel model);
    }
}