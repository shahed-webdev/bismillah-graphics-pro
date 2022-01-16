using AutoMapper;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;

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

            if (!_db.Account.IsNull(model.AccountId))
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
}