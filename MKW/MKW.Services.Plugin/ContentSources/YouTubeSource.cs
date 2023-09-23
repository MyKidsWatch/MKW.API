using MKW.Domain.Dto.DTO.ContentDTO;
using MKW.Domain.Interface.Services.Plugins;

namespace MKW.Services.Plugin.ContentSources
{
    public class YouTubeSource : IExternalSource
    {
        public async Task<ContentDetailsDTO> GetById(string contentId, string language = "pt-br")
        {
            throw new NotImplementedException();
        }

        public async Task<List<ContentListItemDTO>> GetByName(string name, string language = "pt-br")
        {
            throw new NotImplementedException();
        }
    }
}
