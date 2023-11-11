using MKW.Domain.Dto.DTO.AwardDTO;
using MKW.Domain.Dto.DTO.Base;
using Stripe.Checkout;

namespace MKW.Domain.Interface.Services.BaseServices
{
    public interface IPaymentService
    {
        Task<BaseResponseDTO<AwardPurchaseDto>> CreatePaymentSession(params SessionLineItemOptions[] items);
    }
}
