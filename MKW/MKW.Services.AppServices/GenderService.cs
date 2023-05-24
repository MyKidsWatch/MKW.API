using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.GenderDTO;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Utility.Exceptions;

namespace MKW.Services.AppServices
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task<BaseResponseDTO<GenderDto>> Get()
        {
            var genders = await _genderRepository.GetActive();
            if (genders == null) throw new NotFoundException("Nenhum gênero encontrado");

            return new BaseResponseDTO<GenderDto>().AddContent(genders.Select(x => new GenderDto(x)));
        }
    }
}
