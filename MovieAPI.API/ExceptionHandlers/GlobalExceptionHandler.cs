using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Service.Exceptions;

namespace MovieAPI.API.ExceptionHandlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {

        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(
                exception,
                "An unhandled exception occured."
            );

            int statusCode = exception switch
            {
                ConflictException => StatusCodes.Status409Conflict,
                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError,

            };

            string detail = exception switch
            {
                NotFoundException => exception.Message,
                ConflictException => exception.Message,
                UnauthorizedException => exception.Message,
                _ => "An unexpected error occured."
            };

            string title = exception switch
            {
                NotFoundException => "Not Found",
                ConflictException => "Conflict",
                UnauthorizedException => "Unauthorized",
                _ => "Internal Server Error"
            };

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = detail
            };

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsJsonAsync(
                problemDetails,
                cancellationToken
            );

            return true;
        }
    }
}