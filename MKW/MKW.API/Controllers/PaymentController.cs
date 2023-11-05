using Microsoft.AspNetCore.Http;
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
    }
}
