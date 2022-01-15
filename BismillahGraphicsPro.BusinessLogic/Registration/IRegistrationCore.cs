using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace BismillahGraphicsPro.BusinessLogic
{
    public interface IRegistrationCore
    {
        UserType UserTypeByUserName(string userName);
        Task<DbResponse<IdentityUser>> BranchSignUpAsync(BranchCreateModel model);
        List<BranchListModel> BranchList();
    }
}