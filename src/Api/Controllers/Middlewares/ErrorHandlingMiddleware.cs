using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Av2.Api.Controllers.Contracts;
using Av2.Api.Core.Domain.Shared.Exceptions;

namespace Av2.Api.Controllers.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                var statusCode = exception switch
                {
                    NotFoundException => (int) HttpStatusCode.NotFound,
                    _ => (int) HttpStatusCode.InternalServerError
                };
                
                context.Response.StatusCode = statusCode;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                await context.Response.WriteAsJsonAsync(new ResponseDto(exception));
            }
        }
    }
}