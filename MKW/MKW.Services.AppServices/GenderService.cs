using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Services.AppServices.Base;

namespace MKW.Services.AppServices
{
    public class GenderService : BaseService<Gender>, IGenderService
    {
        public GenderService(IGenderRepository genderRepository) : base(genderRepository)
        {

        }
    }
}
