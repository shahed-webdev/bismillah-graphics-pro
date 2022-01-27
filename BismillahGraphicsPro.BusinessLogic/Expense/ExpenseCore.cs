using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public class ExpenseCore : Core, IExpenseCore
{
    public ExpenseCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
    {
    }

    public Task<DbResponse<ExpenseViewModel>> AddAsync(string userName, ExpenseAddModel model)
    {
        try
        {
            if (model.ExpenseAmount < 0)
                return Task.FromResult(new DbResponse<ExpenseViewModel>(false, "Invalid Data"));

            if (_db.Account.IsNull(model.AccountId))
                return Task.FromResult(new DbResponse<ExpenseViewModel>(false, $"Account Not Found"));

            var branchId = _db.Registration.BranchIdByUserName(userName);
            var registrationId = _db.Registration.RegistrationIdByUserName(userName);
            model.BranchId = branchId;
            model.RegistrationId = registrationId;

            var expenseResponse = _db.Expense.Add(model);
            
            //-----------Account and Account log added-----------------------------
            if (expenseResponse.IsSuccess)
            {
                _db.Account.BalanceSubtract(model.AccountId, model.ExpenseAmount);

                var accountLog = new AccountLogAddModel
                {
                    AccountId = expenseResponse.Data.AccountId,
                    BranchId = branchId,
                    RegistrationId = registrationId,
                    IsAdded = false,
                    Amount = expenseResponse.Data.ExpenseAmount,
                    Details = expenseResponse.Data.ExpenseFor,
                    Type = AccountLogType.Expense,
                    TableName = AccountLogTableName.Expense,
                    TableId = expenseResponse.Data.ExpenseId,
                    LogDate = expenseResponse.Data.ExpenseDate
                };

                _db.AccountLog.Add(accountLog);
            }

            return Task.FromResult(expenseResponse);
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<ExpenseViewModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DataResult<ExpenseViewModel>> ListAsync(string userName, DataRequest request)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.Expense.List(request, branchId));
    }

    public Task<DbResponse> DeleteAsync(int id)
    {
        try
        {
            var expenseResponse = _db.Expense.Get(id);
            if (!expenseResponse.IsSuccess)
                return Task.FromResult(new DbResponse(false, expenseResponse.Message));

            _db.Account.BalanceAdd(expenseResponse.Data.AccountId, expenseResponse.Data.ExpenseAmount);

            _db.AccountLog.Delete(AccountLogTableName.Expense, id);

            return Task.FromResult(_db.Expense.Delete(id));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<List<ExpenseCategoryWiseViewModel>> CategoryWiseExpenseAsync(string userName, DateTime? sDate, DateTime? eDate)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.Expense.CategoryWiseExpense(branchId, sDate, eDate));
    }

    public Task<DbResponse<decimal>> TotalExpenseAsync(string userName, DateTime? sDate, DateTime? eDate)
    {
        try
        {
            var branchId = _db.Registration.BranchIdByUserName(userName);
            return Task.FromResult(new DbResponse<decimal>(true, "Success",
                _db.Expense.TotalExpense(branchId, sDate, eDate)));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse<decimal>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<ExpenseCategoryCrudModel>> CategoryAddAsync(string categoryName, string userName)
    {
        try
        {
            if (string.IsNullOrEmpty(categoryName))
                return Task.FromResult(new DbResponse<ExpenseCategoryCrudModel>(false, "Invalid Data"));

            var model = new ExpenseCategoryCrudModel
            {
                BranchId = _db.Registration.BranchIdByUserName(userName),
                CategoryName = categoryName
            };

            if (_db.ExpenseCategory.IsExistName(model.BranchId, model.CategoryName))
                return Task.FromResult(
                    new DbResponse<ExpenseCategoryCrudModel>(false, $" {model.CategoryName} already Exist"));

            return Task.FromResult(_db.ExpenseCategory.Add(model));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<ExpenseCategoryCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse> CategoryEditAsync(ExpenseCategoryCrudModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.CategoryName))
                return Task.FromResult(new DbResponse(false, "Invalid Data"));

            if (_db.ExpenseCategory.IsNull(model.ExpenseCategoryId))
                return Task.FromResult(new DbResponse(false, "No Data Found"));

            if (_db.ExpenseCategory.IsExistName(model.BranchId, model.CategoryName, model.ExpenseCategoryId))
                return Task.FromResult(new DbResponse(false, $" {model.CategoryName} already Exist"));


            return Task.FromResult(_db.ExpenseCategory.Edit(model));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse> CategoryDeleteAsync(int id)
    {
        try
        {
            if (_db.ExpenseCategory.IsNull(id))
                return Task.FromResult(new DbResponse(false, "No data Found"));

            if (_db.ExpenseCategory.IsRelatedDataExist(id))
                return Task.FromResult(new DbResponse(false, "Failed, already exist in products"));

            return Task.FromResult(_db.ExpenseCategory.Delete(id));
        }
        catch (Exception e)
        {
            return Task.FromResult(new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<DbResponse<ExpenseCategoryCrudModel>> CategoryGetAsync(int id)
    {
        try
        {
            if (_db.ExpenseCategory.IsNull(id))
                return Task.FromResult(new DbResponse<ExpenseCategoryCrudModel>(false, "No data Found"));

            return Task.FromResult(_db.ExpenseCategory.Get(id));
        }
        catch (Exception e)
        {
            return Task.FromResult(
                new DbResponse<ExpenseCategoryCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
        }
    }

    public Task<List<ExpenseCategoryCrudModel>> CategoryListAsync(string userName)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.ExpenseCategory.List(branchId));
    }

    public Task<List<DDL>> CategoryDdlAsync(string userName)
    {
        var branchId = _db.Registration.BranchIdByUserName(userName);
        return Task.FromResult(_db.ExpenseCategory.ListDdl(branchId));
    }
}