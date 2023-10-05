using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Test.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);

            }
            catch (Exception ex)
            {
                if (ex.GetType().Name== "ValidationException")
                {
                    var result = JsonSerializer.Serialize(new { message = ex.Message });
                    httpContext.Response.ContentType = "application/json";
                    httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                    httpContext.Response.WriteAsync(result);
                }
                else
                {
                    var result = JsonSerializer.Serialize(new { message = ex.ToString() });
                    httpContext.Response.ContentType = "application/json";
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    httpContext.Response.WriteAsync(result);
                }


            }
        }
    }
}
