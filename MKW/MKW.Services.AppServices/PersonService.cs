using Microsoft.AspNetCore.Http;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Utility.Exceptions;
using MKW.Domain.Utility.Extensions;
using MKW.Services.AppServices.Base;

namespace MKW.Services.AppServices
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PersonService(IPersonRepository personRepository, IHttpContextAccessor httpContextAccessor) : base(personRepository)
        {
            _personRepository = personRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<Person> GetByUserEmail(string email) => _personRepository.GetByEmail(email);

        public async Task<Person> GetUser()
        {
            var email = _httpContextAccessor.HttpContext?.GetUserEmail();
            return await _personRepository.GetByEmail(email) ?? throw new NotFoundException("User not found.");
        }
    }
}
