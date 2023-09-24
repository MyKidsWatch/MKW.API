using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ContentDTO;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Interface.Repository.ContentAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Domain.Interface.Services.Plugins;
using MKW.Domain.Utility.Enums;
using MKW.Domain.Utility.Exceptions;
using Serilog;

namespace MKW.Services.AppServices
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IPlatformCategoryRepository _platformCategoryRepository;
        private readonly ITmdbService _tmdbService;
        private readonly IDictionary<string, IExternalSource> _sources;

        public ContentService(IContentRepository contentService, IDictionary<string, IExternalSource> sources, IPlatformCategoryRepository platformCategoryRepository)
        {
            _contentRepository = contentService;
            _sources = sources;
            _platformCategoryRepository = platformCategoryRepository;
        }

        public async Task<ContentDetailsDTO> GetContentDetailsByExternalId(string externalId, int platformId = 1, string language = "pt-br")
        {
            var contentDetails = platformId switch
            {
                (int)PlatformEnum.TMDb => await _sources["TMDb"].GetById(externalId, language),
                (int)PlatformEnum.Youtube => await _sources["YouTube"].GetById(externalId, language),
                (int)PlatformEnum.TikTok => await _sources["TikTok"].GetById(externalId, language),
                _ => null,
            } ?? throw new NotFoundException("Content not found");

            var content = await _contentRepository.GetContentByExternalId(externalId);

            return content == null ? contentDetails : contentDetails.AddContent(content);
        }

        public async Task<BaseResponseDTO<ContentListItemDTO>> GetContentByName(string query, int? platformId, string language = "pt-br")
        {
            var content =
                (platformId == null
                ? _sources.SelectMany(x =>
                {
                    try
                    {
                        return x.Value.GetByName(query, language).Result!;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Error while fetching external content from {platform}", x.Key);
                        return new List<ContentListItemDTO>();
                    }
                }).ToList()
                : platformId switch
                {
                    (int)PlatformEnum.TMDb => await _sources["TMDb"].GetByName(query, language),
                    (int)PlatformEnum.Youtube => await _sources["YouTube"].GetByName(query, language),
                    (int)PlatformEnum.TikTok => await _sources["TikTok"].GetByName(query, language),
                    _ => null,
                }) ?? throw new NotFoundException("Content not found");

            return new BaseResponseDTO<ContentListItemDTO>().AddContent(content);
        }

        public async Task<BaseResponseDTO<ContentDetailsDTO>> GetContentDetailsById(int id, string language = "pt-br")
        {
            var content = await GetContentById(id);

            var contentDetails = (await GetContentDetailsByExternalId(content.ExternalId, content.PlatformCategory.PlatformId, language)).AddContent(content);

            return new BaseResponseDTO<ContentDetailsDTO>().AddContent(contentDetails);
        }

        public async Task<Content> GetContentById(int id) => await _contentRepository.GetById(id) ?? throw new NotFoundException("Content not found");


        public async Task<Content> GetContentByExternalId(string externalId, int platformId = 1, string language = "pt-br")
        {
            var content = await _contentRepository.GetContentByExternalId(externalId);

            if (content != null) return content;

            var contentDto = await GetContentDetailsByExternalId(externalId, platformId, language);

            if (contentDto == null) return null;

            var platformCategory = await _platformCategoryRepository.GetByPlatformId(platformId);

            var createContent = new Content()
            {
                PlatformCategoryId = platformCategory.Id,
                ExternalId = externalId,
                Name = contentDto.Name
            };

            return await _contentRepository.Add(createContent);
        }
    }
}
