﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReportsDTO;
using MKW.Domain.Interface.Services.AppServices;
using System.Net.Mime;

namespace MKW.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("Reason")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReportReasonDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReportReasonDto>>> GetReasons([FromQuery] string language = "pt-BR")
            => Ok(await _reportService.GetReasons(language));

        [HttpGet("Status")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReportReasonDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReportReasonDto>>> GetStatus([FromQuery] string language = "pt-BR")
            => Ok(await _reportService.GetStatus(language));

        [HttpGet("Reason/id/{reasonId:int}")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReportReasonDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReportReasonDto>>> GetReasons([FromRoute] int reasonId, [FromQuery] string language = "pt-BR")
            => Ok(await _reportService.GetReasonById(reasonId, language));

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReportDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReportDto>>> GetReports
            (
            [FromQuery] int page = 1, [FromQuery] int pageSize = 10,
            [FromQuery] int? reasonId = null, [FromQuery] int? statusId = null,
            [FromQuery] string orderBy = "CreateDate", [FromQuery] bool orderByAscending = true,
            [FromQuery] string language = "pt-BR"
            )
            => Ok(await _reportService.GetReports(page, pageSize, reasonId, statusId, orderBy, orderByAscending, language));

        [HttpPost]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReportDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReportDto>>> AddReport([FromBody] CreateReportDto report)
            => Ok(await _reportService.AddReport(report));

        [HttpPost("Response")]
        [Authorize(Roles = "admin")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReportDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReportDto>>> RespondReport([FromBody] ReportResponseDto report)
            => Ok(await _reportService.RespondReport(report));

        [HttpPatch]
        [Authorize(Roles = "admin")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReportDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReportDto>>> UpdateReportStatus([FromBody] UpdateReportStatusDto report)
            => Ok(await _reportService.UpdateReportStatus(report));
    }
}
