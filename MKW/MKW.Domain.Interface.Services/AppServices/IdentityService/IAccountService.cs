using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MKW.Domain.Dto.DTO.IdentityDTO.Account;
using MKW.Domain.Dto.Base;

namespace MKW.Domain.Interface.Services.AppServices.Identity
{
    public interface IAccountService
    {
        Task<BaseResponseDTO<ReadUserDTO>> GetAllAccountsAsync();
        Task<BaseResponseDTO<ReadUserDTO>?> GetAccountByUserIdAsync(int id);
        Task<BaseResponseDTO<ReadUserDTO>?> GetAccountByUserNameAsync(string userName);
        Task<BaseResponseDTO<ReadUserDTO>> GetAllAccountsByClaimAsync(Claim claim);
        Task<BaseResponseDTO<ReadUserDTO>> GetAllAccountsByRoleAsync(string roleName);
        Task<BaseResponseDTO<ReadUserDTO>> GetActiveAccountsAsync();
        Task<BaseResponseDTO<ReadUserDTO>> RegisterAccountAsync(CreateUserDTO userDTO);
        Task<BaseResponseDTO<ReadUserDTO>> UpdateAccountAsync(int id, UpdateUserDTO userDTO);
        Task<BaseResponseDTO<object>> DeleteAccountByIdAsync(int id);
        Task<BaseResponseDTO<object>> DeleteAccountByUserNameAsync(string userName);
        Task<BaseResponseDTO<CheckUserNameDTO>> CheckUserNameAsync(string username);
        Task<BaseResponseDTO<CheckEmailDTO>> CheckEmailAsync(string username);
        Task<BaseResponseDTO<ResponseGenerateKeycodeDTO>> RequestEmailKeycodeAsync(RequestKeycodeDTO request);
        Task<BaseResponseDTO<ReadUserDTO>> ConfirmAccountEmailAsync(ConfirmAccountEmailDTO ActivationRequest);
        Task<BaseResponseDTO<ResponseGenerateKeycodeDTO>> RequestPasswordKeycodeAsync(RequestKeycodeDTO request);
        Task<BaseResponseDTO<ReadUserDTO>> ResetPasswordAsync(ResetPasswordDTO request);
    }
}
