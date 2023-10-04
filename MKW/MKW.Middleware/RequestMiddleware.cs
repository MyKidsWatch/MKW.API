using Microsoft.AspNetCore.Http;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Utility.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace MKW.Middleware
{
    public class RequestMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundException ex)
            {
                await HandleNotFoundExceptionAsync(context, ex);
            }
            catch (BadRequestException ex)
            {
                await HandleBadRequestExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleNotFoundExceptionAsync(HttpContext context, NotFoundException exception)
        {
            var contentType = "application/json";
            var statusCode = (int)HttpStatusCode.BadRequest;

            var resposta = new BaseResponseDTO<string>().WithErrors(exception.Errors);
            var response = JsonConvert.SerializeObject(resposta);

            context.Response.ContentType = contentType;
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(response);
        }

        private async Task HandleBadRequestExceptionAsync(HttpContext context, BadRequestException exception)
        {
            var contentType = "application/json";
            var statusCode = (int)HttpStatusCode.NotFound;

            var resposta = new BaseResponseDTO<string>().WithErrors(exception.Errors);
            var response = JsonConvert.SerializeObject(resposta);

            context.Response.ContentType = contentType;
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(response);
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var contentType = "application/json";
            var statusCode = (int)HttpStatusCode.InternalServerError;

            var resposta = new BaseResponseDTO<string>().AddError(exception.Message);
            var response = JsonConvert.SerializeObject(resposta);

            context.Response.ContentType = contentType;
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(response);
        }
    }
}
