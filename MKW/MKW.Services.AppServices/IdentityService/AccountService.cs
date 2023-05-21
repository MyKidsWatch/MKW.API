using AutoMapper;
using FluentResults;
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
                var user = await _repository.GetUserByIdAsync(id);
                if (user.result.IsSuccess)
                {
                    var userResponse = _mapper.Map<ReadUserDTO>(user.user);
                    return response.AddContent(userResponse);
                }
                return response.AddError("User not found!");
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
                var user = await _repository.GetUserByUserNameAsync(userName);
                if (user.result.IsSuccess)
                {
                    var userResponse = _mapper.Map<ReadUserDTO>(user.user);
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

        public async Task<BaseResponseDTO<ReadUserDTO>> RegisterAccountAsync(CreateUserDTO userDTO)
        {
            try
            {
                //TODO: EARLY RETURN / NEVER NESTER / 3 LEVEL MAX
                var userResponseDTO = new BaseResponseDTO<ReadUserDTO>();
                var userEntity = _mapper.Map<ApplicationUser>(userDTO);
                var createUser = await _repository.AddUserAsync(userEntity, userDTO.Password);

                if (!createUser.result.Succeeded) return userResponseDTO.WithErrors(getErros(createUser.result.Errors));
              
                await _roleService.AddUserToRoleAsync("standard", createUser.user.UserName);
                var userResponse = _mapper.Map<ReadUserDTO>(createUser.user);
                var confirmEmailToken = await _repository.GenerateEmailConfirmationTokenAsync(createUser.user);
                if (confirmEmailToken.result.IsSuccess)
                {
                    var resultKeycode = await _userTokenRepository.AddUserTokenAsync(createUser.user.Id, confirmEmailToken.token);

                    if (resultKeycode.result.IsSuccess)
                    {
                        var keycode = resultKeycode.keycode;
                        _emailService.sendConfirmAccountEmail(new[] { createUser.user.Email }, "Código de Ativacão", keycode.ToString());
                        userResponse.isConfirmEmailTokenSent = true;
                    }
                    else
                    {
                        userResponse.isConfirmEmailTokenSent = false;
                    }
                }
                else
                {
                    userResponse.isConfirmEmailTokenSent = false;
                    userResponseDTO.WithErrors(getErros(confirmEmailToken.result.Reasons));
                }

                userResponse.AssociatedWithPerson = await CreateAssociatedPerson(userDTO.PersonDetails, createUser.user);
                return userResponseDTO.AddContent(userResponse);
   
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<ReadUserDTO>> UpdateAccountAsync(int id, UpdateUserDTO userDTO)
        {
            try
            {
                var response = new BaseResponseDTO<ReadUserDTO>();
                var userEntity = _mapper.Map<ApplicationUser>(userDTO);
                var updateUser = await _repository.UpdateUserAsync(id, userEntity);
                if (updateUser.result.Succeeded)
                {
                    var readUser = _mapper.Map<ReadUserDTO>(updateUser.user);
                    return response.AddContent(readUser);
                }
                return response.WithErrors(getErros(updateUser.result.Errors));
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
                return deleteUser.Succeeded ? response : response.WithErrors(getErros(deleteUser.Errors));
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
                return deleteUser.Succeeded ? response : response.WithErrors(getErros(deleteUser.Errors));
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
                if (getToken.result.IsSuccess)
                {
                    var confirmEmail = await _repository.ConfirmAccountEmailAsync(activationRequest.UserId, getToken.userToken.Token);
                    if (confirmEmail.IsSuccess)
                    {
                        var excludeToken = await _userTokenRepository.DeleteUserTokenAsync(activationRequest.UserId, activationRequest.Keycode);
                        var (result, user) = await _repository.GetUserByIdAsync(activationRequest.UserId);
                        return responseDTO.AddContent(_mapper.Map<ReadUserDTO>(user));
                    }
                    return responseDTO.WithErrors(getErros(confirmEmail.Reasons));
                }
                return responseDTO.WithErrors(getErros(getToken.result.Reasons));
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

        public async Task<BaseResponseDTO<ResponseGenerateKeycodeDTO>> RequestEmailKeycodeAsync(RequestKeycodeDTO request)
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
                        _emailService.sendConfirmAccountEmail(new[] { request.Email }, "Código de Ativacão", keycode.ToString());
                        return responseDTO.AddContent(new ResponseGenerateKeycodeDTO(true));
                    }
                    return responseDTO.WithErrors(getErros(result.Reasons));
                }
                return responseDTO.WithErrors(getErros(getUserResult.Reasons));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<BaseResponseDTO<ResponseGenerateKeycodeDTO>> RequestPasswordKeycodeAsync(RequestKeycodeDTO request)
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
                            _emailService.sendRecoveryPasswordEmail(new[] { request.Email }, "Recuperacao de Senha", keycode.ToString());
                            return responseDTO.AddContent(new ResponseGenerateKeycodeDTO(true));
                        }
                        return responseDTO.WithErrors(getErros(generateKeycode.result.Reasons));
                    }
                    return responseDTO.WithErrors(getErros(getUser.result.Reasons));
                }
                return responseDTO.WithErrors(getErros(recoveryResult.result.Reasons));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<BaseResponseDTO<ReadUserDTO>> ResetPasswordAsync(ResetPasswordDTO request)
        {
            try
            {
                var responseDTO = new BaseResponseDTO<ReadUserDTO>();

                var getUser = await _repository.GetUserByEmailAsync(request.Email);
                if (getUser.result.IsSuccess)
                {
                    var getToken = await _userTokenRepository.GetUserTokenAsync(getUser.user.Id, request.KeyCode);
                    if (getToken.result.IsSuccess)
                    {
                        var resetPassword = await _repository.ResetPasswordAsync(getUser.user, getToken.userToken.Token, request.Password);
                        if (resetPassword.Succeeded)
                        {
                            await _userTokenRepository.DeleteUserTokenAsync(getUser.user.Id, request.KeyCode);
                            var (result, user) = await _repository.GetUserByIdAsync(getUser.user.Id);
                            return responseDTO.AddContent(_mapper.Map<ReadUserDTO>(user));
                        }
                        return responseDTO.WithErrors(getErros(resetPassword.Errors));
                    }
                    return responseDTO.WithErrors(getErros(getToken.result.Reasons));
                }
                return responseDTO.WithErrors(getErros(getUser.result.Reasons));
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        private IEnumerable<string> getErros(IEnumerable<IdentityError> ErrorList)
        {
            var errorList = new List<string>();

            foreach (IdentityError error in ErrorList)
            {
                errorList.Add($"{error.Code}: {error.Description}");
            }

            return errorList;
        }

        private IEnumerable<string> getErros(List<IReason> ErrorList)
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
