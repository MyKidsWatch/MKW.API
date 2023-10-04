using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKW.API.Controllers.Base;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ContentDTO;
using MKW.Domain.Dto.DTO.TmdbDTO;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Utility.Enums;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace MKW.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ContentController : BaseController
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet("id/{contentId:int}")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ContentDetailsDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ContentDetailsDTO>>> GetContentById([FromRoute] int contentId, [FromQuery] string language = "pt-BR")
            => Ok(await _contentService.GetContentDetailsById(contentId, language));

        [HttpGet("external/{platformId:int}/{externalContentId}")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ContentDetailsDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ContentDetailsDTO>>> GetExternalContentById([FromRoute] string externalContentId, [FromRoute] PlatformEnum platformId, [FromQuery] string language = "pt-BR")
            => Ok(await _contentService.GetContentDetailsByExternalId(externalContentId, (int)platformId, language));

        [HttpGet]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ContentListItemDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ContentListItemDTO>>> GetContentByName([Required][FromQuery] string query, [FromQuery] PlatformEnum? platformId, [FromQuery] string language = "pt-BR")
            => Ok(await _contentService.GetContentByName(query, (int?)platformId, language));
    }
}
