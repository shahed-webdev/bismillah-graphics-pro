using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public interface IAccountLogRepository
{
    void Add(AccountLogAddModel model);
    void Delete(AccountLogTableName tableName, int tableId);
    DataResult<AccountLogViewModel> List(DataRequest request, int branchId);
}