using Microsoft.Extensions.Configuration;
using MKW.Domain.Dto.DTO.AwardDTO;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Services.BaseServices;
using Stripe.Checkout;

namespace MKW.Services.BaseServices
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly SessionService _sessionService;

        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
            _sessionService = new SessionService();
        }

        public async Task<Session> CreatePaymentSession(params SessionLineItemOptions[] items)
        {
            var options = new SessionCreateOptions
            {
                LineItems = items.ToList(),
                Mode = "payment",
                SuccessUrl = "https://localhost:4040/a",
                CancelUrl = "https://localhost:4040/a",
            };

            return _sessionService.Create(options);
        }

        public async Task<Session> GetSession(string sessionId)
        {
            return _sessionService.Get(sessionId);
        }

        public async Task<BaseResponseDTO<AwardPurchaseDto>> GetAwardPurchaseSession(params SessionLineItemOptions[] items)
        {
            var session = await CreatePaymentSession(items);

            var response = new BaseResponseDTO<AwardPurchaseDto>();

            var award = new AwardPurchaseDto()
            {
                Sucessful = false,
                CheckoutUrl = session.Url
            };

            return response.AddContent(award);
        }

        public async Task<BaseResponseDTO<AwardPurchaseDto>> GetPurchaseSession(Person person, Award award)
        {
            var item = new SessionLineItemOptions();

            if (person.Balance == 0)
            {
                item.Price = award.StripeId;
                item.Quantity = 1;
            }
            else
            {
                var remainingCoins = award.Price - person.Balance;

                item.Price = _configuration["API:Stripe:Coin"];
                item.Quantity = remainingCoins;
            }

            return await GetAwardPurchaseSession(item);
        }
    }
}
