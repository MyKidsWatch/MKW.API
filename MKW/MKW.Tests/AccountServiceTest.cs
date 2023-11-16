using System.Security.Claims;
using AutoMapper;
using FakeItEasy;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MKW.API.Controllers.Identity;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Account;
using MKW.Domain.Dto.DTO.IdentityDTO.Authorization;
using MKW.Domain.Dto.DTO.PersonDTO;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.AppServices.IdentityService;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Services.AppServices.IdentityService;
using MKW.Services.BaseServices;
using Moq;

namespace MKW.Tests
{
    public class AccountServiceTest
    {

        private Mock<IUserRepository> userRepositoryMock;
        private Mock<IUserTokenRepository> userTokenRepositoryMock;
        private Mock<IPersonService> personServiceMock;
        private Mock<IEmailService> emailServiceMock;
        private Mock<IRoleService> roleServiceMock;
        private Mock<IMapper> mapperMock;
        private IAccountService accountService;

        private IEmailService emailService;

        public AccountServiceTest()
        {
            userRepositoryMock = new Mock<IUserRepository>();
            userTokenRepositoryMock = new Mock<IUserTokenRepository>();
            personServiceMock = new Mock<IPersonService>();
            emailServiceMock = new Mock<IEmailService>();
            roleServiceMock = new Mock<IRoleService>();
            mapperMock = new Mock<IMapper>();
            accountService = new AccountService(
               userRepositoryMock.Object,
               userTokenRepositoryMock.Object,
               personServiceMock.Object,
               emailServiceMock.Object,
               roleServiceMock.Object,
               mapperMock.Object
               );

        }

        [Fact]
        public async void TestGetUserByIdAsync()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userTokenRepositoryMock = new Mock<IUserTokenRepository>();
            var personServiceMock = new Mock<IPersonService>();
            var emailServiceMock = new Mock<IEmailService>();
            var roleServiceMock = new Mock<IRoleService>();
            var mapperMock = new Mock<IMapper>();
            var accountService = new AccountService(
               userRepositoryMock.Object,
               userTokenRepositoryMock.Object,
               personServiceMock.Object,
               emailServiceMock.Object,
               roleServiceMock.Object,
               mapperMock.Object
               );
            // criando um usuario pra ser retornado pelo repositorio
            var user = new ApplicationUser();
            user.Id = 1;
            user.UserName = "not-batman";
            user.FirstName = "Bruce";
            user.LastName = "Wayne";

            // definindo que o mock do repositorio vai retornar o user acima
            userRepositoryMock
                .Setup(x => x.GetUserByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Result.Ok(), user));

            // criando o DTO a ser retornado pelo Mapper
            var readUserDTO = new ReadUserDTO();
            readUserDTO.Id = 1;
            readUserDTO.FirstName = user.FirstName;
            readUserDTO.LastName = user.LastName;
            readUserDTO.userName = user.UserName;

            // definindo que o mock do Mapper vai retornar o DTO acima
            mapperMock
                .Setup(x => x.Map<ReadUserDTO>(It.IsAny<ApplicationUser>()))
                .Returns(readUserDTO);

            // act
            var response = await accountService.GetAccountByUserIdAsync(1);

