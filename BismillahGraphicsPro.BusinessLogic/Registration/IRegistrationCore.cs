﻿using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace BismillahGraphicsPro.BusinessLogic
{
    public interface IRegistrationCore
    {
        UserType UserTypeByUserName(string userName);
        bool IsBranchActive(string userName);
        DbResponse ToggleBranchActivation(int branchId);
        Task<DbResponse<BranchDetailsModel>> GetBranchAsync(string userName);
        Task<DbResponse<BranchDetailsModel>> GetBranchAsync(int branchId);
        Task<DbResponse<RegistrationEditModel>> GetUserAsync(string userName);
        Task<DbResponse> EditAsync(string userName, RegistrationEditModel model);
        Task<DbResponse<IdentityUser>> BranchSignUpAsync(BranchCreateModel model);
        List<BranchListModel> BranchList();
        Task<DbResponse> EditBranchAsync(BranchEditModel model);
        Task PasswordChangedAsync(string userName, string password);
        Task<List<SideNavbarModel>> GetSideNavbarAsync(string userName);
        Task<DbResponse> ResetAsync(string userName);
        //-----------Sub-Admin--------------------------
        Task<DbResponse<IdentityUser>> SubAdminSignUpAsync(string userName, SubAdminCreateModel model);
        List<SubAdminListModel> SubAdminList(string userName);
        List<DDL> SubAdminDdl(string userName);
        List<PageCategoryWithPageModel> SubAdminPageLinks(int registrationId);
        //Task<List<PageCategoryWithPageModel>> SubAdminPageLinksAsync(string userName);
        Task<DbResponse> SubAdminAssignLinks(int registrationId, List<PageLinkAssignModel> links);
        DbResponse SubAdminToggleActivation(int registrationId);
        bool IsSubAdminActive(string userName);
    }
}