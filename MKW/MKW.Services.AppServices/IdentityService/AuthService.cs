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

        public async Task<(IResultBase, LoginResponseDTO)> LoginByUserNameAsync(LoginRequestByUserNameDTO loginRequest)
        {
            var applicationUser = await _signInManager.UserManager.FindByNameAsync(loginRequest.UserName);
            if (applicationUser is null) return (Result.Fail("Failed to signIn user"), GetLoginErros());

            return await LoginAsync(applicationUser, loginRequest.Password);
        }

        public async Task<(IResultBase, LoginResponseDTO)> LoginByEmailAsync(LoginRequestByEmailDTO loginRequest)
        {
            var applicationUser = await _signInManager.UserManager.FindByEmailAsync(loginRequest.Email);
            if (applicationUser is null) return (Result.Fail("Failed to signIn user"), GetLoginErros());

            return await LoginAsync(applicationUser, loginRequest.Password);

        }

        public async Task<IResultBase> LogoutUserAsync()
        {
            var logoutResult =  _signInManager.SignOutAsync();
            if (logoutResult.IsCompletedSuccessfully) return Result.Ok("logout completed Successfully");
            return Result.Fail("Failed to completed logout");
        }

        private async Task<(IResultBase, LoginResponseDTO)> LoginAsync(ApplicationUser applicationUser, string password)
        {

            var checkPasswordResult = await _signInManager.CheckPasswordSignInAsync(applicationUser, password, false);

            if (checkPasswordResult.Succeeded)
            {
                var userRoles = await _signInManager.UserManager.GetRolesAsync(applicationUser);
                var userClaims = await _signInManager.UserManager.GetClaimsAsync(applicationUser);

                var token = await _tokenService.GetToken(applicationUser, userClaims, userRoles);
  
                var tokenResponseDTO = _mapper.Map<TokenDTO>(token.Value);
                var LoginResponseWithSuccess = new LoginResponseDTO(token.IsSuccess, tokenResponseDTO);
                return (Result.Ok(), LoginResponseWithSuccess);
            }

            var LoginResponseWithErros = GetLoginErros(
                checkPasswordResult);
                
            return (Result.Fail("Failed to signIn user"), LoginResponseWithErros); 

        }

        private LoginResponseDTO GetLoginErros(SignInResult? result = null)
        {
            var responseDTO = new LoginResponseDTO(false);

            if(result is not null)
            {
                if (result.IsLockedOut)  responseDTO.addError("LockedOut");
                if (result.IsNotAllowed) responseDTO.addError("NotAllowed");
                if (result.RequiresTwoFactor) responseDTO.addError("RequiresTwoFactor");
            }

            if(responseDTO.Errors.IsNullOrEmpty<string>())
                responseDTO.addError("User or password are incorrect");

            return responseDTO;
        }
    }
}
