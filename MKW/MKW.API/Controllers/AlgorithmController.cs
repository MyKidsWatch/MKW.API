﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKW.API.Controllers.Base;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Interface.Services.BaseServices;
using System.Net.Mime;

namespace MKW.API.Controllers
{
    [Route("v1/[controller]")]
    public class AlgorithmController : BaseController
    {
        private readonly IAlgorithmService _algorithmService;
        public AlgorithmController(IAlgorithmService algorithmService)
        {
            _algorithmService = algorithmService;
        }

        //[HttpGet]
        //[Authorize]
        //[Produces(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReviewDto>))]
        //[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        //public async Task<ActionResult<BaseResponseDTO<IEnumerable<ReviewDto>>>> AlgorithmTest([FromQuery] int page = 1, [FromQuery] int count = 20)
        //    => Ok(await _algorithmService.GetRecommended(page, count));

        [HttpGet]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<object>>> AlgorithmTest([FromQuery] int page = 1, [FromQuery] int count = 20, [FromQuery] string language = "pt-BR")
             => Ok(await _algorithmService.GetRelevantMovies(page, count,language));
    }
}
