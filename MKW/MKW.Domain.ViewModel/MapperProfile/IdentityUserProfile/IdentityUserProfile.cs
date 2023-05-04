using AutoMapper;
using MKW.Domain.Dto.IdentityDTO;
using MKW.Domain.Entities.IdentityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.MapperProfile.IdentityUserProfile
{
    public class IdentityUserProfile : Profile
    {
        public IdentityUserProfile()
        {
            CreateMap<CreateUserDTO, ApplicationUser>();
            CreateMap<ApplicationUser, ReadUserDTO>();
            CreateMap<UpdateUserDTO, ApplicationUser>();
            CreateMap<DeleteUserDTO, ApplicationUser>();
        }
    }
}
