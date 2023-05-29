using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Services.AppServices.Base;

namespace MKW.Services.AppServices
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository) : base(personRepository)
        {
            _personRepository = personRepository;
        }

        public Task<Person> GetByUserEmail(string email)
        {
            return _personRepository.GetByEmail(email);
        }
    }
}
