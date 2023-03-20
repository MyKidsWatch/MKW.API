using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Interface.Repository.ContentAggregate;

namespace MKW.Data.Repository.ContentAggregate
{
    /// <summary>
    /// Repositório para a entidade Genre. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MKWContext context) : base(context) { }
    }
}
