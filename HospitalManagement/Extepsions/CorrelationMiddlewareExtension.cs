using HospitalManagement.Middlewares;

namespace HospitalManagement.Extepsions
{
    public static class CorrelationMiddlewareExtension
    {
        public static IApplicationBuilder AddCorrelation(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalLoggingMiddleware>();
            app.UseMiddleware<ConfigurationValidatorMiddleware>();
            app.UseMiddleware<CorrelationIdMiddleware>();
            return app;
        }
    }
}
