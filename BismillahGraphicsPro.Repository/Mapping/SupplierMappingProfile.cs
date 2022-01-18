using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class SupplierMappingProfile : Profile
{
    public SupplierMappingProfile()
    {
        CreateMap<Supplier, SupplierAddModel>().ReverseMap();
        CreateMap<Supplier, SupplierEditModel>().ReverseMap();
        CreateMap<Supplier, SupplierViewModel>().ReverseMap();
    }
}