using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Account;
using MKW.Domain.Dto.DTO.PersonDTO;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.AppServices.IdentityService;
using MKW.Domain.Interface.Services.BaseServices;
using System.Security.Claims;

namespace MKW.Services.AppServices.IdentityService
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _repository;
        private readonly IUserTokenRepository _userTokenRepository;
        private readonly IPersonService _personRepository;
        private readonly IEmailService _emailService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public AccountService
            (
            IUserRepository repository,
            IUserTokenRepository userTokenRepository,
            IPersonService personService,
            IEmailService emailService,
            IRoleService roleService,
            IMapper mapper
            )
        {
            _repository = repository;
            _userTokenRepository = userTokenRepository;
            _personRepository = personService;
            _emailService = emailService;
            _mapper = mapper;
            _roleService = roleService;
        }

        public async Task<BaseResponseDTO<ReadUserDTO>> GetAllAccountsAsync()
        {
            try
            {
                var users = _mapper.Map<IEnumerable<ReadUserDTO>>(await _repository.GetAllUsersAsync());
                return new BaseResponseDTO<ReadUserDTO>().WithSuccesses(users);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<ReadUserDTO>> GetActiveAccountsAsync()
        {
            try
            {
                var users = _mapper.Map<IEnumerable<ReadUserDTO>>(await _repository.GetActiveUsersAsync());
                return new BaseResponseDTO<ReadUserDTO>().WithSuccesses(users);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<ReadUserDTO>> GetAccountByUserIdAsync(int id)
        {
            try
            {
                var response = new BaseResponseDTO<ReadUserDTO>();
                var (result, user) = await _repository.GetUserByIdAsync(id);
                if (result.IsFailed) return response.AddError("User not found!");

                var userResponse = _mapper.Map<ReadUserDTO>(user);
                userResponse.AssociatedWithPerson = await GetAssociatedPerson(user);
                return response.AddContent(userResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<ReadUserDTO>> GetAccountByUserNameAsync(string userName)
        {
            try
            {
                var response = new BaseResponseDTO<ReadUserDTO>();
                var (result, user) = await _repository.GetUserByUserNameAsync(userName);
                if (result.IsSuccess)
                {
                    var userResponse = _mapper.Map<ReadUserDTO>(user);
                    userResponse.AssociatedWithPerson = await GetAssociatedPerson(user);
                    return response.AddContent(userResponse);
                }
                return response.AddError("User not found!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<ReadUserDTO>> GetAllAccountsByRoleAsync(string roleName)
        {
            try
            {
                var response = new BaseResponseDTO<ReadUserDTO>();
                //TODO: Test if role exists
                var role = await _roleService.GetRolesByNameAsync(roleName);
                if (role.IsSuccess)
                {
                    var getUsers = await _repository.GetAllUsersByRoleAsync(roleName);
                    var users = _mapper.Map<IEnumerable<ReadUserDTO>>(getUsers);
                    return response.WithSuccesses(users);
                }
                return response.AddError("Role not exists!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<BaseResponseDTO<ReadUserDTO>> GetAllAccountsByClaimAsync(Claim claim)
        {
            try
            {
                var response = new BaseResponseDTO<ReadUserDTO>();
                //TODO: Test if claim exists
                var getUsers = await _repository.GetAllUsersByClaimAsync(claim);
                if (true)
                {
                    var result = _mapper.Map<IEnumerable<ReadUserDTO>>(getUsers);
                    return response.WithSuccesses(result);
                }
                return response.AddError("Claim not found!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<BaseResponseDTO<ReadUserDTO>> GetAccountByTokenAsync(HttpContext httpContext)
        {
            try
            {
                var responseDTO = new BaseResponseDTO<ReadUserDTO>();

                var claims = httpContext.User.Identity as ClaimsIdentity;
                var userId = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                var (result, user) = await _repository.GetUserByIdAsync(int.Parse(userId));
                if (result.IsFailed) return responseDTO.WithErrors(GetErros(result.Reasons));

                var readUser = _mapper.Map<ReadUserDTO>(user);
                readUser.IsAdminUser = await IsAdminUser(user);
                readUser.AssociatedWithPerson = await GetAssociatedPerson(user);

                return responseDTO.AddContent(readUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<ReadUserDTO>> RegisterAccountAsync(CreateUserDTO userDTO, string language = "pt-br")
        {
            try
            {
                var userResponseDTO = new BaseResponseDTO<ReadUserDTO>();
                var applicationUser = _mapper.Map<ApplicationUser>(userDTO);

                var (result, user) = await _repository.AddUserAsync(applicationUser, userDTO.Password);
                if (!result.Succeeded) return userResponseDTO.WithErrors(GetErros(result.Errors));

                var role = await _roleService.AddUserToRoleAsync("standard", user.UserName);
                if (role is null) userResponseDTO.AddError("role not assign to user");

                var (isEmailSent, emailErrors) = await SendActiveEmailKeycodeAsync(user, language);
                if (!isEmailSent) userResponseDTO.WithErrors(emailErrors);

                var userResponse = _mapper.Map<ReadUserDTO>(user);
                userResponse.isConfirmEmailTokenSent = isEmailSent;
                userResponse.AssociatedWithPerson = await CreateAssociatedPerson(userDTO.PersonDetails, user);

                return userResponseDTO.AddContent(userResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<ReadUserDTO>> UpdateAccountAsync(HttpContext httpContext, UpdateUserDTO userDTO, string language = "pt-BR")
        {
            try
            {
                var response = new BaseResponseDTO<ReadUserDTO>();
                var applicationUser = _mapper.Map<ApplicationUser>(userDTO);

                var userClaims = httpContext.User.Identity as ClaimsIdentity;
                var userId = int.Parse(httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

                var (result, user) = await _repository.UpdateUserAsync(userId, applicationUser);
                if (!result.Succeeded) return response.WithErrors(GetErros(result.Errors));

                var readUser = _mapper.Map<ReadUserDTO>(user);
                readUser.AssociatedWithPerson = await UpdateAssociatedPerson(userDTO.PersonDetails, user);
                if (user.EmailConfirmed) return response.AddContent(readUser);

                var (isEmailSent, emailErrors) = await SendActiveEmailKeycodeAsync(user, language);
                if (!isEmailSent) response.WithErrors(emailErrors);

                readUser.isConfirmEmailTokenSent = isEmailSent;
                return response.AddContent(readUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<object>> DeleteAccountByIdAsync(int id)
        {
            try
            {
                var response = new BaseResponseDTO<object>();
                var deleteUser = await _repository.DeleteUserByIdAsync(id);
                return deleteUser.Succeeded ? response : response.WithErrors(GetErros(deleteUser.Errors));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<object>> DeleteAccountByUserNameAsync(string userName)
        {
            try
            {
                var response = new BaseResponseDTO<object>();
                var deleteUser = await _repository.DeleteUserByUserNameAsync(userName);
                return deleteUser.Succeeded ? response : response.WithErrors(GetErros(deleteUser.Errors));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<ReadUserDTO>> ConfirmAccountEmailAsync(ConfirmAccountEmailDTO activationRequest)
        {
            try
            {
                var responseDTO = new BaseResponseDTO<ReadUserDTO>();

                var getToken = await _userTokenRepository.GetUserTokenAsync(activationRequest.UserId, activationRequest.Keycode);
                if (getToken.result.IsFailed) return responseDTO.WithErrors(GetErros(getToken.result.Reasons));

                var confirmEmail = await _repository.ConfirmAccountEmailAsync(activationRequest.UserId, getToken.userToken.Token);
                if (confirmEmail.IsFailed) return responseDTO.WithErrors(GetErros(confirmEmail.Reasons));

                var excludeToken = await _userTokenRepository.DeleteUserTokenAsync(activationRequest.UserId, activationRequest.Keycode);
                var (result, user) = await _repository.GetUserByIdAsync(activationRequest.UserId);
                return responseDTO.AddContent(_mapper.Map<ReadUserDTO>(user));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<CheckUserNameDTO>> CheckUserNameAsync(string username)
        {
            try
            {
                var response = new BaseResponseDTO<CheckUserNameDTO>();
                var (result, user) = await _repository.GetUserByUserNameAsync(username);
                return result.IsSuccess ?
                    response.AddContent(new CheckUserNameDTO(!result.IsSuccess), !result.IsSuccess) :
                    response.AddContent(new CheckUserNameDTO(!result.IsSuccess));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<CheckEmailDTO>> CheckEmailAsync(string username)
        {
            try
            {
                var response = new BaseResponseDTO<CheckEmailDTO>();
                var (result, user) = await _repository.GetUserByEmailAsync(username);
                return result.IsSuccess ?
                    response.AddContent(new CheckEmailDTO(!result.IsSuccess), !result.IsSuccess) :
                    response.AddContent(new CheckEmailDTO(!result.IsSuccess));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<ResponseGenerateKeycodeDTO>> RequestEmailKeycodeAsync(RequestKeycodeDTO request, string language = "pt-BR")
        {
            try
            {
                var responseDTO = new BaseResponseDTO<ResponseGenerateKeycodeDTO>();
                var (getUserResult, user) = await _repository.GetUserByEmailAsync(request.Email);
                if (getUserResult.IsSuccess)
                {
                    var (result, token) = await _repository.GenerateEmailConfirmationTokenAsync(user);
                    if (result.IsSuccess)
                    {
                        var generateKeycode = await _userTokenRepository.AddUserTokenAsync(user.Id, token);
                        var keycode = generateKeycode.keycode;
                        _emailService.SendConfirmAccountEmail(new[] { request.Email }, keycode.ToString(), language);
                        return responseDTO.AddContent(new ResponseGenerateKeycodeDTO(true));
                    }
                    return responseDTO.WithErrors(GetErros(result.Reasons));
                }
                return responseDTO.WithErrors(GetErros(getUserResult.Reasons));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<BaseResponseDTO<ResponseGenerateKeycodeDTO>> RequestPasswordKeycodeAsync(RequestKeycodeDTO request, string language = "pt-BR")
        {
            try
            {
                var responseDTO = new BaseResponseDTO<ResponseGenerateKeycodeDTO>();
                var recoveryResult = await _repository.RequestPasswordKeycodeAsync(request.Email);
                if (recoveryResult.result.IsSuccess)
                {
                    var getUser = await _repository.GetUserByEmailAsync(request.Email);
                    if (getUser.result.IsSuccess)
                    {
                        var generateKeycode = await _userTokenRepository.AddUserTokenAsync(getUser.user.Id, recoveryResult.token);
                        if (generateKeycode.result.IsSuccess)
                        {
                            var keycode = generateKeycode.keycode;
                            _emailService.SendRecoveryPasswordEmail(new[] { request.Email }, keycode.ToString(), language);
                            return responseDTO.AddContent(new ResponseGenerateKeycodeDTO(true));
                        }
                        return responseDTO.WithErrors(GetErros(generateKeycode.result.Reasons));
                    }
                    return responseDTO.WithErrors(GetErros(getUser.result.Reasons));
                }
                return responseDTO.WithErrors(GetErros(recoveryResult.result.Reasons));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<BaseResponseDTO<ReadUserDTO>> ResetPasswordAsync(ResetPasswordDTO request)
        {
            var responseDTO = new BaseResponseDTO<ReadUserDTO>();

            var (result, user) = await _repository.GetUserByEmailAsync(request.Email);
            if (!result.IsSuccess) return responseDTO.WithErrors(GetErros(result.Reasons));

            var (resultToken, userToken) = await _userTokenRepository.GetUserTokenAsync(user.Id, request.KeyCode);
            if (!resultToken.IsSuccess) return responseDTO.WithErrors(GetErros(resultToken.Reasons));

            var resetPassword = await _repository.ResetPasswordAsync(user, userToken.Token, request.Password);
            if (!resetPassword.Succeeded) return responseDTO.WithErrors(GetErros(resetPassword.Errors));

            await _userTokenRepository.DeleteUserTokenAsync(user.Id, request.KeyCode);

            var getUser = await _repository.GetUserByIdAsync(user.Id);
            return responseDTO.AddContent(_mapper.Map<ReadUserDTO>(getUser.user));
        }

        private async Task<bool> IsAdminUser(ApplicationUser user)
        {
            var adminUsers = await _repository.GetAllUsersByRoleAsync("admin");
            var admin = adminUsers.FirstOrDefault(userAdmin => userAdmin.Id == user.Id);
            return admin != null;
        }

        private async Task<(bool isEmailSent, IEnumerable<string> emailErrors)> SendActiveEmailKeycodeAsync(ApplicationUser user, string language = "pt-BR")
        {
            var (result, token) = await _repository.GenerateEmailConfirmationTokenAsync(user);
            if (!result.IsSuccess) return (false, GetErros(result.Reasons));

            var (resultKeycode, keycodeValue) = await _userTokenRepository.AddUserTokenAsync(user.Id, token);
            if (!resultKeycode.IsSuccess) return (false, GetErros(resultKeycode.Reasons));

            _emailService.SendConfirmAccountEmail(new[] { user.Email }, keycodeValue.ToString(), language);

            return (true, GetErros(result.Reasons));
        }

        private async Task<ReadPersonDTO> CreateAssociatedPerson(PersonOnCreateUserDTO PersonDTO, ApplicationUser user)
        {
            var personDetails = _mapper.Map<Person>(PersonDTO);
            personDetails.UserId = user.Id;
            personDetails.Active = true;
            personDetails.UUID = Guid.NewGuid();
            var person = await _personRepository.Add(personDetails);
            return _mapper.Map<ReadPersonDTO>(person);
        }

        private async Task<ReadPersonDTO> GetAssociatedPerson(ApplicationUser user)
        {
            var person = await _personRepository.GetByUserEmail(user.Email);
            return _mapper.Map<ReadPersonDTO>(person);
        }

        private async Task<ReadPersonDTO> UpdateAssociatedPerson(PersonOnCreateUserDTO PersonDTO, ApplicationUser user)
        {
            var personEntity = await _personRepository.GetByUserEmail(user.Email);

            personEntity.BirthDate = PersonDTO.BirthDate;
            personEntity.GenderId = PersonDTO.GenderId;

            var personUpdated = await _personRepository.Update(personEntity);
            return _mapper.Map<ReadPersonDTO>(personUpdated);
        }

        private static IEnumerable<string> GetErros(IEnumerable<IdentityError> ErrorList)
        {
            var errorList = new List<string>();

            foreach (IdentityError error in ErrorList)
            {
                errorList.Add($"{error.Code}: {error.Description}");
            }

            return errorList;
        }

        private static IEnumerable<string> GetErros(List<IReason> ErrorList)
        {
            var errorList = new List<string>();

            foreach (IReason error in ErrorList)
            {
                errorList.Add($"Error Message: {error.Message}");
            }

            return errorList;
        }
    }
}
