using MKW.Domain.Dto.DTO.AwardDTO;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;
using Stripe.Checkout;

namespace MKW.Domain.Interface.Services.BaseServices
{
    public interface IPaymentService
    {
        Task<Session> CreatePaymentSession(params SessionLineItemOptions[] items);
        Task<Session> GetSession(string sessionId);
        Task<BaseResponseDTO<AwardPurchaseDto>> GetAwardPurchaseSession(params SessionLineItemOptions[] items);
        Task<BaseResponseDTO<AwardPurchaseDto>> GetPurchaseSession(Person person, Award award);
    }
}
