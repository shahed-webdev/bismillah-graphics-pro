using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.BusinessLogic;

public interface IPurchaseCore
{
    Task<DbResponse<int>> AddAsync(string userName, PurchaseAddModel model);
    Task<DbResponse<PurchaseReceiptViewModel>> GetAsync(int id);
}