using BookingSystem.Application.Exceptions;
using System.Net;
using System.Security.Authentication;
using System.Text.Json;

namespace BookingSystem.Api.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertApiException(context, ex);
            }
        }

        private Task ConvertApiException(HttpContext context, Exception ex)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType= "application/json";

            var result = string.Empty;

            switch(ex)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.ValidationErrors);
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    result = notFoundException.Message;
                    break;
                case UnauthorizedAccessException:
                    httpStatusCode = HttpStatusCode.Unauthorized;
                    break;
                case AuthenticationException:
                    httpStatusCode = HttpStatusCode.Forbidden;
                    break;
                case Exception:
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;

            if(result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = ex.Message });
            }

             return context.Response.WriteAsync(result);
        }
    }
}