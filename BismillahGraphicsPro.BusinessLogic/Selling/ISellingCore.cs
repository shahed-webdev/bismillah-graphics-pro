using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public interface ISellingCore
{
    Task<DbResponse<int>> AddAsync(string userName, SellingAddModel model);
    Task<DbResponse<SellingReceiptViewModel>> GetAsync(int id);
    Task<DbResponse<int>> EditAsync(SellingEditModel model);
    Task<DataResult<SellingRecordViewModel>> ListAsync(string userName, DataRequest request);
}