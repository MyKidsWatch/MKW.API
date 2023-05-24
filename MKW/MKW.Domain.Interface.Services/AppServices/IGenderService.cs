using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.GenderDTO;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Services.AppServices.Base;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IGenderService
    {
        Task<BaseResponseDTO<GenderDto>> Get();
    }
}
