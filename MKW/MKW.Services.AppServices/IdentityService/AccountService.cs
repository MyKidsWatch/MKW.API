using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Dto.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Account;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.AppServices.Identity;
using MKW.Domain.Interface.Services.AppServices.IdentityService;
using MKW.Domain.Interface.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
            IPersonService person,
            IEmailService emailService,
            IRoleService roleService,
            IMapper mapper
            )
        {
            _repository = repository;
            _userTokenRepository = userTokenRepository;
            _personRepository = person;
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
                var user = await _repository.GetUserByIdAsync(id);
                var userResponse = _mapper.Map<ReadUserDTO>(user.user);
                return new BaseResponseDTO<ReadUserDTO>().WithSuccess(userResponse);
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
                var users = await _repository.GetUserByUserNameAsync(userName);
                var userResponse = _mapper.Map<ReadUserDTO>(users.user);
                return new BaseResponseDTO<ReadUserDTO>().WithSuccess(userResponse);
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
                var role = _mapper.Map<IEnumerable<ReadUserDTO>>(await _repository.GetAllUsersByRoleAsync(roleName));
                return new BaseResponseDTO<ReadUserDTO>().WithSuccesses(role);
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
                var result = _mapper.Map<IEnumerable<ReadUserDTO>>(await _repository.GetAllUsersByClaimAsync(claim));
                return new BaseResponseDTO<ReadUserDTO>().WithSuccesses(result);
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
                var userResponseDTO = new BaseResponseDTO<ReadUserDTO>();
                var userEntity = _mapper.Map<ApplicationUser>(userDTO);
                var createUser = await _repository.AddUserAsync(userEntity, userDTO.Password);

                if (createUser.result.Succeeded)
                {
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

                    var personDetails = _mapper.Map<Person>(userDTO.PersonDetails);
                    personDetails.UserId = createUser.user.Id;
                    personDetails.Active = false;
                    //await _personRepository.Add(personDetails);
                    return userResponseDTO.WithSuccess(userResponse);
                }
                return userResponseDTO.WithErrors(getErros(createUser.result.Errors));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BaseResponseDTO<ReadUserDTO>> UpdateAccountAsync (int id, UpdateUserDTO userDTO)
        {
            try
            {
                var userEntity = _mapper.Map<ApplicationUser>(userDTO);
                var updateUser = await _repository.UpdateUserAsync(id, userEntity);
                if (updateUser.result.Succeeded)
                {
                    var readUser= _mapper.Map<ReadUserDTO>(updateUser.user);
                    return new BaseResponseDTO<ReadUserDTO>().WithSuccess(readUser);
                }
                return new BaseResponseDTO<ReadUserDTO>().WithErrors(getErros(updateUser.result.Errors));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<object>> DeleteAccountByIdAsync (int id)
        {
            try
            {
                var deleteUser = await _repository.DeleteUserByIdAsync(id);
                return deleteUser.Succeeded ?
                    new BaseResponseDTO<object>() :
                    new BaseResponseDTO<object>().WithErrors(getErros(deleteUser.Errors));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<object>> DeleteAccountByUserNameAsync (string userName)
        {
            try
            {
                var deleteUser = await _repository.DeleteUserByUserNameAsync(userName);
                return deleteUser.Succeeded ? 
                    new BaseResponseDTO<object>() :
                    new BaseResponseDTO<object>().WithErrors(getErros(deleteUser.Errors));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<Object>> ConfirmAccountEmailAsync (ConfirmAccountEmailDTO activationRequest)
        {
            try
            {
                var responseDTO = new BaseResponseDTO<Object>();

                var getToken = await _userTokenRepository.GetUserTokenAsync(activationRequest.UserId, activationRequest.Keycode);
                if (getToken.result.IsSuccess)
                {
                    var confirmEmail = await _repository.ConfirmAccountEmailAsync(activationRequest.UserId, getToken.userToken.Token);
                    if (confirmEmail.IsSuccess)
                    {
                        await _userTokenRepository.DeleteUserTokenAsync(activationRequest.UserId, activationRequest.Keycode);
                        var getUser = await _repository.GetUserByIdAsync(activationRequest.UserId);
                        var lockoutResult = await _repository.SetUserLockoutEndDateAsync(getUser.user, DateTimeOffset.MinValue);
                        if (lockoutResult.IsSuccess)
                        {
                            return responseDTO.WithSuccess(lockoutResult.Reasons);
                        }
                        return responseDTO.WithErrors(getErros(lockoutResult.Reasons));
                    }                
                    return responseDTO.WithErrors(getErros(confirmEmail.Reasons));
                }
                return responseDTO.WithErrors(getErros(getToken.result.Reasons));
            }
            catch (Exception ex )
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<object>> CheckUserNameAsync(string username)
        {
            try
            {
                var checkUserName = await _repository.GetUserByUserNameAsync(username);
                return checkUserName.result.IsSuccess ?
                    new BaseResponseDTO<Object>().WithSuccess(new { isUsernameValid = true }) :
                    new BaseResponseDTO<Object>().WithErrors(getErros(checkUserName.result.Reasons));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<object>> CheckEmailAsync(string username)
        {
            try
            {
                var checkUserName = await _repository.GetUserByUserNameAsync(username);
                return checkUserName.result.IsSuccess ?
                    new BaseResponseDTO<Object>().WithSuccess(new { isEmailValid = true }) :
                    new BaseResponseDTO<Object>().WithErrors(getErros(checkUserName.result.Reasons));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<object>> RequestPasswordKeycodeAsync(RequestPasswordKeycodeDTO request)
        {
            try
            {
                var responseDTO = new BaseResponseDTO<Object>();

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
                            return responseDTO.WithSuccess(new { isKeycodeSend = true });
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

        public async Task<BaseResponseDTO<object>> ResetPasswordAsync(ResetPasswordDTO request)
        {
            try
            {
                var responseDTO = new BaseResponseDTO<Object>();

                var getUser = await _repository.GetUserByEmailAsync(request.Email);
                if (getUser.result.IsSuccess)
                {
                    var getToken = await _userTokenRepository.GetUserTokenAsync(getUser.user.Id, request.KeyCode);
                    if (getToken.result.IsSuccess)
                    {
                        var resetPassword = await _repository.ResetPasswordAsync(getUser.user, getToken.userToken.Token, request.Password);
                        if (resetPassword.Succeeded)
                        {
                            _userTokenRepository.DeleteUserTokenAsync(getUser.user.Id, request.KeyCode);
                            return responseDTO.WithSuccess(new { isPasswordReseted = true });
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

        private IEnumerable<string> getErros (IEnumerable<IdentityError> ErrorList)
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
