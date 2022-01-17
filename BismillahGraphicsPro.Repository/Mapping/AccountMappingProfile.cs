using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class AccountMappingProfile: Profile
{
    public AccountMappingProfile()
    {
        CreateMap<Account, AccountAddModel>().ReverseMap();
        CreateMap<Account, AccountViewModel>().ReverseMap();
        CreateMap<AccountDeposit, AccountDepositViewModel>().ReverseMap();
        CreateMap<AccountWithdraw, AccountWithdrawViewModel>().ReverseMap();
    }
}