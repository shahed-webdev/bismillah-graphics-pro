using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class ExpenseMappingProfile: Profile
{
    public ExpenseMappingProfile()
    {
        CreateMap<ExpenseCategory, ExpenseCategoryCrudModel>().ReverseMap();
        CreateMap<Expense, ExpenseAddModel>().ReverseMap();
        CreateMap<Expense,ExpenseViewModel>()
            .ForMember(d=> d.AccountName, opt=> opt.MapFrom(c=> c.Account.AccountName))
            .ForMember(d=> d.CategoryName, opt=> opt.MapFrom(c=> c.ExpenseCategory.CategoryName))
            .ForMember(d=> d.ExpenseByUserName, opt=> opt.MapFrom(c=> c.Registration.UserName))
            .ReverseMap();


    }
}