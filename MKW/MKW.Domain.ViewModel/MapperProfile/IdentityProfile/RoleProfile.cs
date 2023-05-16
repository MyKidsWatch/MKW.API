using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Dto.DTO.IdentityDTO.Auth;
using MKW.Domain.Dto.DTO.IdentityDTO.Authorization;
using MKW.Domain.Entities.IdentityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.MapperProfile.IdentityProfile
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole<int>, ReadRoleDTO>()
                .ForMember(dest => dest.RoleId, src => src.MapFrom(role => role.Id))
                .ForMember(dest => dest.RoleName, src => src.MapFrom(item => item.Name));
        }
    }
}
