using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository ;

public interface IBranchRepository
{
    void AddWithRegistration(BranchCreateModel model);
    List<BranchListModel> BranchList();
    bool IsBranchActive(int branchId);
    void Activate(int branchId);
    void Deactivate(int branchId);
    BranchDetailsModel? BranchDetails(int branchId);
}