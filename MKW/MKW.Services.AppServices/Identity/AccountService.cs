using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MKW.Domain.Dto.Base;
using MKW.Domain.Dto.Identity;
using MKW.Domain.Entities.Identity;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using MKW.Domain.Interface.Services.AppServices.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Services.AppServices.Identity
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository<User> _repository;
        private readonly IMapper _mapper;

        public AccountService(UserManager<User> userManager, IUserRepository<User> repository, IMapper mapper)
        {
            _userManager = userManager;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadUserDTO>> GetAllAccounts() => 
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
            var userEntity = _mapper.Map<User>(userDTO);
            var createUser = await _repository.AddUserAsync(userEntity, userDTO.Password);
            
            if (createUser.result.Succeeded)
            {
                //TODO: Add Roles
                var confirmEmailToken = _userManager.GenerateEmailConfirmationTokenAsync(createUser.user);
                //TODO: encode token
                string encodedConfirmEmailToken = "";
                //TODO: send token by email

                var readUser = _mapper.Map<ReadUserDTO>(createUser.user);
                return (Result.Ok().WithSuccess(encodedConfirmEmailToken), readUser);
            }
            return (Result.Fail("Failed to register user"), null);
        }

        public async Task<(IResultBase, ReadUserDTO)> UpdateAccount(UpdateUserDTO userDTO)
        {
            var userEntity = _mapper.Map<User>(userDTO);
            var updateUser = await _repository.UpdateUserAsync(userEntity);
            if (updateUser.result.Succeeded)
            {
                var readUser= _mapper.Map<ReadUserDTO>(updateUser.user);
                return (Result.Ok(), readUser);
            }
            return (Result.Fail("Failed to update user"), null);
        }

        public async Task<IResultBase> DeleteAccount(DeleteUserDTO userDTO)
        {
            var userEntity = _mapper.Map<User>(userDTO);
            var deleteUser = await _repository.DeleteUserAsync(userEntity);
            if (deleteUser.Succeeded) return Result.Ok();
            return Result.Fail("Failed to delete user");
        }

        public async Task<IResultBase> DeleteAccountById(int id)
        {
            var deleteUser = await _repository.DeleteUserByIdAsync(id);
            if (deleteUser.Succeeded) return Result.Ok();
            return Result.Fail("Failed to delete user");
        }

        public async Task<IResultBase> DeleteAccountByUserName(string userName)
        {
            var deleteUser = await _repository.DeleteUserByUserNameAsync(userName);
            if (deleteUser.Succeeded) return Result.Ok();
            return Result.Fail("Failed to delete user");
        }
    }
}
