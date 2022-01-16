using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public class MeasurementUnitMappingProfile : Profile
{
    public MeasurementUnitMappingProfile()
    {
        CreateMap<MeasurementUnit, MeasurementUnitCrudModel>().ReverseMap();
    }
}