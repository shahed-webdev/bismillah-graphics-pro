using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository 
{
    public class BranchMappingProfile : Profile
    {
        public BranchMappingProfile()
        {
            CreateMap<Branch, BranchListModel>()
                .ForMember(d => d.AdminPassword, opt => opt.MapFrom(c => c.Registrations.FirstOrDefault().Ps))

                .ReverseMap();
            CreateMap<Branch, BranchDetailsModel>().ReverseMap();
            CreateMap<Branch, BranchEditModel>().ReverseMap();
        }
    }
}
