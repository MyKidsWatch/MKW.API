using AutoMapper;
using MKW.Domain.Dto.DTO.AwardDTO;
using MKW.Domain.Dto.DTO.PersonDTO;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Dto.MapperProfile.ProfileProfile
{
    public class ProfileProfile : Profile
    {
        public ProfileProfile()
        {
            CreateMap<Person, ReadProfileDTO>()
             .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.ImageURL))
             .ForMember(dest => dest.Childrens, opt => opt.MapFrom(src => src.Children))
             .ForMember(dest => dest.Awards, opt => opt.MapFrom(src => src.AwardsGiven
                .GroupBy(x => x.Award.Name)
                .Select(group => new ReadAwardDTO
                {
                    Name = group.Key.ToString(),
                    Quantity = group.Count()
                }).ToList()));

            CreateMap<ApplicationUser, ReadProfileDTO>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}