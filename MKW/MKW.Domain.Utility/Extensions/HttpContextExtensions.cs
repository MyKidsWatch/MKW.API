using Microsoft.AspNetCore.Http;
using MKW.Domain.Utility.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Utility.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUserEmail(this HttpContext httpContext)
        {
            return httpContext.User?.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value ?? throw new NotFoundException("Usuário não encontrado");
        }
    }
}
