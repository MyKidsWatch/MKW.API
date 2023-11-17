using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MKW.Services.AppServices;
using Xunit;
using Microsoft.AspNetCore.Http;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ChildDTO;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Utility.Exceptions;
using System.Security.Claims;
using Moq;
using FakeItEasy;
using MKW.Domain.Entities.IdentityAggregate;
using Microsoft.OpenApi.Any;

namespace MKW.Tests
{
    public class ChildServiceTest
    {
        private readonly ChildService _cs;
        private readonly Mock<IPersonChildRepository> _mockPersonChildRepository;
        // private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly Mock<IPersonRepository> _mockPersonRepository;
        private readonly Mock<IPersonService> _mockPersonService;

        private readonly PersonChild _child;
        private readonly Person _user;

        private readonly ChildDto _childDto;

        private readonly CreateChildDto _createChildDto;

        public ChildServiceTest()
        {
            _mockPersonChildRepository = new Mock<IPersonChildRepository>();
            // _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();h
            _httpContextAccessor = A.Fake<IHttpContextAccessor>();
            _mockPersonRepository = new Mock<IPersonRepository>();
            _mockPersonService = new Mock<IPersonService>();

            _child = A.Fake<PersonChild>();

            _user = A.Fake<Person>();

            _user.User = A.Fake<ApplicationUser>();

            _user.Children = new PersonChild[] { _child };

            _childDto = new ChildDto(_child);

            _createChildDto = A.Fake<CreateChildDto>();

            _mockPersonChildRepository
              .Setup(x => x.GetById(_child.Id))
              .Returns(Task.FromResult(_child));

            _mockPersonChildRepository
            .Setup(x => x.Add(It.IsAny<PersonChild>()))
            .Returns(Task.FromResult(_child));

            _mockPersonChildRepository
            .Setup(x => x.Update(It.IsAny<PersonChild>()))
            .Returns(Task.FromResult(_child));

            _mockPersonRepository
                .Setup(x => x.GetByEmail(_user.User.Email))
                .Returns(Task.FromResult(_user));

            _mockPersonService
                  .Setup(x => x.GetUser())
                  .Returns(Task.FromResult(_user));

            


            var context = new DefaultHttpContext();
            context.User = new ClaimsPrincipal();
            var claim = new Claim(ClaimTypes.Email, _user.User.Email);
            context.User.AddIdentity(new ClaimsIdentity(new Claim[] { claim }));

            _httpContextAccessor.HttpContext = context;

            _cs = new ChildService(_mockPersonChildRepository.Object, _httpContextAccessor, _mockPersonRepository.Object);


        }


        [Fact]
        async public void Should_Return_ChildDto_Response_GetById()
        {
            var result = await _cs.GetById(_child.Id);

            Assert.Equivalent(result.Content[0], _childDto);

            _mockPersonChildRepository
                .Setup(x => x.GetById(_child.Id))
                .Returns(Task.FromResult<PersonChild>(null));

            Assert.ThrowsAsync<NotFoundException>(() => _cs.GetById(_child.Id));
        }

        [Fact]
        async public void Should_Return_ChildDto_Response_Get()
        {
            var result = await _cs.Get();

            Assert.Equivalent(result.Content[0], _childDto);
        }

        [Fact]
        async public void Should_Return_ChildDto_Response_AddChild()
        {
            var result = await _cs.AddChild(_createChildDto);

            Assert.Equivalent(result.Content[0], _childDto);
        }

        [Fact]
        async public void Should_Return_ChildDto_Response_UpdateChild()
        {
            var result = await _cs.UpdateChild(_childDto);

            Assert.Equivalent(result.Content[0], _childDto);
        }

         [Fact]
        async public void Test_DeleteChild()
        {
            _cs.DeleteChild(_childDto.Id);
        }
    }
}