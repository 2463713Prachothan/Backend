using System.Net;
using System.Text.Json;
using TimeTrack.API.DTOs.Common;

namespace TimeTrack.API.Middleware;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var response = exception switch
        {
            KeyNotFoundException => CreateErrorResponse(
                HttpStatusCode.NotFound,
                "Resource not found",
                exception.Message
            ),
            UnauthorizedAccessException => CreateErrorResponse(
                HttpStatusCode.Unauthorized,
                "Unauthorized access",
                exception.Message
            ),
            InvalidOperationException => CreateErrorResponse(
                HttpStatusCode.BadRequest,
                "Invalid operation",
                exception.Message
            ),
            ArgumentException => CreateErrorResponse(
                HttpStatusCode.BadRequest,
                "Invalid argument",
                exception.Message
            ),
            _ => CreateErrorResponse(
                HttpStatusCode.InternalServerError,
                "Internal server error",
                "An unexpected error occurred. Please try again later."
            )
        };

        context.Response.StatusCode = (int)response.StatusCode;

        var jsonResponse = JsonSerializer.Serialize(response.ErrorResponse, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(jsonResponse);
    }

    private static (HttpStatusCode StatusCode, ApiResponseDto<object> ErrorResponse) CreateErrorResponse(
        HttpStatusCode statusCode,
        string message,
        string detail)
    {
        return (statusCode, ApiResponseDto<object>.ErrorResponse(message, new List<string> { detail }));
    }
}