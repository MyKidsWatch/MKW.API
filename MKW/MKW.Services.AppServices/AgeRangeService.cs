using MKW.Domain.Dto.DTO.AgeRangeDTO;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;

namespace MKW.Services.AppServices
{
    public class AgeRangeService : IAgeRangeService
    {
        private readonly IAgeRangeRepository _ageRangeRepository;
        public AgeRangeService(IAgeRangeRepository ageRangeRepository)
        {
            _ageRangeRepository = ageRangeRepository;
        }

        public async Task<BaseResponseDTO<AgeRangeDto>> Get()
        {
            var ageRanges = await _ageRangeRepository.GetActive();

            return new BaseResponseDTO<AgeRangeDto>().AddContent(ageRanges.Select(x => new AgeRangeDto(x)));
        }
    }
}
