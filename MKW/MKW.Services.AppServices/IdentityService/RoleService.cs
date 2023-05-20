using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Authorization;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using MKW.Domain.Interface.Services.AppServices.IdentityService;

namespace MKW.Services.AppServices.IdentityService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository repository, IUserRepository userRepository, IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponseDTO<ReadRoleDTO>> GetRolesByNameAsync(string roleName)
        {
            try
            {
                var response = new BaseResponseDTO<ReadRoleDTO>();
                var (result, roleDb) = await _repository.GetRoleByNameAsync(roleName);
                if (result.Succeeded)
                {
                    var role = _mapper.Map<ReadRoleDTO>(roleDb);
                    return response.AddContent(role);
                }
                return response.WithErrors(GetErros(result.Errors));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<BaseResponseDTO<ReadRoleDTO>> GetAllRolesAsync()
        {
            try
            {
                var response = new BaseResponseDTO<ReadRoleDTO>();
                var roleList = _mapper.Map<IEnumerable<ReadRoleDTO>>(await _repository.GetRolesAsync());
                return response.WithSuccesses(roleList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<ReadRoleDTO>> AddUserToRoleAsync(string roleName, string userName)
        {
            try
            {
                var response = new BaseResponseDTO<ReadRoleDTO>();
                var getUser = await _userRepository.GetUserByUserNameAsync(userName);
                if (getUser.result.IsSuccess)
                {
                    var result = await _repository.AddUserToRoleAsync(roleName, getUser.user);
                    return result.Succeeded ? response : response.WithErrors(GetErros(result.Errors));
                }
                return response.AddError("user not found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<ReadRoleDTO>> RemoveUserFromRoleAsync(string roleName, string userName)
        {
            try
            {
                var response = new BaseResponseDTO<ReadRoleDTO>();
                var getUser = await _userRepository.GetUserByUserNameAsync(userName);
                if (getUser.result.IsSuccess)
                {
                    var result = await _repository.DeleteUserFromRoleAsync(roleName, getUser.user);
                    return result.Succeeded ? response : response.WithErrors(GetErros(result.Errors));
                }
                return response.AddError("user not found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
    }
}
