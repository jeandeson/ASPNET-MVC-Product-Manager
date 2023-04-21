using Microsoft.AspNetCore.Http;
using Model.Errors;
using Newtonsoft.Json;
using System.Net;

namespace WebApplication2.Middlewares
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _log;

        public ErrorHandler(RequestDelegate next, ILoggerFactory log)
        {
            _next = next;
            _log = log.CreateLogger("MyErrorHandler");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                 HandleErrorAsync(httpContext, ex);
            }
        }

        private void HandleErrorAsync(HttpContext context, Exception exception)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Internal server error";

            if(exception is CustomException customException)
            {
                message = customException.Message;
                statusCode = (int)customException.StatusCode;
            }
            else if (exception.InnerException is CustomException innerCustomException)
            {
                message = innerCustomException.Message;
                statusCode = (int)innerCustomException.StatusCode;
            }
            _log.LogError($"Error: {exception.Message}");
            _log.LogError($"Stack: {exception.StackTrace}");

            context.Response.Cookies.Append("ErrorMessage", message);
            context.Response.Redirect($"/Error/{statusCode}");
        }
    }
}
