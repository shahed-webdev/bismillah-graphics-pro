using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public class AccountCore: Core,IAccountCore
{
    public AccountCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
    {
    }
    public DbResponse<AccountViewModel> Add(string accountName, string userName)
    {
        try
        {

            if (string.IsNullOrEmpty(accountName))
                return new DbResponse<AccountViewModel>(false, "Invalid Data");

            var model = new AccountAddModel()
            {
                BranchId = _db.Registration.BranchIdByUserName(userName),
                AccountName = accountName
            };

            if (_db.Account.IsExistName(model.BranchId, model.AccountName))
                return new DbResponse<AccountViewModel>(false, $" {model.AccountName} already Exist");

            return _db.Account.Add(model);

        }
        catch (Exception e)
        {
            return new DbResponse<AccountViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
        }
    }

    public DbResponse Edit(AccountViewModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.AccountName))
                return new DbResponse(false, "Invalid Data");

            if (_db.Account.IsNull(model.AccountId))
                return new DbResponse(false, "No Data Found");

            if (_db.Account.IsExistName(model.BranchId, model.AccountName, model.AccountId))
                return new DbResponse(false, $" {model.AccountName} already Exist");


            return _db.Account.Edit(model);

        }
        catch (Exception e)
        {
            return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
        }
    }

    public DbResponse Delete(int id)
    {
        try
        {
            if (!_db.Account.IsNull(id))
                return new DbResponse(false, "No data Found");

            if (_db.Account.IsRelatedDataExist(id))
                return new DbResponse(false, "Failed, already exist in products");

            return _db.Account.Delete(id);

        }
        catch (Exception e)
        {
            return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
        }
    }

    public DbResponse<AccountViewModel> Get(int id)
    {
        try
        {
            if (_db.Account.IsNull(id))
                return new DbResponse<AccountViewModel>(false, "No data Found");

            return _db.Account.Get(id);

        }
        catch (Exception e)
        {
            return new DbResponse<AccountViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
        }
    }

    public List<AccountViewModel> List(string userName)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return _db.Account.List(branchId);
    }

    public List<DDL> ListDdl(string userName)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return _db.Account.ListDdl(branchId);
    }

    public DbResponse<AccountDepositViewModel> Deposit(string userName, AccountDepositViewModel model)
    {
        try
        {
            if (model.DepositAmount < 0)
                return new DbResponse<AccountDepositViewModel>(false, "Invalid Data");

            if (_db.Account.IsNull(model.AccountId))
                return new DbResponse<AccountDepositViewModel>(false, $"Account Not Found");

            _db.Account.BalanceAdd(model.AccountId, model.DepositAmount);

            var accountDepositResponse = _db.Account.Deposit(model);
            //-----------Account log added-----------------------------
            if (accountDepositResponse.IsSuccess)
            {
                var accountLog = new AccountLogAddModel
                {
                    AccountId = accountDepositResponse.Data.AccountId,
                    BranchId = _db.Registration.BranchIdByUserName(userName),
                    RegistrationId = _db.Registration.RegistrationIdByUserName(userName),
                    IsAdded = true,
                    Amount = accountDepositResponse.Data.DepositAmount,
                    Details = accountDepositResponse.Data.Description,
                    Type = AccountLogType.Deposit,
                    TableName = AccountLogTableName.AccountDeposit,
                    TableId = accountDepositResponse.Data.AccountDepositId,
                    LogDate = accountDepositResponse.Data.DepositDate
                };

                _db.AccountLog.Add(accountLog);
            }

            return accountDepositResponse;

        }
        catch (Exception e)
        {
            return new DbResponse<AccountDepositViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
        }
    }

    public DataResult<AccountDepositViewModel> DepositList(DataRequest request)
    {
        return _db.Account.DepositList(request);
    }

    public DbResponse<AccountWithdrawViewModel> Withdraw(string userName, AccountWithdrawViewModel model)
    {
        try
        {
            if (model.WithdrawAmount < 0)
                return new DbResponse<AccountWithdrawViewModel>(false, "Invalid Data");

            if (_db.Account.IsNull(model.AccountId))
                return new DbResponse<AccountWithdrawViewModel>(false, $"Account Not Found");

            _db.Account.BalanceSubtract(model.AccountId, model.WithdrawAmount);

            var withdrawResponse = _db.Account.Withdraw(model);
            //-----------Account log added-----------------------------
            if (withdrawResponse.IsSuccess)
            {
                var accountLog = new AccountLogAddModel
                {
                    AccountId = withdrawResponse.Data.AccountId,
                    BranchId = _db.Registration.BranchIdByUserName(userName),
                    RegistrationId = _db.Registration.RegistrationIdByUserName(userName),
                    IsAdded = false,
                    Amount = withdrawResponse.Data.WithdrawAmount,
                    Details = withdrawResponse.Data.Description,
                    Type = AccountLogType.Withdraw,
                    TableName = AccountLogTableName.AccountWithdraw,
                    TableId = withdrawResponse.Data.AccountWithdrawId,
                    LogDate = withdrawResponse.Data.WithdrawDate
                };

                _db.AccountLog.Add(accountLog);
            }

            return withdrawResponse;

        }
        catch (Exception e)
        {
            return new DbResponse<AccountWithdrawViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
        }
    }

    public DataResult<AccountWithdrawViewModel> WithdrawList(DataRequest request)
    {
        return _db.Account.WithdrawList(request);
    }
}