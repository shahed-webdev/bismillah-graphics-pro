using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class ExpanseMappingProfile: Profile
{
    public ExpanseMappingProfile()
    {
        CreateMap<ExpanseCategory, ExpanseCategoryCrudModel>().ReverseMap();
        CreateMap<Expanse, ExpenseAddModel>().ReverseMap();
        CreateMap<Expanse,ExpenseViewModel>()
            .ForMember(d=> d.AccountName, opt=> opt.MapFrom(c=> c.Account.AccountName))
            .ForMember(d=> d.CategoryName, opt=> opt.MapFrom(c=> c.ExpanseCategory.CategoryName))
            .ForMember(d=> d.ExpenseByUserName, opt=> opt.MapFrom(c=> c.Registration.UserName))
            .ReverseMap();


    }
}