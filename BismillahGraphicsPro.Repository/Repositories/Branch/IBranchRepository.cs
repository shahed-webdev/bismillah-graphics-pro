using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository ;

public interface IBranchRepository
{
    void AddWithRegistration(BranchCreateModel model);
    List<BranchListModel> BranchList();
}