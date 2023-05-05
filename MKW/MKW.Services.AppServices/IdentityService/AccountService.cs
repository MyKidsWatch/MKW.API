using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Dto.IdentityDTO;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.AppServices.Identity;
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
        private readonly IMapper _mapper;

        public AccountService(UserManager<ApplicationUser> userManager, IUserRepository repository, IMapper mapper)
        {
            _userManager = userManager;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadUserDTO>?> GetAllAccounts() => 
            _mapper.Map<IEnumerable<ReadUserDTO>>(await _repository.GetAllUsersAsync());
        public async Task<IEnumerable<ReadUserDTO>> GetActiveAccounts() =>
            _mapper.Map<IEnumerable<ReadUserDTO>>(await _repository.GetActiveUsersAsync());
        public async Task<ReadUserDTO?> GetAccountByUserId(int id) => 
            _mapper.Map<ReadUserDTO>(await _repository.GetUserByIdAsync(id));
        public async Task<ReadUserDTO?> GetAccountByUserName(string userName) =>
            _mapper.Map<ReadUserDTO>(await _repository.GetUserByUserNameAsync(userName));
        public async Task<IEnumerable<ReadUserDTO>> GetAllAccountsByRole(string roleName) => 
            _mapper.Map<IEnumerable<ReadUserDTO>>(await _repository.GetAllUsersByRoleAsync(roleName));
        public async Task<IEnumerable<ReadUserDTO>> GetAllAccountsByClaim(Claim claim) => 
            _mapper.Map<IEnumerable<ReadUserDTO>>(await _repository.GetAllUsersByClaimAsync(claim));
        
        public async Task<(IResultBase, ReadUserDTO?)> RegisterAccount(CreateUserDTO userDTO)
        {
            var userEntity = _mapper.Map<ApplicationUser>(userDTO);
            var createUser = await _repository.AddUserAsync(userEntity, userDTO.Password);

            if (createUser.result.Succeeded)
            {
                //TODO: Add Roles to user
                var confirmEmailToken = _userManager.GenerateEmailConfirmationTokenAsync(createUser.user);
                if (confirmEmailToken.IsCompleted)
                {
                    string encodedConfirmEmailToken = HttpUtility.UrlEncode(confirmEmailToken.Result);
                    //TODO: send token by email
                    var userResponse = _mapper.Map<ReadUserDTO>(createUser.user);
                    userResponse.confirmEmailToken = encodedConfirmEmailToken;

                    return (Result.Ok(), userResponse);
                }

                //var personDetails = _mapper.Map<Person>(userDTO.PersonDetails);
                //personDetails.UserId = createUser.user.Id;
                //personDetails.Active = false;
                return (Result.Ok(), _mapper.Map<ReadUserDTO>(createUser.user));
            }

            var errorList = new List<string>();

            foreach(IdentityError error in createUser.result.Errors)
            {
                errorList.Add($"{error.Code}: {error.Description}");
            }

            return (Result.Fail("Failed to register user").WithErrors(errorList), null);
        }

        public async Task<(IResultBase, ReadUserDTO)> UpdateAccount(int id, UpdateUserDTO userDTO)
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

        public async Task<IResultBase> DeleteAccountById(int id)
        {
            var deleteUser = await _repository.DeleteUserByIdAsync(id);
            if (deleteUser.Succeeded) return Result.Ok();
            return Result.Fail($"Failed to delete user by id: {id}");
        }

        public async Task<IResultBase> DeleteAccountByUserName(string userName)
        {
            var deleteUser = await _repository.DeleteUserByUserNameAsync(userName);
            if (deleteUser.Succeeded) return Result.Ok();
            return Result.Fail($"Failed to delete user by userName: {userName}");
        }
    }
}
