using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.PremiumAggregate;
using MKW.Domain.Interface.Repository.PremiumAggregate;

namespace MKW.Data.Repository.PremiumAggregate
{
    /// <summary>
    /// Repositório para a entidade Timespan. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public class TimespanRepository : BaseRepository<Timespan>, ITimespanRepository
    {
        public TimespanRepository(MKWContext context) : base(context)
        {
        }
    }
}
