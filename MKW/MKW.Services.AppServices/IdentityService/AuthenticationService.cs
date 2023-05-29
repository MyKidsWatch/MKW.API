using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Authentication;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Interface.Services.AppServices.IdentityService;
using System.Security.Claims;

namespace MKW.Services.AppServices.IdentityService
{
    public class AuthenticationService : IAuthService
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthenticationService(SignInManager<ApplicationUser> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<BaseResponseDTO<TokenDTO>> LoginByUserNameAsync(LoginRequestByUserNameDTO loginRequest)
        {
            try
            {
                var applicationUser = await _signInManager.UserManager.FindByNameAsync(loginRequest.UserName);
                if (applicationUser is null) return new BaseResponseDTO<TokenDTO>().WithErrors(GetErros());

                return await LoginAsync(applicationUser, loginRequest.Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<TokenDTO>> LoginByEmailAsync(LoginRequestByEmailDTO loginRequest)
        {
            try
            {
                var applicationUser = await _signInManager.UserManager.FindByEmailAsync(loginRequest.Email);
                if (applicationUser is null) return new BaseResponseDTO<TokenDTO>().WithErrors(GetErros());

                return await LoginAsync(applicationUser, loginRequest.Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResponseDTO<TokenDTO>> RefreshLoginAsync(HttpContext request)
        {
            try
            {
                var responseDTO = new BaseResponseDTO<TokenDTO>();
                var claims = request.User.Identity as ClaimsIdentity;
                var userId = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                var user = await _signInManager.UserManager.FindByIdAsync(userId);
                if (user is null) return new BaseResponseDTO<TokenDTO>().WithErrors(GetErros());

                if (await _signInManager.UserManager.IsLockedOutAsync(user))
                {
                    return new BaseResponseDTO<TokenDTO>().WithErrors(GetErros());
                }

                return responseDTO.AddContent(await GenerateToken(user));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<BaseResponseDTO<TokenDTO>> LoginAsync(ApplicationUser applicationUser, string password)
        {
            try
            {
                var LoginResponseDTO = new BaseResponseDTO<TokenDTO>();
                var checkPasswordResult = await _signInManager.CheckPasswordSignInAsync(applicationUser, password, false);

                if (checkPasswordResult.Succeeded)
                {
                    return LoginResponseDTO.AddContent(await GenerateToken(applicationUser));
                }

                return LoginResponseDTO.WithErrors(GetErros(checkPasswordResult));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<TokenDTO> GenerateToken(ApplicationUser applicationUser)
        {
            var userRoles = await _signInManager.UserManager.GetRolesAsync(applicationUser);
            var userClaims = await _signInManager.UserManager.GetClaimsAsync(applicationUser);
            var token = await _tokenService.GetToken(applicationUser, userClaims, userRoles);
            var tokenResponseDTO = _mapper.Map<TokenDTO>(token.Value);
            return tokenResponseDTO;
        }

        private IEnumerable<string> GetErros(SignInResult? result = null)
        {
            var errorList = new List<string>();

            if (result is not null)
            {
                if (result.IsLockedOut) errorList.Add("LockedOut");
                if (result.IsNotAllowed) errorList.Add("NotAllowed");
                if (result.RequiresTwoFactor) errorList.Add("RequiresTwoFactor");
            }

            if (errorList.IsNullOrEmpty<string>())
                errorList.Add("User or password are incorrect");

            return errorList;
        }
    }
}
