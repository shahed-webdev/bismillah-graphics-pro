using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public interface IAccountLogRepository
{
    void Add(AccountLogAddModel model);
    void delete(AccountLogTableName tableName, int tableId);
}