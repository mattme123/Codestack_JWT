using System;
using System.Threading.Tasks;
using JWTClaimsDemo.Extentions.Exceptions;
using Microsoft.AspNetCore.Http;

namespace JWTClaimsDemo.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomException ex)
            {
                await ExceptionService.HandleCustomException(httpContext, ex);
            }
            catch (Exception ex)
            {
                await ExceptionService.HandleException(httpContext, ex);
            }
        }
    }
}
