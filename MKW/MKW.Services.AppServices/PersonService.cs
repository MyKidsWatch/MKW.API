using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.ReviewAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Services.AppServices.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Services.AppServices
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        public PersonService(IPersonRepository personRepository) : base(personRepository)
        {
        }
    }
}
