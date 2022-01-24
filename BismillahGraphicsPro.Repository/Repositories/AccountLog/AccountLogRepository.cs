using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public class AccountLogRepository: Repository, IAccountLogRepository
{
    public AccountLogRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public void Add(AccountLogAddModel model)
    {
        var accountLog = _mapper.Map<AccountLog>(model);
        Db.AccountLogs.Add(accountLog);
        Db.SaveChanges();
    }

    public void AddRange(List<AccountLogAddModel> model)
    {
        var accountLogs = model.Select(m=> _mapper.Map<AccountLog>(m)).ToList();
        Db.AccountLogs.AddRange(accountLogs);
        Db.SaveChanges();
    }

    public void Delete(AccountLogTableName tableName, int tableId)
    {
        var accountLog = Db.AccountLogs.FirstOrDefault(x => x.TableName == tableName && x.TableId == tableId);
        if (accountLog == null) return;
        Db.AccountLogs.Remove(accountLog);
        Db.SaveChanges();
    }

    public DataResult<AccountLogViewModel> List(DataRequest request, int branchId)
    {
        return Db.AccountLogs
            .Where(e => e.BranchId == branchId)
            .ProjectTo<AccountLogViewModel>(_mapper.ConfigurationProvider)
            .OrderByDescending(a => a.InsertDateBdTime)
            .ToDataResult(request);
    }
}