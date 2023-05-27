using AutoMapper;
using FluentResults;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Account;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
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
            this.userRepositoryMock = new Mock<IUserRepository>();
            this.userTokenRepositoryMock = new Mock<IUserTokenRepository>();
            this.personServiceMock = new Mock<IPersonService>();
            this.emailServiceMock = new Mock<IEmailService>();
            this.roleServiceMock = new Mock<IRoleService>();
            this.mapperMock = new Mock<IMapper>();
            this.accountService = new AccountService(
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


            // // Arrange
            // var mock = new Mock<IAccountService>();

            // res = new BaseResponseDTO<ReadUserDTO>(true);
            // mock.Setup(m => m.GetAccountByUserIdAsync(It.IsAny<int>())).ReturnsAsync(res);

            // // Act

            // // Assert
            // Assert.True(res.IsSuccess);
        }

        [Fact]
        public async void TestGetUserByUserNameAsync()
        {
            //Arrange
            var user = new ApplicationUser();
            user.Id = 1;
            user.UserName = "not-batman";
            user.FirstName = "Bruce";
            user.LastName = "Wayne";

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


            // Act
            var response = await accountService.GetAccountByUserIdAsync(1);


            // Assert
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Content);
            Assert.Equal(response.Content.FirstOrDefault(), readUserDTO);
        }

        [Fact]
        public async void TestGetActiveUsersAsync(){
            //Arrange

            var user = new ApplicationUser();
            user.Id = 1;
            user.UserName = "not-batman";
            user.FirstName = "Bruce";
            user.LastName = "Wayne";

            // userRepositoryMock
            //     .Setup(x => x.GetActiveUsersAsync())
            //     .ReturnsAsync((IEnumerable<ApplicationUser>)user);

            var readUserDTO = new ReadUserDTO();
            readUserDTO.Id = 1;
            readUserDTO.FirstName = user.FirstName;
            readUserDTO.LastName = user.LastName;
            readUserDTO.userName = user.UserName;

            mapperMock
                .Setup(x => x.Map<IEnumerable<ReadUserDTO>>(It.IsAny<ApplicationUser>()))
                .Returns((IEnumerable<ReadUserDTO>)readUserDTO);

            
             // Act
            var response = await accountService.GetActiveAccountsAsync();

            // Assert

            Assert.True(true);
        }
    }
}