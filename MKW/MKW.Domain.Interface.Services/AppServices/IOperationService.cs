﻿using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.OperationDTO;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IOperationService
    {
        Task<BaseResponseDTO<OperationDto>> AddFunds(AddFundDto model);
        Task<BaseResponseDTO<OperationDto>> GetOperationStatus(int operationId);
    }
}
