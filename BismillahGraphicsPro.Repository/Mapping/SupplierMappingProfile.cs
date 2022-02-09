using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class SupplierMappingProfile : Profile
{
    public SupplierMappingProfile()
    {
        CreateMap<SupplierAddModel, Supplier>()
            .ForMember(d => d.SupplierCompanyName, opt => opt.MapFrom(c => c.SupplierCompanyName.Trim()))
            .ForMember(d => d.SupplierName, opt => opt.MapFrom(c => c.SupplierName.Trim()))
            .ForMember(d => d.SupplierAddress, opt => opt.MapFrom(c => c.SupplierAddress.Trim()))
            .ForMember(d => d.SupplierPhone, opt => opt.MapFrom(c => c.SupplierPhone.Trim()))
            .ReverseMap();
        CreateMap<SupplierEditModel, Supplier>()
            .ForMember(d => d.SupplierCompanyName, opt => opt.MapFrom(c => c.SupplierCompanyName.Trim()))
            .ForMember(d => d.SupplierName, opt => opt.MapFrom(c => c.SupplierName.Trim()))
            .ForMember(d => d.SupplierAddress, opt => opt.MapFrom(c => c.SupplierAddress.Trim()))
            .ForMember(d => d.SupplierPhone, opt => opt.MapFrom(c => c.SupplierPhone.Trim()))
            .ReverseMap();
        CreateMap<Supplier, SupplierViewModel>().ReverseMap();
        CreateMap<Supplier, PurchaseDueViewModel>()
            .ForMember(d => d.TotalDue, opt => opt.MapFrom(c => c.SupplierDue));
    }
}