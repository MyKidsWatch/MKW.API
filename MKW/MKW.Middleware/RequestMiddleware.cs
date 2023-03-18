using Microsoft.AspNetCore.Http;
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
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
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

        //private async Task<string> GetBody(HttpContext context)
        //{
        //    var request = context.Request;

        //    if(request.Method == "POST" && request.ContentLength > 0)
        //    {

        //    }

        //    return "";
        //}
    }
}
