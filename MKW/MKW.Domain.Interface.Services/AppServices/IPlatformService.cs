using MKW.Domain.Entities.ContentAggregate;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IPlatformService
    {
        Task<IEnumerable<Platform>?> GetAll();
    }
}