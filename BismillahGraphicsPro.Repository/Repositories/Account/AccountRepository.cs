using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

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

}