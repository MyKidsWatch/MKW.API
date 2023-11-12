using Microsoft.EntityFrameworkCore;
using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Utility.Exceptions;

namespace MKW.Data.Repository.UserAggregate
{
    public class OperationTypeRepository : BaseRepository<OperationType>, IOperationTypeRepository
    {
        public OperationTypeRepository(MKWContext context) : base(context)
        {
        }

        public async Task<OperationType> GetOperationByType(string operationType) =>
            await _dbSet.FirstOrDefaultAsync(x => x.Type == operationType) ?? throw new NotFoundException("Operation Type not found.");
    }
}
