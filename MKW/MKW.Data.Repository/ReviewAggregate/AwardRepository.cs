using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Interface.Repository.ReviewAggregate;

namespace MKW.Data.Repository.ReviewAggregate
{
    public class AwardRepository : BaseRepository<Award>, IAwardRepository
    {
        public AwardRepository(MKWContext context) : base(context)
        {
        }
    }
}
