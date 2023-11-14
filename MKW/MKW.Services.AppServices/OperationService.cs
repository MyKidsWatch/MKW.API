using Microsoft.Extensions.Configuration;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.OperationDTO;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Domain.Utility.Exceptions;
using Stripe.Checkout;

namespace MKW.Services.AppServices
{
    public class OperationService : IOperationService
    {
        private readonly IPersonService _personService;
        private readonly IOperationRepository _operationRepository;
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IPaymentService _paymentService;
        private readonly IConfiguration _configuration;

        public OperationService(IPersonService personService, IOperationRepository operationRepository, IConfiguration configuration,
                              IOperationTypeRepository operationTypeRepository, IPaymentService paymentService)
        {
            _personService = personService;
            _operationRepository = operationRepository;
            _operationTypeRepository = operationTypeRepository;
            _paymentService = paymentService;
            _configuration = configuration;
        }

        public async Task<BaseResponseDTO<OperationDto>> GetOperationStatus(int operationId)
        {
            var response = new BaseResponseDTO<OperationDto>();

            var user = await _personService.GetUser();
            var operation = await _operationRepository.GetById(operationId) ?? throw new NotFoundException("Operation not found");
            if (operation.PersonId != user.Id) throw new BadRequestException("User is not buyer");

            var session = await _paymentService.GetSession(operation.StripeId);

            if (session.PaymentStatus.ToLower() != "paid")
                return response.AddContent(new OperationDto(operation)
                {
                    CheckoutUrl = session.ClientSecret,
                    PaymentStatus = session.PaymentStatus,
                    Finished = false
                });

            if (!operation.Active)
            {
                operation.Active = true;
                await _operationRepository.Update(operation);

                user.Balance += operation.Coins;
                await _personService.Update(user);
            }

            return response.AddContent(new OperationDto(operation)
            {
                PaymentStatus = session.PaymentStatus,
                Finished = true
            });
        }

        public async Task<BaseResponseDTO<OperationDto>> AddFunds(AddFundDto model)
        {
            var user = await _personService.GetUser();
            var operationType = await _operationTypeRepository.GetOperationByType("Purchase");

            var sessionItem = new SessionLineItemOptions()
            {
                Price = _configuration["API:Stripe:Coin"],
                Quantity = model.Coins
            };

            var session = await _paymentService.CreatePaymentSession(user.User.Email, sessionItem);

            var operation = new Operation()
            {
                OperationTypeId = operationType?.Id ?? 0,
                PersonId = user.Id,
                Coins = model.Coins,
                StripeId = session.Id,
                Active = false
            };

            operation = await _operationRepository.Add(operation);

            return new BaseResponseDTO<OperationDto>().AddContent(new OperationDto(operation)
            {
                CheckoutUrl = session.ClientSecret,
                PaymentStatus = session.PaymentStatus,
                Finished = false
            });
        }

    }
}
