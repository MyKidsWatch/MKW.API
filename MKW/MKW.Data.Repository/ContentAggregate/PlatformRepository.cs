using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Interface.Repository.ContentAggregate;

namespace MKW.Data.Repository.ContentAggregate
{
    /// <summary>
    /// Repositório para a entidade Platform. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public class PlatformRepository : BaseRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(MKWContext context) : base(context)
        {
        }
    }
}
