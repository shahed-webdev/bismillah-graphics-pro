using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class PurchaseMappingProfile : Profile
{
    public PurchaseMappingProfile()
    {
        CreateMap<PurchaseList, PurchaseListAddModel>().ReverseMap();
        CreateMap<Purchase, PurchaseAddModel>().ReverseMap();

        CreateMap<PurchaseList, PurchaseListViewModel>()
            .ForMember(d => d.MeasurementUnitName, opt => opt.MapFrom(c => c.MeasurementUnit.MeasurementUnitName))
            .ForMember(d => d.ProductName, opt => opt.MapFrom(c => c.Product.ProductName))
            .ReverseMap();

        CreateMap<PurchasePaymentRecord, PurchasePaymentViewModel>()
            .ForMember(d => d.AccountName, opt => opt.MapFrom(c => c.Account.AccountName))
            .ReverseMap();
        CreateMap<Purchase, PurchaseRecordViewModel>()
            .ForMember(d => d.SoldByUserName, opt => opt.MapFrom(c => c.Registration.UserName))
            .ForMember(d => d.SupplierCompanyName, opt => opt.MapFrom(c => c.Supplier.SupplierCompanyName))
            .ForMember(d => d.SupplierSmsNumber, opt => opt.MapFrom(c => c.Supplier.SmsNumber))
            .ReverseMap();

        CreateMap<Purchase, PurchaseReceiptViewModel>()
            .ForMember(d => d.SoldByUserName, opt => opt.MapFrom(c => c.Registration.UserName))
            .ReverseMap();

        CreateMap<PurchaseDuePayModel, PurchasePaymentReceipt>();
        CreateMap<Purchase, PurchaseDueBillsViewModel>();
    }
}