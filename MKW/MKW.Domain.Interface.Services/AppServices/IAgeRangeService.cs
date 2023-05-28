using MKW.Domain.Dto.DTO.AgeRangeDTO;
using MKW.Domain.Dto.DTO.Base;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IAgeRangeService
    {
        Task<BaseResponseDTO<AgeRangeDto>> Get();
    }
}
