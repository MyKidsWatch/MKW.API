using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;

namespace MKW.Data.Repository.UserAggregate
{
    /// <summary>
    /// Repositório para a entidade Gender. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(MKWContext context) : base(context)
        {
        }
    }
}
