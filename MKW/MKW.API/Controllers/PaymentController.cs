using Microsoft.AspNetCore.Mvc;
using MKW.API.Controllers.Base;
using MKW.Domain.Interface.Services.BaseServices;

namespace MKW.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        //[HttpGet]
        //public async Task<ActionResult<BaseResponseDTO<string>>> GetPaymentSession() => Ok(await _paymentService.CreatePaymentSession());
    }
}
