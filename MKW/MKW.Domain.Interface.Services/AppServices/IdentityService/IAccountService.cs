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
        Task<IEnumerable<ReadUserDTO>?> GetAllAccountsAsync();
        Task<ReadUserDTO?> GetAccountByUserIdAsync(int id);
        Task<ReadUserDTO?> GetAccountByUserNameAsync(string userName);
        Task<IEnumerable<ReadUserDTO>> GetAllAccountsByClaimAsync(Claim claim);
        Task<IEnumerable<ReadUserDTO>> GetAllAccountsByRoleAsync(string roleName);
        Task<IEnumerable<ReadUserDTO>> GetActiveAccountsAsync();
        Task<BaseResponseDTO<ReadUserDTO>> RegisterAccountAsync(CreateUserDTO userDTO);
        Task<IResultBase> ConfirmAccountEmailAsync(ConfirmAccountEmailDTO ActivationRequest);
        Task<(IResultBase result, ReadUserDTO user)> UpdateAccountAsync(int id, UpdateUserDTO userDTO);
        Task<IResultBase> DeleteAccountByIdAsync(int id);
        Task<BaseResponseDTO<ReadUserDTO>> DeleteAccountByUserNameAsync(string userName);
    }
}
