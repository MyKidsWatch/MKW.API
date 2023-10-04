using MKW.Domain.Dto.DTO.AwardDTO;
using MKW.Domain.Dto.DTO.Base;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IAwardService
    {
        Task<BaseResponseDTO<GivenAwardDto>> AddAward(GiveAwardDto model);
        Task<BaseResponseDTO<AwardDetailsDto>> GetAwards();
    }
}