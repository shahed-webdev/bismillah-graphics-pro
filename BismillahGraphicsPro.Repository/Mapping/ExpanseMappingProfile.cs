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

    }
}