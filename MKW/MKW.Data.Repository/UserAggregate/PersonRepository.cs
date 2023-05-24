using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;

namespace MKW.Data.Repository.UserAggregate
{
    /// <summary>
    /// Repositório para a entidade Person. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(MKWContext context) : base(context)
        {
        }

        public async Task<Person> GetByEmail(string email) => _dbSet.FirstOrDefault(x => x.User.Email.ToLower() == email.ToLower());
    }
}
