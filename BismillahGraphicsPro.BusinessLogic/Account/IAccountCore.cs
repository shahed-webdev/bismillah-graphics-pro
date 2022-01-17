using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public interface IAccountCore
{
    DbResponse<AccountViewModel> Add(string accountName, string userName);
    DbResponse Edit(AccountViewModel model);
    DbResponse Delete(int id);
    DbResponse<AccountViewModel> Get(int id);
    List<AccountViewModel> List(string userName);
    List<DDL> ListDdl(string userName);
    DbResponse<AccountDepositViewModel> Deposit(string userName,AccountDepositViewModel model);
    DataResult<AccountDepositViewModel> DepositList(DataRequest request);

    DbResponse<AccountWithdrawViewModel> Withdraw(string userName,AccountWithdrawViewModel model);
    DataResult<AccountWithdrawViewModel> WithdrawList(DataRequest request);
}