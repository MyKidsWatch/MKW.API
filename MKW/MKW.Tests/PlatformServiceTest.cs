using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MKW.Services.AppServices;
using Xunit;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Interface.Repository.ContentAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Services.AppServices.Base;
using Moq;

namespace MKW.Tests
{
    public class PlatformServiceTest
    {
        public PlatformService _ps;
        private Mock<IPlatformRepository> _mockPlatformRepository;
        
        [Fact]
        public void Should_Instatiate()
        {
            _mockPlatformRepository = new Mock<IPlatformRepository>();
            _ps = new PlatformService(_mockPlatformRepository.Object);
            Assert.NotNull(_ps);
        }
    }
}