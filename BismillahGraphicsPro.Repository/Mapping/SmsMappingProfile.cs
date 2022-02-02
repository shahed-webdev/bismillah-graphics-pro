using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class SmsMappingProfile : Profile
{
    public SmsMappingProfile()
    {
        CreateMap<SmsSendRecord, SmsSendRecordViewModel>().ReverseMap();

    }
}