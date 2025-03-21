
using EntityManagement.DataAcces.DbContext_Entity;
using HospitalManagement.Extepsions;
using HospitalManagement.Middlewares;
using HospitalManagement.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using ServicesManagement.ModdelService;
using ServicesManagement.Settings;

namespace HospitalManagement
{
    
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<HospitalContext>(options =>
                options.UseNpgsql(connectionString));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDependencies();
            //Serilog configuration
            builder.Host.SeriloConfig();
            builder.Services.Configure<AppointmentSettings>(configuration.GetSection("AppointmentSettings"));
            builder.Services.Configure<FileStorage>(configuration.GetSection("FileStorage"));
            builder.Services.AddOptions<DoctorsSettings>().Bind(configuration.GetSection("DoctorsSettings"))
                .ValidateDataAnnotations()
                .Validate((conf) =>
                {
                    if (conf.WorkTime.Start >= conf.WorkTime.End)
                    {
                        return false;
                    }
                    return true;
                }, "Start time should be less than end time");
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.AddCorrelationExtension();
 
            app.MapControllers();

            app.Run();
        }
    }
}
