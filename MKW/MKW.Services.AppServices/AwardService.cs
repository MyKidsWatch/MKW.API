using Microsoft.Extensions.Configuration;
using MKW.Domain.Dto.DTO.AwardDTO;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.ReviewAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Domain.Utility.Exceptions;

namespace MKW.Services.AppServices
{
    public class AwardService : IAwardService
    {
        private readonly IAwardRepository _awardRepository;
        private readonly IAwardPersonRepository _awardPersonRepository;
        private readonly IPersonService _personService;
        private readonly IReviewRepository _reviewRepository;
        private readonly IPaymentService _paymentService;
        private readonly IConfiguration _configuration;
        private readonly IOperationRepository _operationRepository;
        private readonly IOperationTypeRepository _operationTypeRepository;

        public AwardService(IAwardRepository awardRepository, IAwardPersonRepository awardPersonRepository,
            IPersonService personService, IReviewRepository reviewRepository, IPaymentService paymentService,
            IConfiguration configuration, IOperationRepository operationRepository, IOperationTypeRepository operationTypeRepository)
        {
            _awardPersonRepository = awardPersonRepository;
            _awardRepository = awardRepository;
            _personService = personService;
            _reviewRepository = reviewRepository;
            _paymentService = paymentService;
            _configuration = configuration;
            _operationRepository = operationRepository;
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<BaseResponseDTO<AwardDetailsDto>> GetAwards()
        {
            var responseDTO = new BaseResponseDTO<AwardDetailsDto>();
            var awards = await _awardRepository.GetActive() ?? throw new NotFoundException("Awards not found.");

            return responseDTO.AddContent(awards.Select(x => new AwardDetailsDto(x)));
        }

        public async Task<BaseResponseDTO<AwardPurchaseDto>> AddAward(GiveAwardDto model)
        {
            var responseDTO = new BaseResponseDTO<AwardPurchaseDto>();
            var award = await _awardRepository.GetById(model.AwardId) ?? throw new NotFoundException("Award not found.");
            var person = await _personService.GetUser();
            var review = await _reviewRepository.GetById(model.ReviewId) ?? throw new NotFoundException("Review not found");

            if (!award.Active) throw new BadRequestException("Award can not be given");
            if (review.PersonId == person.Id) throw new BadRequestException("User can not award themself");

            if (person.Balance < award.Price) return await _paymentService.GetPurchaseSession(person, award);

            await ProcessTransaction(person, award, review);

            var givenAward = new AwardPerson()
            {
                PersonId = person.Id,
                AwardId = award.Id,
                ReviewId = review.Id,
            };

            givenAward = await _awardPersonRepository.Add(givenAward);

            var awardDto = new AwardPurchaseDto()
            {
                Sucessful = true,
                Award = new GivenAwardDto(givenAward)
            };

            return responseDTO.AddContent(awardDto);
        }

        private async Task ProcessTransaction(Person person, Award award, Review review)
        {
            var typePurchase = await _operationTypeRepository.GetOperationByType("Purchase");
            var typeEarn = await _operationTypeRepository.GetOperationByType("Earn");

            var operationPurchase = new Operation()
            {
                OperationTypeId = typePurchase.Id,
                PersonId = person.Id,
                Coins = award.Price,
                Active = true
            };
            var operationEarned = new Operation()
            {
                OperationTypeId = typeEarn.Id,
                PersonId = review.Person.Id,
                Coins = award.Value,
                Active = true
            };
            await _operationRepository.AddRange(operationPurchase, operationEarned);

            person.Balance -= award.Price;
            review.Person.Balance += award.Value;

            await _personService.UpdateRange(person, review.Person);
        }
    }
}
