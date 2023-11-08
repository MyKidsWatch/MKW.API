using MKW.Domain.Dto.DTO.AwardDTO;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.ReviewAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Utility.Exceptions;

namespace MKW.Services.AppServices
{
    public class AwardService : IAwardService
    {
        private readonly IAwardRepository _awardRepository;
        private readonly IAwardPersonRepository _awardPersonRepository;
        private readonly IPersonService _personService;
        private readonly IReviewRepository _reviewRepository;

        public AwardService(IAwardRepository awardRepository, IAwardPersonRepository awardPersonRepository, IPersonService personService, IReviewRepository reviewRepository)
        {
            _awardPersonRepository = awardPersonRepository;
            _awardRepository = awardRepository;
            _personService = personService;
            _reviewRepository = reviewRepository;
        }

        public async Task<BaseResponseDTO<AwardDetailsDto>> GetAwards()
        {
            var responseDTO = new BaseResponseDTO<AwardDetailsDto>();
            var awards = await _awardRepository.GetActive() ?? throw new NotFoundException("Awards not found.");

            return responseDTO.AddContent(awards.Select(x => new AwardDetailsDto(x)));
        }

        // TODO: transformar método em transacional para garantir que as alterações de Balance só terão efeito quando/se a entrega do prêmio for realizada com sucesso
        public async Task<BaseResponseDTO<GivenAwardDto>> AddAward(GiveAwardDto model)
        {
            var responseDTO = new BaseResponseDTO<GivenAwardDto>();
            var award = await _awardRepository.GetById(model.AwardId) ?? throw new NotFoundException("Award not found.");
            var person = await _personService.GetUser();
            var review = await _reviewRepository.GetById(model.ReviewId) ?? throw new NotFoundException("Review not found");

            if (!award.Active) throw new BadRequestException("Award can not be given");
            if (review.PersonId == person.Id) throw new BadRequestException("User can not award themself");
            if (person.Balance < award.Price) throw new BadRequestException("User does not have enough coins");

            await ProcessTransaction(person, award, review);

            var givenAward = new AwardPerson()
            {
                PersonId = person.Id,
                AwardId = award.Id,
                ReviewId = review.Id,
            };

            givenAward = await _awardPersonRepository.Add(givenAward);

            return responseDTO.AddContent(new GivenAwardDto(givenAward));
        }


        private async Task ProcessTransaction(Person person, Award award, Review review)
        {
            person.Balance -= award.Price;
            await _personService.Update(person);

            review.Person.Balance += award.Value;
            await _personService.Update(review.Person);
        }
    }
}
