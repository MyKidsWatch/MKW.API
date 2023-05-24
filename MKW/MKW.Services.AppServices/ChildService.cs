using Microsoft.AspNetCore.Http;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ChildDTO;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Utility.Exceptions;
using System.Security.Claims;

namespace MKW.Services.AppServices
{
    public class ChildService : IChildService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonChildRepository _personChildRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChildService(IPersonChildRepository personChildRepository, IHttpContextAccessor httpContextAccessor, IPersonRepository personRepository)
        {
            _personChildRepository = personChildRepository;
            _httpContextAccessor = httpContextAccessor;
            _personRepository = personRepository;
        }

        public async Task<BaseResponseDTO<ChildDto>> GetById(int id)
        {
            var child = await _personChildRepository.GetById(id);

            if (child == null) throw new NotFoundException("Criança não encontrada");

            return new BaseResponseDTO<ChildDto>().AddContent(new ChildDto(child));
        }

        public async Task<BaseResponseDTO<ChildDto>> Get()
        {
            var user = await GetUser();

            return new BaseResponseDTO<ChildDto>().AddContent(user.Children?.Where(x => x.Active).Select(x => new ChildDto(x)));
        }

        public async Task<BaseResponseDTO<ChildDto>> AddChild(CreateChildDto childDto)
        {
            var user = await GetUser();

            var child = new PersonChild()
            {
                PersonId = user.Id,
                AgeRangeId = childDto.AgeRangeId,
                GenderId = childDto.GenderId,
            };

            child = await _personChildRepository.Add(child);

            var createdChildDto = new ChildDto(child);

            return new BaseResponseDTO<ChildDto>().AddContent(createdChildDto);
        }

        public async Task<BaseResponseDTO<ChildDto>> UpdateChild(ChildDto childDto)
        {
            var user = await GetUser();

            var child = new PersonChild()
            {
                Id = childDto.Id,
                PersonId = user.Id,
                AgeRangeId = childDto.AgeRangeId,
                GenderId = childDto.GenderId,
            };

            child = await _personChildRepository.Update(child);

            var createdChildDto = new ChildDto(child);

            return new BaseResponseDTO<ChildDto>().AddContent(createdChildDto);
        }

        public async Task DeleteChild(int childId)
        {
            await _personChildRepository.DeleteById(childId);
        }

        public async Task<Person> GetUser()
        {
            var email = _httpContextAccessor.HttpContext?.User?.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value;
            var user = await _personRepository.GetByEmail(email);

            if (user == null) throw new NotFoundException("Usuário não encontrado.");

            return user;
        }
    }
}
