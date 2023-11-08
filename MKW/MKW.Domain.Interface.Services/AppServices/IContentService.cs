using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ContentDTO;
using MKW.Domain.Entities.ContentAggregate;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IContentService
    {
        Task<ContentDetailsDTO> GetContentDetailsByExternalId(string externalId, int platformId = 1, string language = "pt-br");
        Task<ContentDetailsDTO> GetExternalContent(string externalId, int platformId = 1, string language = "pt-br");
        Task<Content> GetContentByExternalId(string externalId, int platformId = 1, string language = "pt-br");
        Task<Content> GetContentById(int id);
        Task<BaseResponseDTO<ContentDetailsDTO>> GetContentDetailsById(int id, string language = "pt-br");
        Task<BaseResponseDTO<ContentListItemDTO>> GetContentByName(string query, int? platformId, string language = "pt-br");
    }
}
