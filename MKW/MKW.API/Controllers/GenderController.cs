using Microsoft.AspNetCore.Mvc;
using MKW.API.Controllers.Base;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;

namespace MKW.API.Controllers
{
    [Route("v1/[controller]")]
    public class GenderController : CrudBaseController<Gender>
    {

        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService) : base(genderService)
        {
            _genderService = genderService;
        }
    }
}
