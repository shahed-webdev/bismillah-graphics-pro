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
}