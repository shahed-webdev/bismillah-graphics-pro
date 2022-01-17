using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public class AccountRepository: Repository, IAccountRepository
{
    public AccountRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public DbResponse<AccountViewModel> Add(AccountAddModel model)
    {
        var account = _mapper.Map<Account>(model);
        Db.Accounts.Add(account);
        Db.SaveChanges();
        var accountViewModel = _mapper.Map<AccountViewModel>(account);

        return new DbResponse<AccountViewModel>(true, $"{model.AccountName} Created Successfully", accountViewModel);

    }

    public DbResponse Edit(AccountViewModel model)
    {
        var account = Db.Accounts.Find(model.AccountId);
        account!.AccountName = model.AccountName;
        Db.Accounts.Update(account);
        Db.SaveChanges();
        return new DbResponse(true, $"{account.AccountName} Updated Successfully");

    }

    public DbResponse Delete(int id)
    {
        var account = Db.Accounts.Find(id);
        Db.Accounts.Remove(account!);
        Db.SaveChanges();
        return new DbResponse(true, $"{account.AccountName} Deleted Successfully");

    }

    public DbResponse<AccountViewModel> Get(int id)
    {
        var account = Db.Accounts.Where(r => r.AccountId == id)
            .ProjectTo<AccountViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();
        return new DbResponse<AccountViewModel>(true, $"{account!.AccountName} Get Successfully", account);

    }

    public bool IsExistName(int branchId, string name)
    {
        return Db.Accounts.Any(r => r.BranchId == branchId && r.AccountName == name);
    }

    public bool IsExistName(int branchId, string name, int updateId)
    {
        return Db.Accounts.Any(r => r.BranchId == branchId && r.AccountName == name && r.AccountId != updateId);
    }

    public bool IsNull(int id)
    {
        return Db.Accounts.Any(r => r.AccountId == id);
    }

    public bool IsRelatedDataExist(int id)
    {
        return Db.AccountDeposits.Any(m => m.AccountId == id)
               || Db.AccountWithdraws.Any(m => m.AccountId == id)
               || Db.Expanses.Any(m => m.AccountId == id)
               || Db.PurchasePaymentReceipts.Any(m => m.AccountId == id)
               || Db.SellingPaymentReceipts.Any(m => m.AccountId == id);
    }

    public List<AccountViewModel> List(int branchId)
    {
        return Db.Accounts.Where(m => m.BranchId == branchId)
            .ProjectTo<AccountViewModel>(_mapper.ConfigurationProvider)
            .OrderBy(a => a.AccountName)
            .ToList();
    }

    public List<DDL> ListDdl(int branchId)
    {
        return Db.Accounts
            .OrderBy(a => a.AccountName)
            .Select(m => new DDL
            {
                value = m.AccountId.ToString(),
                label = m.AccountName
            }).ToList();
    }
    public void BalanceAdd(int id, decimal amount)
    {
        var account = Db.Accounts.Find(id);
        if (account == null) return;
        account.Balance += amount;
        Db.Accounts.Update(account);
    }

    public void BalanceSubtract(int id, decimal amount)
    {
        var account = Db.Accounts.Find(id);
        if (account == null) return;
        account.Balance -= amount;
        Db.Accounts.Update(account);
    }

    public DbResponse<AccountDepositViewModel> Deposit(AccountDepositViewModel model)
    {
        var accountDeposit = _mapper.Map<AccountDeposit>(model);
        Db.AccountDeposits.Add(accountDeposit);
        Db.SaveChanges();
        model.AccountDepositId = accountDeposit.AccountDepositId;

        return new DbResponse<AccountDepositViewModel>(true, $"{model.DepositAmount} Amount Deposited Successfully", model);

    }

    public DataResult<AccountDepositViewModel> DepositList(DataRequest request)
    {
        return Db.AccountDeposits
            .ProjectTo<AccountDepositViewModel>(_mapper.ConfigurationProvider)
            .OrderBy(a => a.DepositDate)
            .ToDataResult(request);
    }

    public DbResponse<AccountWithdrawViewModel> Withdraw(AccountWithdrawViewModel model)
    {
        var accountWithdraw = _mapper.Map<AccountWithdraw>(model);
        Db.AccountWithdraws.Add(accountWithdraw);
        Db.SaveChanges();
        model.AccountWithdrawId = accountWithdraw.AccountWithdrawId;

        return new DbResponse<AccountWithdrawViewModel>(true, $"{model.WithdrawAmount} Amount Deposited Successfully", model);

    }

    public DataResult<AccountWithdrawViewModel> WithdrawList(DataRequest request)
    {
        return Db.AccountWithdraws
            .ProjectTo<AccountWithdrawViewModel>(_mapper.ConfigurationProvider)
            .OrderBy(a => a.WithdrawDate)
            .ToDataResult(request);
    }
}