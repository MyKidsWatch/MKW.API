using AutoMapper;
using MKW.Domain.Dto.Identity;
using MKW.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.MapperProfile.Identity
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<User, ReadUserDTO>();
            CreateMap<IEnumerable<User>, IEnumerable<ReadUserDTO>>();
            CreateMap<UpdateUserDTO, User>();
            CreateMap<DeleteUserDTO, User>();
        }
    }
}
