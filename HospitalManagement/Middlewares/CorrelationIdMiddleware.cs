using Microsoft.EntityFrameworkCore;
using FluentValidation;
using ServicesManagement.Configurations;
using Microsoft.Extensions.Options;

namespace HospitalManagement.Middlewares
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private const string _correlationIdHeader = "X-correlation-Id";
        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, ICorrelationIdGenerator correlationIdGenerator)
        {
            var correlationId = GetCorrelationIdTrace(context, correlationIdGenerator);
            AddCorrelationIdToRespons(context, correlationId);
            await _next(context);
        }
        private static string GetCorrelationIdTrace(HttpContext context, ICorrelationIdGenerator correlationIdGenerator)
        {
            if (context.Response.Headers.TryGetValue(_correlationIdHeader, out var correlationId))
            {
                correlationIdGenerator.Set(correlationId);
                return correlationId;
            }
            return correlationIdGenerator.Get();
        }
        private static void AddCorrelationIdToRespons(HttpContext context, string correlationId)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Add(_correlationIdHeader, new[] {correlationId });
                return Task.CompletedTask;
            });
        }
    }
}
