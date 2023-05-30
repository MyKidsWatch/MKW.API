using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Dto.DTO.IdentityDTO.Account;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.AppServices.IdentityService;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Services.AppServices.IdentityService;
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

        public void AccountService()
        {
            // this.userRepositoryMock = new Mock<IUserRepository>();
            // this.userTokenRepositoryMock = new Mock<IUserTokenRepository>();
            // this.personServiceMock = new Mock<IPersonService>();
            // this.emailServiceMock = new Mock<IEmailService>();
            // this.roleServiceMock = new Mock<IRoleService>();
            // this.mapperMock = new Mock<IMapper>();
            // this.accountService = new AccountService(
            //    userRepositoryMock.Object,
            //    userTokenRepositoryMock.Object,
            //    personServiceMock.Object,
            //    emailServiceMock.Object,
            //    roleServiceMock.Object,
            //    mapperMock.Object
            //    );
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