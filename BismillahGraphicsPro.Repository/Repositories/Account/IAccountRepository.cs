using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public interface IAccountRepository
{
    DbResponse<AccountViewModel> Add(AccountAddModel model);
    DbResponse Edit(AccountViewModel model);
    DbResponse Delete(int id);
    DbResponse<AccountViewModel> Get(int id);
    bool IsExistName(int branchId, string name);
    bool IsExistName(int branchId, string name, int updateId);
    bool IsNull(int id);
    bool IsRelatedDataExist(int id);
    List<AccountViewModel> List(int branchId);
    List<DDL> ListDdl(int branchId);

}