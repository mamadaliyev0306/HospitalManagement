using HospitalManagement.Exceptions;
using System.Net;
using System.Text.Json;
using KeyNotFoundException = HospitalManagement.Exceptions.KeyNotFoundException;
using NotImplementedException = HospitalManagement.Exceptions.NotImplementedException;
using UnauthorizedAccessException = HospitalManagement.Exceptions.UnauthorizedAccessException;

namespace HospitalManagement.Middlewares;

public class GlobalLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExtensionsAsync(context, ex);
        }
    }
    private async Task HandleExtensionsAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode;
        string message= "";
        var StackTrace = string.Empty;
        var exceptionType = exception.GetType();
        if (exceptionType == typeof(NotFountException))
        {
            StackTrace = exception.StackTrace;
            message = exception.Message;
            statusCode = HttpStatusCode.NotFound;
        }
        else if(exceptionType == typeof(BadRequestException))
        {
             StackTrace = exception.StackTrace;
             message = exception.Message;
             statusCode = HttpStatusCode.BadRequest;
        }
        else if (exceptionType == typeof(KeyNotFoundException))
        {
            StackTrace = exception.StackTrace;
            message = exception.Message;
            statusCode = HttpStatusCode.NotFound;
        }
        else if (exceptionType == typeof(UnauthorizedAccessException))
        {
            StackTrace = exception.StackTrace;
            message = exception.Message;
            statusCode = HttpStatusCode.Unauthorized;
        }
        else if (exceptionType == typeof(NotImplementedException))
        {
            StackTrace = exception.StackTrace;
            message = exception.Message;
            statusCode = HttpStatusCode.NotImplemented;
        }
        else
        {
            StackTrace = exception.StackTrace;
            message = exception.Message;
            statusCode = HttpStatusCode.InternalServerError;
        }
        var exceptionResult= JsonSerializer.Serialize(new {error = message, StackTrace });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsync(exceptionResult);
    }
}
