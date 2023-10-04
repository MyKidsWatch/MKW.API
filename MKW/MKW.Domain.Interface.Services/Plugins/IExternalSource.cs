using MKW.Domain.Dto.DTO.ContentDTO;

namespace MKW.Domain.Interface.Services.Plugins
{
    public interface IExternalSource
    {
        Task<ContentDetailsDTO> GetById(string contentId, string language = "pt-br");
        Task<List<ContentListItemDTO>> GetByName(string name, string language = "pt-br");
    }
}
