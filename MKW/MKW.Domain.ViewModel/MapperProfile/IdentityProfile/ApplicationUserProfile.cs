using AutoMapper;
using MKW.Domain.Dto.DTO.IdentityDTO.Account;
using MKW.Domain.Entities.IdentityAggregate;

namespace MKW.Domain.Dto.MapperProfile.IdentityProfile
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<CreateUserDTO, ApplicationUser>();
            CreateMap<ApplicationUser, ReadUserDTO>();
            CreateMap<UpdateUserDTO, ApplicationUser>();
            CreateMap<DeleteUserDTO, ApplicationUser>();
        }
    }
}
