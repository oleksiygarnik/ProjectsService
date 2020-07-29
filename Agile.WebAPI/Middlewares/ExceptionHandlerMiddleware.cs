using Domain;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Agile.WebAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context) => InvokeAsync(context);

        private async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                int httpStatusCode = GetExceptionStatusCode(e);

                context.Response.StatusCode = httpStatusCode;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(
                    JsonConvert.SerializeObject(new
                    {
                        ExceptionType = e.GetType().Name,
                        e.Message
                    }));
            }
        }

        private static int GetExceptionStatusCode(Exception exception)
        {
            return exception switch
            {
                var _ when
                    exception is NotFoundException ||
                    exception is ArgumentException =>
                    (int)HttpStatusCode.NotFound,

                _ => (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
