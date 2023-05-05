using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Dto.DTO.IdentityDTO.Account;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.AppServices.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _repository;
        private readonly IPersonService _personRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public AccountService(UserManager<ApplicationUser> userManager,
            IUserRepository repository,
            IPersonService person,
            IEmailService emailService,
            IMapper mapper)
        {
            _userManager = userManager;
            _repository = repository;
            _personRepository = person;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadUserDTO>?> GetAllAccountsAsync() => 
            _mapper.Map<IEnumerable<ReadUserDTO>>(await _repository.GetAllUsersAsync());
        public async Task<IEnumerable<ReadUserDTO>> GetActiveAccountsAsync() =>
            _mapper.Map<IEnumerable<ReadUserDTO>>(await _repository.GetActiveUsersAsync());
        public async Task<ReadUserDTO?> GetAccountByUserIdAsync(int id) => 
            _mapper.Map<ReadUserDTO>(await _repository.GetUserByIdAsync(id));
        public async Task<ReadUserDTO?> GetAccountByUserNameAsync(string userName) =>
            _mapper.Map<ReadUserDTO>(await _repository.GetUserByUserNameAsync(userName));
        public async Task<IEnumerable<ReadUserDTO>> GetAllAccountsByRoleAsync(string roleName) => 
            _mapper.Map<IEnumerable<ReadUserDTO>>(await _repository.GetAllUsersByRoleAsync(roleName));
        public async Task<IEnumerable<ReadUserDTO>> GetAllAccountsByClaimAsync(Claim claim) => 
            _mapper.Map<IEnumerable<ReadUserDTO>>(await _repository.GetAllUsersByClaimAsync(claim));
        
        public async Task<(IResultBase, ReadUserDTO?)> RegisterAccountAsync(CreateUserDTO userDTO)
        {
            var userEntity = _mapper.Map<ApplicationUser>(userDTO);
            var createUser = await _repository.AddUserAsync(userEntity, userDTO.Password);

            if (createUser.result.Succeeded)
            {
                //TODO: Add Roles to user
                var confirmEmailToken = _userManager.GenerateEmailConfirmationTokenAsync(createUser.user);
                if (confirmEmailToken.IsCompletedSuccessfully)
                {
                    string encodedConfirmEmailToken = HttpUtility.UrlEncode(confirmEmailToken.Result);
                    //TODO: send token by email
                    var userResponse = _mapper.Map<ReadUserDTO>(createUser.user);
                    userResponse.confirmEmailToken = confirmEmailToken.Result;

                    _emailService.sendEmail(new[] { createUser.user.Email }, "Link de Ativacão", createUser.user.Id, encodedConfirmEmailToken);

                    //var personDetails = _mapper.Map<Person>(userDTO.PersonDetails);
                    //personDetails.UserId = createUser.user.Id;
                    //personDetails.Active = false;

                    //_personRepository.Add(personDetails);

                    return (Result.Ok(), userResponse);
                }

                return (Result.Ok(), _mapper.Map<ReadUserDTO>(createUser.user));
            }

            return (Result.Fail("Failed to register user").WithErrors(getIdentityErros(createUser.result.Errors)), null);
        }

        public async Task<IResultBase> ConfirmAccountEmailAsync (ConfirmAccountEmailDTO ActivationRequest)
        {
            var user = await _userManager.FindByIdAsync(ActivationRequest.UserId.ToString());
            var IdentitResult = await _userManager.ConfirmEmailAsync(user, ActivationRequest.ActivationToken);
            if (IdentitResult.Succeeded) return Result.Ok();
            return Result.Fail("Failed to active e-mail").WithErrors(getIdentityErros(IdentitResult.Errors));
        }
        

        public async Task<(IResultBase, ReadUserDTO)> UpdateAccountAsync (int id, UpdateUserDTO userDTO)
        {
            var userEntity = _mapper.Map<ApplicationUser>(userDTO);
            var updateUser = await _repository.UpdateUserAsync(id, userEntity);
            if (updateUser.result.Succeeded)
            {
                var readUser= _mapper.Map<ReadUserDTO>(updateUser.user);
                return (Result.Ok(), readUser);
            }
            return (Result.Fail("Failed to update user"), null);
        }

        public async Task<IResultBase> DeleteAccountByIdAsync (int id)
        {
            var deleteUser = await _repository.DeleteUserByIdAsync(id);
            if (deleteUser.Succeeded) return Result.Ok();
            return Result.Fail($"Failed to delete user by id: {id}");
        }

        public async Task<IResultBase> DeleteAccountByUserNameAsync (string userName)
        {
            var deleteUser = await _repository.DeleteUserByUserNameAsync(userName);
            if (deleteUser.Succeeded) return Result.Ok();
            return Result.Fail($"Failed to delete user by userName: {userName}");
        }

        private IEnumerable<string> getIdentityErros (IEnumerable<IdentityError> identityErrorList)
        {
            var errorList = new List<string>();

            foreach (IdentityError error in identityErrorList)
            {
                errorList.Add($"{error.Code}: {error.Description}");
            }

            return errorList;
        }
    }
}
