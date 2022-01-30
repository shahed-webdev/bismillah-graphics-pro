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
    Task<DbResponse<DailyCashModel>> DailyCashReportAsync(string userName, DateTime? date);
    //-------Log
    Task<BalanceSheetReportModel> BalanceSheetAsync(string userName, int accountId, DateTime? sDate, DateTime? eDate);
    Task<DataResult<AccountLogViewModel>> LogListAsync(string userName, DataRequest request);
    //-------Deposit & Withdraw
    DbResponse<AccountDepositViewModel> Deposit(string userName,AccountDepositViewModel model);
    DataResult<AccountDepositViewModel> DepositList(DataRequest request);

    DbResponse<AccountWithdrawViewModel> Withdraw(string userName,AccountWithdrawViewModel model);
    DataResult<AccountWithdrawViewModel> WithdrawList(DataRequest request);
}