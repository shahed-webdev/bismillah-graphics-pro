using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class PurchaseMappingProfile: Profile
{
    public PurchaseMappingProfile()
    {
        CreateMap<PurchaseList, PurchaseListAddModel>().ReverseMap();
        CreateMap<Purchase, PurchaseAddModel>().ReverseMap();
    }
}