using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using MKW.Domain.Interface.Services.AppServices.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Dto.DTO.IdentityDTO.Auth;
using FluentResults;
using MKW.Domain.Interface.Services.AppServices.IdentityService;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using MKW.Domain.Dto.Base;
using System.Net.Http.Headers;

namespace MKW.Services.AppServices.IdentityService
{
    public class AuthService : IAuthService
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService( SignInManager<ApplicationUser> signInManager,  ITokenService tokenService, IMapper mapper)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<BaseResponseDTO<TokenDTO>> LoginByUserNameAsync(LoginRequestByUserNameDTO loginRequest)
        {
            var applicationUser = await _signInManager.UserManager.FindByNameAsync(loginRequest.UserName);
            if (applicationUser is null) return new BaseResponseDTO<TokenDTO>().addErrors(GetErros());

            return await LoginAsync(applicationUser, loginRequest.Password);
        }

        public async Task<BaseResponseDTO<TokenDTO>> LoginByEmailAsync(LoginRequestByEmailDTO loginRequest)
        {
            var applicationUser = await _signInManager.UserManager.FindByEmailAsync(loginRequest.Email);
            if (applicationUser is null) return new BaseResponseDTO<TokenDTO>().addErrors(GetErros());

            return await LoginAsync(applicationUser, loginRequest.Password);

        }

        public async Task<BaseResponseDTO<Object>> LogoutUserAsync() => new BaseResponseDTO<Object>(_signInManager.SignOutAsync().IsCompletedSuccessfully);


        private async Task<BaseResponseDTO<TokenDTO>> LoginAsync(ApplicationUser applicationUser, string password)
        {

            var checkPasswordResult = await _signInManager.CheckPasswordSignInAsync(applicationUser, password, false);
  
            if (checkPasswordResult.Succeeded)
            {
                var userRoles = await _signInManager.UserManager.GetRolesAsync(applicationUser);
                var userClaims = await _signInManager.UserManager.GetClaimsAsync(applicationUser);

                var token = await _tokenService.GetToken(applicationUser, userClaims, userRoles);
  
                var tokenResponseDTO = _mapper.Map<TokenDTO>(token.Value);
                var LoginResponseDTO = new BaseResponseDTO<TokenDTO>(checkPasswordResult.Succeeded, tokenResponseDTO);
   
                return LoginResponseDTO;
            }

            return new BaseResponseDTO<TokenDTO>().addErrors(GetErros(checkPasswordResult)) ; 
        }

        private IEnumerable<string> GetErros(SignInResult? result = null)
        {
            var errorList = new List<string>();

            if(result is not null)
            {
                if (result.IsLockedOut) errorList.Add("LockedOut");
                if (result.IsNotAllowed) errorList.Add("NotAllowed");
                if (result.RequiresTwoFactor) errorList.Add("RequiresTwoFactor");
            }

            if(errorList.IsNullOrEmpty<string>())
                errorList.Add("User or password are incorrect");

            return errorList;
        }
    }
}
