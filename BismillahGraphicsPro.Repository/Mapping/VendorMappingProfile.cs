using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class VendorMappingProfile:Profile
{
    public VendorMappingProfile()
    {
        CreateMap<Vendor, VendorAddModel>().ReverseMap();
        CreateMap<Vendor, VendorEditModel>().ReverseMap();
        CreateMap<Vendor, VendorViewModel>().ReverseMap();
    }
}