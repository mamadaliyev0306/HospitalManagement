using FluentValidation;
using Microsoft.Extensions.Options;

namespace HospitalManagement.Middlewares
{
    public class ConfigurationValidatorMiddleware
    {
        private RequestDelegate _next;

        public ConfigurationValidatorMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
               await _next(context);
            }
            catch (OptionsValidationException a) 
            {
                //Console.WriteLine("Error OptionsValidationException ???" + a.Failures);
                await context.Response.WriteAsync("Error OptionsValidationException ???" + a.Failures);
                
            }
 
        }
    }
}