            // assert
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Content);
            Assert.Equal(response.Content.FirstOrDefault(), readUserDTO);

        }

        [Fact]
        public async void TestGetUserByUserNameAsync()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userTokenRepositoryMock = new Mock<IUserTokenRepository>();
            var personServiceMock = new Mock<IPersonService>();
            var emailServiceMock = new Mock<IEmailService>();
            var roleServiceMock = new Mock<IRoleService>();
            var mapperMock = new Mock<IMapper>();
            var accountService = new AccountService(
               userRepositoryMock.Object,
               userTokenRepositoryMock.Object,
               personServiceMock.Object,
               emailServiceMock.Object,
               roleServiceMock.Object,
               mapperMock.Object
               );
            // criando um usuario pra ser retornado pelo repositorio
            var user = new ApplicationUser();
            user.Id = 1;
            user.UserName = "not-batman";
            user.FirstName = "Bruce";
            user.LastName = "Wayne";

            // definindo que o mock do repositorio vai retornar o user acima
            userRepositoryMock
                .Setup(x => x.GetUserByUserNameAsync(user.UserName))
                .ReturnsAsync((Result.Ok(), user));


            // criando o DTO a ser retornado pelo Mapper
            var readUserDTO = new ReadUserDTO();
            readUserDTO.Id = 1;
            readUserDTO.FirstName = user.FirstName;
            readUserDTO.LastName = user.LastName;
            readUserDTO.userName = user.UserName;

            // definindo que o mock do Mapper vai retornar o DTO acima
            mapperMock
                .Setup(x => x.Map<ReadUserDTO>(It.IsAny<ApplicationUser>()))
                .Returns(readUserDTO);

            // act
            var response = await accountService.GetAccountByUserNameAsync(readUserDTO.userName);


            // assert
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Content);
            Assert.Equal(response.Content.FirstOrDefault(), readUserDTO);
        }

        // [Fact]
        // public async void TestGetActiveUsersAsync()

        // [Fact]
        // async void TestGetAllAccountsByRoleAsync()

        // [Fact]
        // async void TestGetAllAccountsByClaimAsync()

        // [Fact]
        // async void TestRegisterAccountAsync()

        // [Fact]
        // async void TestUpdateAccountAsync(int id, UpdateUserDTO userDTO)

        [Fact]
        async void TestDeleteAccountByIdAsync()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userTokenRepositoryMock = new Mock<IUserTokenRepository>();
            var personServiceMock = new Mock<IPersonService>();
            var emailServiceMock = new Mock<IEmailService>();
            var roleServiceMock = new Mock<IRoleService>();
            var mapperMock = new Mock<IMapper>();
            var accountService = new AccountService(
               userRepositoryMock.Object,
               userTokenRepositoryMock.Object,
               personServiceMock.Object,
               emailServiceMock.Object,
               roleServiceMock.Object,
               mapperMock.Object
               );

            var user = new ApplicationUser();
            user.Id = 1;

            var result = IdentityResult.Success;            

            userRepositoryMock
                .Setup(x => x.DeleteUserByIdAsync(user.Id))
                .ReturnsAsync(result);

            // act
            var response = await accountService.DeleteAccountByIdAsync(user.Id);

            // assert
            Assert.True(response.IsSuccess);
            Assert.Null(response.Content);
        }

        [Fact]
        async void TestDeleteAccountByUserNameAsync(){
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userTokenRepositoryMock = new Mock<IUserTokenRepository>();
            var personServiceMock = new Mock<IPersonService>();
            var emailServiceMock = new Mock<IEmailService>();
            var roleServiceMock = new Mock<IRoleService>();
            var mapperMock = new Mock<IMapper>();
            var accountService = new AccountService(
               userRepositoryMock.Object,
               userTokenRepositoryMock.Object,
               personServiceMock.Object,
               emailServiceMock.Object,
               roleServiceMock.Object,
               mapperMock.Object
               );

            var user = new ApplicationUser();
            user.Id = 1;
            user.UserName = "not-batman";

            var result = IdentityResult.Success;            

            userRepositoryMock
                .Setup(x => x.DeleteUserByUserNameAsync(user.UserName))
                .ReturnsAsync(result);

            // act
            var response = await accountService.DeleteAccountByUserNameAsync(user.UserName);

            // assert
            Assert.True(response.IsSuccess);
            Assert.Null(response.Content);
        }

        // [Fact]
        // async void TestConfirmAccountEmailAsync(ConfirmAccountEmailDTO activationRequest)

        [Fact]
        async void TestCheckUserNameAsync()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userTokenRepositoryMock = new Mock<IUserTokenRepository>();
            var personServiceMock = new Mock<IPersonService>();
            var emailServiceMock = new Mock<IEmailService>();
            var roleServiceMock = new Mock<IRoleService>();
            var mapperMock = new Mock<IMapper>();
            var accountService = new AccountService(
               userRepositoryMock.Object,
               userTokenRepositoryMock.Object,
               personServiceMock.Object,
               emailServiceMock.Object,
               roleServiceMock.Object,
               mapperMock.Object
               );
            var user = new ApplicationUser();
            user.Id = 1;
            user.UserName = "notbatman";

            userRepositoryMock
                .Setup(x => x.GetUserByUserNameAsync(user.UserName))
                .ReturnsAsync((Result.Ok(), user));

            var checkUserNameDTO = new CheckUserNameDTO(false);

            mapperMock
                .Setup(x => x.Map<CheckUserNameDTO>(It.IsAny<ApplicationUser>()))
                .Returns(checkUserNameDTO);

            // act
            var response = await accountService.CheckUserNameAsync("notbatman");

            // assert
            Assert.False(response.IsSuccess);
            Assert.NotNull(response.Content);
        }

        [Fact]
        async void TestCheckEmailAsync()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userTokenRepositoryMock = new Mock<IUserTokenRepository>();
            var personServiceMock = new Mock<IPersonService>();
            var emailServiceMock = new Mock<IEmailService>();
            var roleServiceMock = new Mock<IRoleService>();
            var mapperMock = new Mock<IMapper>();
            var accountService = new AccountService(
               userRepositoryMock.Object,
               userTokenRepositoryMock.Object,
               personServiceMock.Object,
               emailServiceMock.Object,
               roleServiceMock.Object,
               mapperMock.Object
               );
            var user = new ApplicationUser();
            user.Id = 1;
            user.Email = "josedasilva@email.com";

            userRepositoryMock
                .Setup(x => x.GetUserByEmailAsync(user.Email))
                .ReturnsAsync((Result.Ok(), user));

            var checkEmailDTO = new CheckEmailDTO(true);

            mapperMock
                .Setup(x => x.Map<CheckEmailDTO>(It.IsAny<ApplicationUser>()))
                .Returns(checkEmailDTO);

            // act
            var response = await accountService.CheckEmailAsync(
                "josedasilva@email.com");

            // assert
            Assert.False(response.IsSuccess);
            Assert.NotNull(response.Content);
        }

        [Fact]
        async void Should_Return_Accounts_Enumerable(){

            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userTokenRepositoryMock = new Mock<IUserTokenRepository>();
            var personServiceMock = new Mock<IPersonService>();
            var emailServiceMock = new Mock<IEmailService>();
            var roleServiceMock = new Mock<IRoleService>();
            var mapperMock = new Mock<IMapper>();
            var accountService = new AccountService(
               userRepositoryMock.Object,
               userTokenRepositoryMock.Object,
               personServiceMock.Object,
               emailServiceMock.Object,
               roleServiceMock.Object,
               mapperMock.Object
               );
            // criando um usuario pra ser retornado pelo repositorio
            var user = new ApplicationUser();
            user.Id = 1;
            user.UserName = "not-batman";
            user.FirstName = "Bruce";
            user.LastName = "Wayne";

            IEnumerable<ApplicationUser> users = new ApplicationUser[] { user };

            // definindo que o mock do repositorio vai retornar o user acima
            userRepositoryMock
                .Setup(x => x.GetAllUsersAsync())
                .ReturnsAsync(users);

            // criando o DTO a ser retornado pelo Mapper
            var readUserDTO = new ReadUserDTO();
            readUserDTO.Id = 1;
            readUserDTO.FirstName = user.FirstName;
            readUserDTO.LastName = user.LastName;
            readUserDTO.userName = user.UserName;

            IEnumerable<ReadUserDTO> readUserDTOs = new ReadUserDTO[] { readUserDTO};
            // definindo que o mock do Mapper vai retornar o DTO acima
            mapperMock
                .Setup(x => x.Map<IEnumerable<ReadUserDTO>>(It.IsAny<IEnumerable<ApplicationUser>>()))
                .Returns(readUserDTOs);

            // act
            var response = await accountService.GetAllAccountsAsync();

            // assert
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Content);
            Assert.Equal(response.Content.FirstOrDefault(), readUserDTO);

            userRepositoryMock
                .Setup(x => x.GetAllUsersAsync())
                .Throws(new Exception());

            Assert.ThrowsAsync<Exception>(() => accountService.GetAllAccountsAsync());

        }

        [Fact]
        async void Should_Return_Accounts_ReadUserDTO_Enumerable_GetActiveAccountsAsync()
        {
            var readUserDTO = A.Fake<ReadUserDTO>();
            IEnumerable<ReadUserDTO> readUserDTOs = new ReadUserDTO[] { readUserDTO };
            var user = A.Fake<ApplicationUser>();

            IEnumerable<ApplicationUser> users = new ApplicationUser[] { user };

            userRepositoryMock
                .Setup(x => x.GetActiveUsersAsync())
                .Returns(Task.FromResult(users));
            
            mapperMock
                .Setup(x => x.Map<IEnumerable<ReadUserDTO>>(It.IsAny<IEnumerable<ApplicationUser>>()))
                .Returns(readUserDTOs);

            var result = await accountService.GetActiveAccountsAsync();

            Assert.Equal(result.Content[0].FirstName, user.FirstName);
        }

        [Fact]
        async void Should_Return_Accounts_ReadUserDTO_Enumerable_GetAllAccountsByRoleAsync()
        {

            var role = A.Fake<BaseResponseDTO<ReadRoleDTO>>();
            role.AddContent(A.Fake<ReadRoleDTO>());
            var firstRole = role.Content.First();
            var user = A.Fake<ApplicationUser>();
            var readUserDTO = A.Fake<ReadUserDTO>();
            IEnumerable<ReadUserDTO> readUserDTOs = new ReadUserDTO[] { readUserDTO };
            IEnumerable<ApplicationUser> users = new ApplicationUser[] { user };

            // IEnumerable<ReadRoleDTO> roles = new ReadRoleDTO[] { role };

            roleServiceMock
                .Setup(x => x.GetRolesByNameAsync(firstRole.RoleName))
                .Returns(Task.FromResult<BaseResponseDTO<ReadRoleDTO>>(role));

            userRepositoryMock
                .Setup(x => x.GetAllUsersByRoleAsync(firstRole.RoleName))
                .Returns(Task.FromResult(users));

            mapperMock
                .Setup(x => x.Map<IEnumerable<ReadUserDTO>>(It.IsAny<IEnumerable<ApplicationUser>>()))
                .Returns(readUserDTOs);

            var result = await accountService.GetAllAccountsByRoleAsync(firstRole.RoleName);

            Assert.Equal(result.Content.First(), readUserDTO);
        }

        [Fact]
        async void Should_Return_Accounts_ReadUserDTO_Enumerable_GetAllAccountsByClaimAsync()
        {

            var role = A.Fake<BaseResponseDTO<ReadRoleDTO>>();
            role.AddContent(A.Fake<ReadRoleDTO>());
            var firstRole = role.Content.First();
            var user = A.Fake<ApplicationUser>();
            var readUserDTO = A.Fake<ReadUserDTO>();
            IEnumerable<ReadUserDTO> readUserDTOs = new ReadUserDTO[] { readUserDTO };
            IEnumerable<ApplicationUser> users = new ApplicationUser[] { user };
            var claim = A.Fake<Claim>();

            userRepositoryMock
                .Setup(x => x.GetAllUsersByClaimAsync(claim))
                .Returns(Task.FromResult(users));

            mapperMock
                .Setup(x => x.Map<IEnumerable<ReadUserDTO>>(It.IsAny<IEnumerable<ApplicationUser>>()))
                .Returns(readUserDTOs);

            var result = await accountService.GetAllAccountsByClaimAsync(claim);

            Assert.Equal(result.Content.First(), readUserDTO);
        }

        [Fact]
        async void Should_Return_Accounts_ReadUserDTO_Enumerable_GetAccountByTokenAsync()
        {

            var role = A.Fake<BaseResponseDTO<ReadRoleDTO>>();
            role.AddContent(A.Fake<ReadRoleDTO>());
            var firstRole = role.Content.First();
            var user = A.Fake<ApplicationUser>();
            var readUserDTO = A.Fake<ReadUserDTO>();
            readUserDTO.AssociatedWithPerson = A.Fake<ReadPersonDTO>();
            IEnumerable<ReadUserDTO> readUserDTOs = new ReadUserDTO[] { readUserDTO };
            IEnumerable<ApplicationUser> users = new ApplicationUser[] { user };

            var context = new DefaultHttpContext();
            context.User = new ClaimsPrincipal();
            var claim = new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",user.Id.ToString());
            
            context.User.AddIdentity(new ClaimsIdentity(new Claim[] { claim }));


            userRepositoryMock
                .Setup(x => x.GetUserByIdAsync(user.Id))
                .Returns(Task.FromResult((Result.Ok(), user)));

            mapperMock
                .Setup(x => x.Map<ReadUserDTO>(It.IsAny<ApplicationUser>()))
                .Returns(readUserDTO);

            var result = await accountService.GetAccountByTokenAsync(context);

            Assert.Equal(result.Content.First(), readUserDTO);
        }

        [Fact]
        async void Should_Return_Accounts_ReadUserDTO_Enumerable_RegisterAccountAsync(){
            var createUserDto = A.Fake<CreateUserDTO>();

            userRepositoryMock
                .Setup(x => x.GetUserByIdAsync(user.Id))
                .Returns(Task.FromResult((Result.Ok(), user)));

            mapperMock
                .Setup(x => x.Map<CreateUserDTO>(It.IsAny<ApplicationUser>()))
                .Returns(createUserDto);

            var result = await accountService.RegisterAccountAsync(createUserDto);
        }

        // [Fact]
        // async void TestRequestEmailKeycodeAsync(){
        //     // Arrange
        //     var userRepositoryMock = new Mock<IUserRepository>();
        //     var userTokenRepositoryMock = new Mock<IUserTokenRepository>();
        //     var personServiceMock = new Mock<IPersonService>();
        //     var emailServiceMock = new Mock<IEmailService>();
        //     var roleServiceMock = new Mock<IRoleService>();
        //     var mapperMock = new Mock<IMapper>();
        //     var accountService = new AccountService(
        //        userRepositoryMock.Object,
        //        userTokenRepositoryMock.Object,
        //        personServiceMock.Object,
        //        emailServiceMock.Object,
        //        roleServiceMock.Object,
        //        mapperMock.Object
        //        );
        //     var user = new ApplicationUser();
        //     user.Id = 1;
        //     user.Email = "josedasilva@email.com";

        //     userRepositoryMock
        //         .Setup(x => x.GetUserByEmailAsync(user.Email))
        //         .ReturnsAsync((Result.Ok(), user));

        //     var responseGeneratedKeycode = new ResponseGenerateKeycodeDTO(true);

        //     mapperMock
        //         .Setup(x => x.Map<CheckEmailDTO>(It.IsAny<ApplicationUser>()))
        //         .Returns(responseGeneratedKeycode);

        //     // act
        //     var response = await accountService.RequestEmailKeycodeAsync();

        //     // assert
        //     Assert.False(response.IsSuccess);
        //     Assert.NotNull(response.Content);
        // }

        // [Fact]
        // async void TestRequestPasswordKeycodeAsync()

        // [Fact]
        // async Task<BaseResponseDTO<ReadUserDTO>> TestResetPasswordAsync()

        // [Fact]
        // async void TestGetAccountByTokenAsync()
    }

}