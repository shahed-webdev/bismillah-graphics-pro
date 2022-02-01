using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

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

    void BalanceAdd(int id, decimal amount);
    void BalanceSubtract(int id, decimal amount);

    DbResponse<AccountDepositViewModel> Deposit(AccountDepositViewModel model);
    DataResult<AccountDepositViewModel> DepositList(DataRequest request);

    DbResponse<AccountWithdrawViewModel> Withdraw(AccountWithdrawViewModel model);
    DataResult<AccountWithdrawViewModel> WithdrawList(DataRequest request);

    BalanceSheetReportModel BalanceSheet(int branchId, int accountId, DateTime? sDate, DateTime? eDate);
    DailyCashModel DailyCashReport(int branchId, DateTime? date);
}