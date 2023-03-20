using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Interface.Repository.ContentAggregate;

namespace MKW.Data.Repository.ContentAggregate
{
    /// <summary>
    /// Repositório para a entidade PlatformCategory. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public class PlatformCategoryRepository : BaseRepository<PlatformCategory>, IPlatformCategoryRepository
    {
        public PlatformCategoryRepository(MKWContext context) : base(context)
        {
        }
    }
}
