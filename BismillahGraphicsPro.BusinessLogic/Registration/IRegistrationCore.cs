using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace BismillahGraphicsPro.BusinessLogic
{
    public interface IRegistrationCore
    {
        UserType UserTypeByUserName(string userName);
        bool IsBranchActive(string userName);
        DbResponse ToggleBranchActivation(int branchId);
        Task<DbResponse<IdentityUser>> BranchSignUpAsync(BranchCreateModel model);
        List<BranchListModel> BranchList();
    }
}