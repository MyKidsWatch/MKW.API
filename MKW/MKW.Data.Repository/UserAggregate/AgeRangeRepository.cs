using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;

namespace MKW.Data.Repository.UserAggregate
{
    /// <summary>
    /// Repositório para a entidade AgeRange. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public class AgeRangeRepository : BaseRepository<AgeRange>, IAgeRangeRepository
    {
        public AgeRangeRepository(MKWContext context) : base(context)
        {
        }
    }
}
