using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MKW.Services.AppServices;
using Xunit;
using MKW.Domain.Dto.DTO.AwardDTO;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.ReviewAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Utility.Exceptions;
using Moq;
using FakeItEasy;

namespace MKW.Tests
{
    public class AwardServiceTest
    {
        public readonly AwardService _as;
        private readonly Mock<IAwardRepository> _mockAwardRepository;
        private readonly Mock<IAwardPersonRepository> _mockAwardPersonRepository;
        private readonly Mock<IPersonService> _mockPersonService;
        private readonly Mock<IReviewRepository> _mockReviewRepository;

        private readonly GivenAwardDto _model;
        private readonly Award _award;

        private readonly GivenAwardDto _givenAward;
        private readonly GiveAwardDto _giveAward;

        private readonly AwardPerson _awardPerson;

        private readonly Person _user;
        private readonly Review _review;
        public AwardServiceTest()
        {
            _mockAwardRepository = new Mock<IAwardRepository>();
            _mockAwardPersonRepository = new Mock<IAwardPersonRepository>();
            _mockPersonService = new Mock<IPersonService>();
            _mockReviewRepository = new Mock<IReviewRepository>();
            _as = new AwardService(_mockAwardRepository.Object, _mockAwardPersonRepository.Object, _mockPersonService.Object, _mockReviewRepository.Object);
            _model = A.Fake<GivenAwardDto>();
            _award = A.Fake<Award>();
            _giveAward = A.Fake<GiveAwardDto>();
            _givenAward = A.Fake<GivenAwardDto>();
            _user = A.Fake<Person>();
            _review = A.Fake<Review>();
            _review.PersonId = 2;
            _awardPerson = A.Fake<AwardPerson>();

            _mockAwardRepository
              .Setup(x => x.GetById(It.IsAny<int>()))
              .Returns(Task.FromResult(_award));

            _mockPersonService
                .Setup(x => x.GetUser())
                .Returns(Task.FromResult(_user));
            
            _mockPersonService
                .Setup(x => x.Update(It.IsAny<Person>()))
                .Returns(Task.FromResult(_user));

            _mockReviewRepository
                .Setup(x => x.GetById(_review.Id))
                .Returns(Task.FromResult(_review));

            _mockAwardPersonRepository
                .Setup(x => x.Add(It.IsAny<AwardPerson>()))
                .Returns(Task.FromResult(_awardPerson));
        }

        [Fact]
        async void Should_Return_GivenAwardDto_Enumerable()
        {
            
            var result = await _as.AddAward(_giveAward);

            Assert.Equivalent(result.Content.First().Award, new GivenAwardDto(_awardPerson).Award);
            

        }
    }
}