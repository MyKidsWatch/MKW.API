using AutoMapper;
using MKW.Domain.Dto.DTO.IdentityDTO.Authentication;
using MKW.Domain.Entities.IdentityAggregate;

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
