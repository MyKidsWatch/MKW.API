using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ChildDTO;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IChildService
    {
        Task<BaseResponseDTO<ChildDto>> GetById(int id);
        Task<BaseResponseDTO<ChildDto>> Get();
        Task<BaseResponseDTO<ChildDto>> AddChild(CreateChildDto childDto);
        Task<BaseResponseDTO<ChildDto>> UpdateChild(ChildDto childDto);
        Task DeleteChild(int childId);
    }
}
