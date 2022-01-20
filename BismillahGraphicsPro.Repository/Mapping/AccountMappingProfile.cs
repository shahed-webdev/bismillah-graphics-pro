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
        CreateMap<AccountLog, AccountLogAddModel>().ReverseMap();
        CreateMap<AccountLog, AccountLogViewModel>()
            .ForMember(d => d.AccountName, opt => opt.MapFrom(c => c.Account.AccountName))
            .ForMember(d => d.LogByUserName, opt => opt.MapFrom(c => c.Registration.UserName))
            .ForMember(d => d.Type, opt => opt.MapFrom(c => c.Type.ToString()))
            .ReverseMap();
    }
}