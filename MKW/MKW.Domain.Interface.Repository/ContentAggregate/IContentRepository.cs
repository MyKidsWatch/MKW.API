﻿using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Interface.Repository.Base;

namespace MKW.Domain.Interface.Repository.ContentAggregate
{
    /// <summary>
    /// Repositório para a entidade Content. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public interface IContentRepository : IBaseRepository<Content>
    {
        Task<Content?> GetContentByExternalId(string externalId, int? platformId = null);
        Task<IEnumerable<Content?>> GetContentsByExternalId(IEnumerable<string> externalIds, int? platformId = null);
    }
}
