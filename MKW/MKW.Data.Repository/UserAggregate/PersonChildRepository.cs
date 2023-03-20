using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;

namespace MKW.Data.Repository.UserAggregate
{
    /// <summary>
    /// Repositório para a entidade PersonChild. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public class PersonChildRepository : BaseRepository<PersonChild>, IPersonChildRepository
    {
        public PersonChildRepository(MKWContext context) : base(context)
        {
        }
    }
}
