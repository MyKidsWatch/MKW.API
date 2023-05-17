using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;

namespace MKW.Data.Repository.UserAggregate
{
    public class OperationTypeRepository : BaseRepository<OperationType>, IOperationTypeRepository
    {
        public OperationTypeRepository(MKWContext context) : base(context)
        {
        }
    }
}
