using AutoMapper;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Dto.PersonDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.MapperProfile.PersonProfile
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonOnCreateUserDTO, Person>();
        }
    }   
}
