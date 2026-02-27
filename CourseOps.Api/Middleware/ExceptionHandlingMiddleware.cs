using CourseOps.Api.DTOs.Common;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CourseOps.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception. TraceId: {TraceId}", context.TraceIdentifier);

                var (statusCode, message) = ex switch
                {
                    DbUpdateConcurrencyException => (StatusCodes.Status409Conflict, "The record was modified by another user."),
                    _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
                };

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                var response = new ErrorResponse
                {
                    StatusCode = statusCode,
                    Message = message,
                    TraceId = context.TraceIdentifier
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
