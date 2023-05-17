using AutoMapper;
using MKW.Domain.Dto.DTO.PersonDTO;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Dto.MapperProfile.PersonProfile
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonOnCreateUserDTO, Person>();
            CreateMap<Person, ReadPersonDTO>();
        }
    }
}
