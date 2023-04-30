using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Interface.Repository.ContentAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Services.AppServices.Base;

namespace MKW.Services.AppServices
{
    public class PlatformService : BaseService<Platform>, IPlatformService
    {
        public PlatformService(IPlatformRepository platformRepository) : base(platformRepository)
        {
        }
    }
}
