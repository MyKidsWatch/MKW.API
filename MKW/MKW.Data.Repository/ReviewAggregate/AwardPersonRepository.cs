using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Interface.Repository.ReviewAggregate;

namespace MKW.Data.Repository.ReviewAggregate
{
    public class AwardPersonRepository : BaseRepository<AwardPerson>, IAwardPersonRepository
    {
        public AwardPersonRepository(MKWContext context) : base(context)
        {
        }
    }
}
