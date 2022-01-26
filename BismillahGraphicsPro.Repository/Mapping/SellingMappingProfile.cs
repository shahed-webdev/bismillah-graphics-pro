using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class SellingMappingProfile: Profile
{
    public SellingMappingProfile()
    {
        CreateMap<SellingList, SellingListAddModel>().ReverseMap();
        CreateMap<Selling, SellingAddModel>().ReverseMap();
        
        CreateMap<SellingList, SellingListViewModel>()
            .ForMember(d=> d.MeasurementUnitName, opt=> opt.MapFrom(c=> c.MeasurementUnit.MeasurementUnitName))
            .ForMember(d=> d.ProductName, opt=> opt.MapFrom(c=> c.Product.ProductName))
            .ReverseMap();

        CreateMap<SellingPaymentRecord, SellingPaymentViewModel>()
            .ForMember(d => d.AccountName, opt => opt.MapFrom(c => c.Account.AccountName))
            .ReverseMap();
        CreateMap<Selling, SellingRecordViewModel>()
            .ForMember(d => d.SoldByUserName, opt => opt.MapFrom(c => c.Registration.UserName))
            .ForMember(d => d.VendorCompanyName, opt => opt.MapFrom(c => c.Vendor.VendorCompanyName))
            .ForMember(d => d.VendorSmsNumber, opt => opt.MapFrom(c => c.Vendor.SmsNumber))
            .ReverseMap();

        CreateMap<Selling, SellingReceiptViewModel>()
            .ForMember(d => d.SoldByUserName, opt => opt.MapFrom(c => c.Registration.UserName))
            .ReverseMap();

        CreateMap<SellingDuePayModel, SellingPaymentReceipt>();
        CreateMap<Selling, SellingDueBillsViewModel>();

    }
}