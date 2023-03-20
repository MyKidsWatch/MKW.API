using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Interface.Repository.Base;

namespace MKW.Domain.Interface.Repository.ContentAggregate
{
    /// <summary>
    /// Repositório para a entidade Genre. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public interface IGenreRepository : IBaseRepository<Genre>
    {
    }
}
