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
    public class RegistrationMappingProfile: Profile
    {
        public RegistrationMappingProfile()
        {
            CreateMap<BranchCreateModel, Registration>()
                .ForMember(d => d.Ps, opt => opt.MapFrom(c => c.Password))
                .ForMember(d => d.Branch, opt => opt.MapFrom(c => new Branch
                {
                    AdminUserName = c.UserName,
                    BranchName = c.Name,
                    BranchAddress = c.Address,
                    BranchPhone = c.Phone,
                    BranchEmail = c.Email
                }));
            CreateMap<SubAdminCreateModel, Registration>()
                .ForMember(d => d.Ps, opt => opt.MapFrom(c => c.Password));
            CreateMap<Registration, SubAdminListModel>().ReverseMap();
            CreateMap<Registration, RegistrationEditModel>().ReverseMap();
        }
    }
}
