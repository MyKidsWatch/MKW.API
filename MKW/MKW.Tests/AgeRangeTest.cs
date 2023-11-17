using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MKW.Services.AppServices;
using Xunit;
using MKW.Domain.Dto.DTO.AgeRangeDTO;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using Moq;
using AutoFixture;
using FluentResults;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Tests
{
    public class AgeRangeTest
    {
        private readonly AgeRangeService _ars;
        private readonly Mock<IAgeRangeRepository> _mockAgeRangeRepository;

        public AgeRangeTest()
        {
            _mockAgeRangeRepository = new Mock<IAgeRangeRepository>();
            _ars = new AgeRangeService(_mockAgeRangeRepository.Object);
        }
        
        [Fact]
        public async void Should_Return_Age_Range_Enumerable()
        {
            // Arrange
            AgeRange ageRangeAgg = new AgeRange
            {
                Id = 1,
                InitialAge = 2,
                FinalAge = 4
            };

            IEnumerable<AgeRange> xyz = new AgeRange[] {ageRangeAgg};
            
            // Act
            _mockAgeRangeRepository
                .Setup(x => x.GetActive())
                .Returns(Task.FromResult(xyz));
            
            var result = await _ars.Get();

            // Assert
            Assert.Equal(ageRangeAgg.InitialAge, result.Content[0].InitialAge);
        }
    }

}