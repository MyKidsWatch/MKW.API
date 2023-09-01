using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Interface.Repository.ContentAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.BaseServices;

namespace MKW.Services.AppServices
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;
        private readonly ITmdbService _tmdbService;

        public ContentService(IContentRepository contentService)
        {
            _contentRepository = contentService;
        }

        public async Task<Content> GetContentByExternalId(string externalId, int? platformId = 1)
        {
            var content = await _contentRepository.GetContentByExternalId(externalId);

            if (content != null) return content;

            var movie = await _tmdbService.GetMovie(Int32.Parse(externalId));

            var createContent = new Content()
            {
                PlatformCategoryId = 1,
                ExternalId = externalId,
            };

            return await _contentRepository.Add(createContent);
        }

        public async Task<Content> GetContentById(int id) => await _contentRepository.GetById(id);
    }
}
