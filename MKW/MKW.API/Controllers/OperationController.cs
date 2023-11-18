using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKW.Domain.Dto.DTO.AwardDTO;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.OperationDTO;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Services.AppServices;
using System.Net.Mime;

namespace MKW.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpGet("{operationId:int}")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<AwardPurchaseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<OperationDto>>> GetOperation([FromRoute] int operationId)
            => Ok(await _operationService.GetOperationStatus(operationId));

        [HttpPost("Funds")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<OperationDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<OperationDto>>> AddFunds([FromBody] AddFundDto coins)
            => Ok(await _operationService.AddFunds(coins));
    }
}
