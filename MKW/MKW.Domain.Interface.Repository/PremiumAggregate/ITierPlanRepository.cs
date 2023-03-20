using MKW.Domain.Entities.PremiumAggregate;
using MKW.Domain.Interface.Repository.Base;

namespace MKW.Domain.Interface.Repository.PremiumAggregate
{
    /// <summary>
    /// Repositório para a entidade TierPlan. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public interface ITierPlanRepository : IBaseRepository<TierPlan>
    {
    }
}
