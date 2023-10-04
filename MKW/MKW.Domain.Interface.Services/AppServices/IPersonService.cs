using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Services.AppServices.Base;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IPersonService : IBaseService<Person>
    {
        Task<Person> GetByUserEmail(string email);
        Task<Person> GetUser();
    }
}