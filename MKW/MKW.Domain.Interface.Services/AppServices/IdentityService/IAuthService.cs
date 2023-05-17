using Microsoft.AspNetCore.Http;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Authentication;

namespace MKW.Domain.Interface.Services.AppServices.IdentityService
{
    public interface IAuthService
    {
        Task<BaseResponseDTO<TokenDTO>> LoginByUserNameAsync(LoginRequestByUserNameDTO loginRequest);
        Task<BaseResponseDTO<TokenDTO>> LoginByEmailAsync(LoginRequestByEmailDTO loginRequest);
        Task<BaseResponseDTO<TokenDTO>> RefreshLoginAsync(HttpContext userId);
    }
}
