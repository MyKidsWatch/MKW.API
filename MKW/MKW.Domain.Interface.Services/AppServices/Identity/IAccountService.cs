using Microsoft.AspNetCore.Identity;
using MKW.Domain.Dto.Identity;
using MKW.Domain.Entities.Identity;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;



namespace MKW.Domain.Interface.Services.AppServices.Identity
{
    public interface IAccountService
    {
        Task<IEnumerable<ReadUserDTO>> GetAllAccounts();
        Task<ReadUserDTO?> GetAccountByUserId(int id);
        Task<ReadUserDTO?> GetAccountByUserName(string userName);
        Task<IEnumerable<ReadUserDTO>> GetAllAccountsByClaim(Claim claim);
        Task<IEnumerable<ReadUserDTO>> GetAllAccountsByRole(string roleName);
        Task<IEnumerable<ReadUserDTO>> GetActiveAccounts();
        Task<(IResultBase result, ReadUserDTO? user)> RegisterAccount(CreateUserDTO userDTO);
        Task<(IResultBase result, ReadUserDTO user)> UpdateAccount(UpdateUserDTO userDTO);
        Task<IResultBase> DeleteAccount(DeleteUserDTO userDTO);
        Task<IResultBase> DeleteAccountById(int id);
        Task<IResultBase> DeleteAccountByUserName(string userName);
    }
}
