using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class ProductMappingProfile: Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductCategory, ProductCategoryCrudModel>().ReverseMap();
        CreateMap<Product, ProductAddModel>().ReverseMap();
        CreateMap<Product, ProductViewModel>()
            .ForMember(d => d.ProductCategoryName, opt => opt.MapFrom(c => c.ProductCategory.ProductCategoryName))
            .ReverseMap();
    }
}