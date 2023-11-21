using AutoMapper;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.PersonDTO;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Utility.Exceptions;
using Org.BouncyCastle.Asn1.Ocsp;

namespace MKW.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPersonService _personService;

        public ProfileService(IPersonRepository personRepository, IMapper mapper, IUserRepository userRepository, IPersonService personService)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _personService = personService;
        }

        public async Task<BaseResponseDTO<ReadProfileDTO>> GetProfileByUsername(string username)
        {
            var responseDTO = new BaseResponseDTO<ReadProfileDTO>();

            var (result, user) = await _userRepository.GetUserByUserNameAsync(username);
            if (result.IsFailed) throw new NotFoundException("user not found");

            var person = await _personRepository.GetByEmail(user.Email);

            var readProfileDTO = _mapper.Map<ReadProfileDTO>(person);
            readProfileDTO = _mapper.Map(user, readProfileDTO);

            return responseDTO.AddContent(readProfileDTO);
        }

        public async Task<BaseResponseDTO<IEnumerable<ReadProfileDTO>>> GetAllProfilesByUsername(string username)
        {
            var responseDTO = new BaseResponseDTO<IEnumerable<ReadProfileDTO>>();

            var users = await _userRepository.GetAllUsersByUsernameAsync(username);
            if (!users.Any()) throw new NotFoundException("no users found");

            var profiles = new List<ReadProfileDTO>();
            foreach (var user in users)
            {
                var person = await _personRepository.GetByEmail(user.Email);
                var readProfile = _mapper.Map<ReadProfileDTO>(person);
                readProfile = _mapper.Map(user, readProfile);
                profiles.Add(readProfile);
            }

            var readProfileDTOs = profiles;
            return responseDTO.AddContent(readProfileDTOs);
        }

        public async Task<BaseResponseDTO<ReadProfileDTO>> UpdateProfilePicture(UpdateProfilePictureDto model)
        {
            var responseDTO = new BaseResponseDTO<ReadProfileDTO>();

            var person = await _personService.GetUser();

            person.ImageURL = model.ImageName;

            await _personRepository.Update(person);

            var readProfile = _mapper.Map<ReadProfileDTO>(person);
            readProfile = _mapper.Map(person.User, readProfile);

            return responseDTO.AddContent(readProfile);

        }

    }
}