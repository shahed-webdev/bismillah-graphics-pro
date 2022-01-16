using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.BusinessLogic;

public interface IAccountCore
{
    DbResponse<AccountViewModel> Add(string accountName, string userName);
    DbResponse Edit(AccountViewModel model);
    DbResponse Delete(int id);
    DbResponse<AccountViewModel> Get(int id);
    List<AccountViewModel> List(string userName);
    List<DDL> ListDdl(string userName);
}