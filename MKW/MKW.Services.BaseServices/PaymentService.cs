using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Interface.Repository.ReviewAggregate;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Domain.Utility.Exceptions;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Services.BaseServices
{
    public class PaymentService : IPaymentService
    {
        private readonly IAwardRepository _awardRepository;

        public PaymentService(IAwardRepository awardRepository)
        {
            _awardRepository = awardRepository;
        }

        public async Task<BaseResponseDTO<string>> CreatePaymentSession()
        {
            var awards = await _awardRepository.GetActive() ?? throw new NotFoundException("No awards found");

            var options = new SessionCreateOptions
            {
                LineItems = awards.Select(x => new SessionLineItemOptions()
                {
                    Price = x.StripeId,
                    Quantity = 1
                }).ToList(),
                Mode = "payment",
                SuccessUrl = "https://localhost:4040/a",
                CancelUrl = "https://localhost:4040/a",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            var response = new BaseResponseDTO<string>();

            return response.AddContent(session.Url);
        }
    }
}
