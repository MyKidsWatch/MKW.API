using MKW.Domain.Entities.ContentAggregate;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IContentService
    {
        Task<Content> GetContentByExternalId(string externalId, int? platformId = 1);
        Task<Content> GetContentById(int id);
    }
}
