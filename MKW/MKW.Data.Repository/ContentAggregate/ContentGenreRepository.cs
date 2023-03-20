using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Interface.Repository.ContentAggregate;

namespace MKW.Data.Repository.ContentAggregate
{
    /// <summary>
    /// Repositório para a entidade ContentGenre. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public class ContentGenreRepository : BaseRepository<ContentGenre>, IContentGenreRepository
    {
        public ContentGenreRepository(MKWContext context) : base(context) { }
    }
}
