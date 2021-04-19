using JWTClaimsDemo.Extensions;
using JWTClaimsDemo.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace JWTClaimsDemo.Extentions.Exceptions
{
    public class ExceptionService
    {
        public static Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return WriteException(context, ex);
        }
        public static Task HandleCustomException(HttpContext context, CustomException ex)
        {
            context.Response.Clear();
            context.Response.StatusCode = ex.StatusCode;
            context.Response.ContentType = ex.ContentType;
            return WriteException(context, ex);
        }
        public static Task WriteException(HttpContext context, dynamic ex)
        {
            return context.Response.WriteAsync(new ErrorDetail()
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.InnerException?.Message ?? ex.Message
            }.ToJSONString());
        }
    }
    public static class Middleware
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
