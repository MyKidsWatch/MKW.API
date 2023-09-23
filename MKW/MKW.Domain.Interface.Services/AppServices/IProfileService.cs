using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.PersonDTO;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IProfileService
    {
        Task<BaseResponseDTO<ReadProfileDTO>> GetProfileByUsername(string username);
        Task<BaseResponseDTO<IEnumerable<ReadProfileDTO>>> GetAllProfilesByUsername(string username);
    }
}