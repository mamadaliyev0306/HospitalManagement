
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
            //builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddDbContext<HospitalContext>(options =>
                options.UseNpgsql(connectionString));
            builder.Services.AddControllers();
            //builder.Services.Configure<DoctorsSettings>(
            //builder.Configuration.GetSection("DoctorsSettings"));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDependencies();
            builder.Services.AddControllers();

            builder.Services.Configure<AppointmentSettings>(configuration.GetSection("AppointmentSettings"));
            builder.Services.Configure<FileStorage>(configuration.GetSection("FileStorage"));
            //File ga yozish
            builder.Host.ConfigureLogging((context, logging) =>
            {
                logging.AddFileLogging(option =>
                {
                    context.Configuration.GetSection("FolderLoggers:Options").Bind(option);
                });
            });
            builder.Services.AddSerilog((serviceProvider, configurationLogging) =>
            {
                configurationLogging.ReadFrom.Configuration(configuration);
            });
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
            
            

            //builder.Services.Configure<PdpSettings>(configuration.GetSection("PdpSettings"));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<GlobalLoggingMiddleware>();
            app.UseMiddleware<ConfigurationValidatorMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}
