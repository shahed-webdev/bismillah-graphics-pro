using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository ;

public interface IBranchRepository
{
    void AddWithRegistration(BranchCreateModel model);
    List<BranchListModel> BranchList();
    bool IsBranchActive(int branchId);
    void Activate(int branchId);
    void Deactivate(int branchId);
    DbResponse<BranchDetailsModel> Get(int branchId);
    //--------------Sub-Admin--------------------------------
    void AddSubAdmin(SubAdminCreateModel model, int branchId);
    DbResponse<SubAdminListModel> SubAdminGet(int registrationId);
    List<SubAdminListModel> SubAdminList(int branchId);
    List<DDL> SubAdminDdl(int branchId);
    List<PageCategoryWithPageModel> SubAdminPageLinks(int registrationId);
    DbResponse<string> SubAdminAssignLinks(int registrationId, List<PageLinkAssignModel> links);
    bool IsSubAdminActive(int registrationId);
    void SubAdminActivate(int registrationId);
    void SubAdminDeactivate(int registrationId);
}