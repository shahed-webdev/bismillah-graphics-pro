using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public interface IAccountLogRepository
{
    void Add(AccountLogAddModel model);
}