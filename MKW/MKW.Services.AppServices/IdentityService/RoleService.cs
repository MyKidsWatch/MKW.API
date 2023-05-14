using FluentResults;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Dto.Base;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using MKW.Domain.Interface.Services.AppServices.IdentityService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Services.AppServices.IdentityService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponseDTO<object>> AddRoleAsync(string role)
        {
            var result = await _repository.AddRoleAsync(role);
            return result.Succeeded ? 
                new BaseResponseDTO<object>() : 
                new BaseResponseDTO<object>().WithErrors(getErros(result.Errors));
        }

        public async Task<BaseResponseDTO<object>> AddUserToRoleAsync(string roleName, ApplicationUser user)
        {
            var result = await _repository.AddUserToRoleAsync(roleName, user);
            return result.Succeeded ?
                new BaseResponseDTO<object>() :
                new BaseResponseDTO<object>().WithErrors(getErros(result.Errors));
        }

        public Task<BaseResponseDTO<object>> DeleteRoleAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseDTO<object>> DeleteUserFromRoleAsync(string roleName, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseDTO<object>> GetRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseDTO<object>> UpdateRoleAsync(string oldRoleName, string newRoleName)
        {
            throw new NotImplementedException();
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
    }
}
