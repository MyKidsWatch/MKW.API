using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MKW.Services.AppServices;
using Xunit;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.GenderDTO;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Utility.Exceptions;
using Moq;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Tests
{
    public class GenderServiceTest
    {
        private readonly GenderService _gs;
        private readonly Mock<IGenderRepository> _mockGenderRepository;

        public GenderServiceTest()
        {
          _mockGenderRepository = new Mock<IGenderRepository>();
          _gs = new GenderService(_mockGenderRepository.Object);
        }
        
        [Fact]
        public async void Should_Return_Gender_Enumerable()
        {
            // Arrange
            Gender gender = new Gender
            {
                Name = "Foo",
                IsBinary = true
            };

            IEnumerable<Gender> xyz = new Gender[] {gender};

            // Act
            _mockGenderRepository
                .Setup(x => x.GetActive())
                .Returns(Task.FromResult(xyz));
            
            var result = await _gs.Get();

            // Assert
            Assert.Equal(gender.Name, result.Content[0].Name);
        }

        [Fact]
        public async void Should_Throw_NotFoundException()
        {
            // Arrange

            IEnumerable<Gender> xyz = null;

            // Act
            _mockGenderRepository
                .Setup(x => x.GetActive())
                .Returns(Task.FromResult(xyz));
            
            // Act + Assert
            Assert.ThrowsAsync<NotFoundException>(async () => await _gs.Get());
             
        }

    }
}