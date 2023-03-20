using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.Base;

namespace MKW.Domain.Interface.Repository.UserAggregate
{
    /// <summary>
    /// Repositório para a entidade Gender. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public interface IGenderRepository : IBaseRepository<Gender>
    {
    }
}
