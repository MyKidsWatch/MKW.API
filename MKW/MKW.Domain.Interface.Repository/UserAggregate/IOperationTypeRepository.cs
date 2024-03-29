﻿using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.Base;

namespace MKW.Domain.Interface.Repository.UserAggregate
{
    public interface IOperationTypeRepository : IBaseRepository<OperationType>
    {
        Task<OperationType> GetOperationByType(string operationType);
    }
}
