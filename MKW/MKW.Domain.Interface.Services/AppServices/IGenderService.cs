using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.GenderDTO;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IGenderService
    {
        Task<BaseResponseDTO<GenderDto>> Get();
    }
}
