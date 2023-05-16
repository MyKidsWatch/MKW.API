using AutoMapper;
using MKW.Domain.Dto.DTO.IdentityDTO.Auth;
using MKW.Domain.Entities.IdentityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.MapperProfile.IdentityProfile
{
    public class TokenProfile : Profile
    {
        public TokenProfile()
        {
            CreateMap<ApplicationToken, TokenDTO>();
        }
    }
}
