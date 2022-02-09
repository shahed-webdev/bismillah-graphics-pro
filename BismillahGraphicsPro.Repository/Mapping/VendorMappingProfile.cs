using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class VendorMappingProfile:Profile
{
    public VendorMappingProfile()
    {
        CreateMap<VendorAddModel,Vendor>()
            .ForMember(d => d.VendorCompanyName, opt => opt.MapFrom(c => c.VendorCompanyName.Trim()))
            .ForMember(d => d.VendorName, opt => opt.MapFrom(c => c.VendorName.Trim()))
            .ForMember(d => d.VendorAddress, opt => opt.MapFrom(c => c.VendorAddress.Trim()))
            .ForMember(d => d.VendorPhone, opt => opt.MapFrom(c => c.VendorPhone.Trim()))
            .ReverseMap();
        CreateMap<VendorEditModel,Vendor>()
            .ForMember(d => d.VendorCompanyName, opt => opt.MapFrom(c => c.VendorCompanyName.Trim()))
            .ForMember(d => d.VendorName, opt => opt.MapFrom(c => c.VendorName.Trim()))
            .ForMember(d => d.VendorAddress, opt => opt.MapFrom(c => c.VendorAddress.Trim()))
            .ForMember(d => d.VendorPhone, opt => opt.MapFrom(c => c.VendorPhone.Trim()))
            .ReverseMap();

        CreateMap<Vendor, VendorViewModel>().ReverseMap();
        CreateMap<Vendor, SellingDueViewModel>()
            .ForMember(d => d.TotalDue, opt => opt.MapFrom(c => c.VendorDue));

    }
}