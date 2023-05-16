using FluentResults;
using Microsoft.AspNetCore.Http;
using MKW.Domain.Dto.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Auth;
using MKW.Domain.Entities.IdentityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Interface.Services.AppServices.Identity
{
    public interface IAuthService
    {
        Task<BaseResponseDTO<TokenDTO>> LoginByUserNameAsync(LoginRequestByUserNameDTO loginRequest);
        Task<BaseResponseDTO<TokenDTO>> LoginByEmailAsync(LoginRequestByEmailDTO loginRequest);
        Task<BaseResponseDTO<TokenDTO>> RefreshLoginAsync(HttpContext userId);
    }
}
