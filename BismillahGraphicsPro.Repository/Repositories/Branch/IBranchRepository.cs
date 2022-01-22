using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository ;

public interface IBranchRepository
{
    void AddWithRegistration(BranchCreateModel model);
    void AddSubAdmin(SubAdminCreateModel model, int branchId);
    List<SubAdminListModel> SubAdminList(int branchId);
    List<DDL> SubAdminDdl(int branchId);
    ICollection<PageCategoryWithPageModel> SubAdminPageLinks(int registrationId);
    void SubAdminAssignLinks(int registrationId, int[] linkIds);
    List<BranchListModel> BranchList();
    bool IsBranchActive(int branchId);
    void Activate(int branchId);
    void Deactivate(int branchId);
    BranchDetailsModel? BranchDetails(int branchId);
}