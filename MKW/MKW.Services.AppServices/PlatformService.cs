using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Interface.Repository.ContentAggregate;
using MKW.Domain.Interface.Services.AppServices;

namespace MKW.Services.AppServices
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository _platformRepository;

        public PlatformService(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public async Task<IEnumerable<Platform>?> GetAll() => await _platformRepository.GetAll();
    }
}
