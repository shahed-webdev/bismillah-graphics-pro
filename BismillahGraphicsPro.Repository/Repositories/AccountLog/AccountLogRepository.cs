using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

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

    public void delete(AccountLogTableName tableName, int tableId)
    {
        var accountLog = Db.AccountLogs.FirstOrDefault(x => x.TableName == tableName && x.TableId == tableId);
        if (accountLog == null) return;
        Db.AccountLogs.Remove(accountLog);
        Db.SaveChanges();
    }
}