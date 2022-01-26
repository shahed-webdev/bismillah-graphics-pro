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

        CreateMap<PurchasePaymentRecord, PurchasePaymentRecordViewModel>()
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
        CreateMap<PurchasePaymentReceipt, PurchasePaymentViewModel>()
            .ForMember(d => d.PaidByUserName, opt => opt.MapFrom(c => c.Registration.UserName))
            .ForMember(d => d.SupplierCompanyName, opt => opt.MapFrom(c => c.Supplier.SupplierCompanyName))
            .ForMember(d => d.SmsNumber, opt => opt.MapFrom(c => c.Supplier.SmsNumber))
            .ForMember(d => d.SupplierAddress, opt => opt.MapFrom(c => c.Supplier.SupplierAddress))
            .ForMember(d => d.AccountName, opt => opt.MapFrom(c => c.Account.AccountName));


        CreateMap<PurchasePaymentRecord, PurchasePaymentBillModel>()
            .ForMember(d => d.PurchaseDate, opt => opt.MapFrom(c => c.Purchase.PurchaseDate))
            .ForMember(d => d.PurchaseSn, opt => opt.MapFrom(c => c.Purchase.PurchaseSn))
            .ForMember(d => d.PurchaseTotalPrice, opt => opt.MapFrom(c => c.Purchase.PurchaseTotalPrice))
            ;

        CreateMap<PurchasePaymentReceipt, PurchasePaymentReceiptViewModel>()
            .ForMember(d => d.PaidByUserName, opt => opt.MapFrom(c => c.Registration.UserName))
            .ForMember(d => d.SupplierCompanyName, opt => opt.MapFrom(c => c.Supplier.SupplierCompanyName))
            .ForMember(d => d.SupplierName, opt => opt.MapFrom(c => c.Supplier.SupplierName))
            .ForMember(d => d.SmsNumber, opt => opt.MapFrom(c => c.Supplier.SmsNumber))
            .ForMember(d => d.SupplierAddress, opt => opt.MapFrom(c => c.Supplier.SupplierAddress))
            .ForMember(d => d.AccountName, opt => opt.MapFrom(c => c.Account.AccountName))
            .ForMember(d => d.Bills, opt => opt.MapFrom(c => c.PurchasePaymentRecords));


        
    }
}