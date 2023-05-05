using FluentResults;
using MKW.Domain.Dto.DTO.IdentityDTO.Auth;
using MKW.Domain.Entities.IdentityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Interface.Services.AppServices.Identity
{
    public interface IAuthService
    {
        Task<(IResultBase result, LoginResponseDTO loginResponse)> LoginByUserNameAsync(LoginRequestByUserNameDTO loginRequest);
        Task<(IResultBase result, LoginResponseDTO loginResponse)> LoginByEmailAsync(LoginRequestByEmailDTO loginRequest);
    }
}
