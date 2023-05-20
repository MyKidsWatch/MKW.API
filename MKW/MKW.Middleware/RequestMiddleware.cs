using Microsoft.AspNetCore.Http;
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
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleNotFoundExceptionAsync(HttpContext context, Exception exception)
        {
            var contentType = "application/json";
            var statusCode = (int)HttpStatusCode.NotFound;

            var response = JsonConvert.SerializeObject(exception.Message);

            context.Response.ContentType = contentType;
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(response);
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var contentType = "application/json";
            var statusCode = (int)HttpStatusCode.InternalServerError;

            var response = JsonConvert.SerializeObject(exception.Message);

            context.Response.ContentType = contentType;
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(response);
        }
    }
}
