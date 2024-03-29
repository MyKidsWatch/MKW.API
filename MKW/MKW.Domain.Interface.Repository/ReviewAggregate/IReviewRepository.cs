﻿using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Interface.Repository.Base;

namespace MKW.Domain.Interface.Repository.ReviewAggregate
{
    /// <summary>
    /// Repositório para a entidade Post. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task<IEnumerable<Review>> GetByUserId(int userId);
    }
}
