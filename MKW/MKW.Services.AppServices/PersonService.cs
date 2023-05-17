using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Services.AppServices.Base;

namespace MKW.Services.AppServices
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        public PersonService(IPersonRepository personRepository) : base(personRepository)
        {
        }
    }
}
