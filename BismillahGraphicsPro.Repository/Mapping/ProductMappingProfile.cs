using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class ProductMappingProfile: Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductCategory, ProductCategoryCrudModel>().ReverseMap();
    }
}