using EntityManagement.DataAcces.DbContext_Entity;
using HospitalManagement.FolderLoggers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.ModdelRepozitory;
using ServicesManagement.Dtos.Configurations;
using ServicesManagement.ModdelRepository;
using ServicesManagement.ModdelRepository.InterfaceRepository;
using ServicesManagement.ModdelService;
using ServicesManagement.ModdelService.Interfaces;
using ServicesManagement.Settings;

namespace HospitalManagement.Extepsions;

public static  class DependencyIniection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IDoctorRepository,DoctorRepository>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<ICorrelationIdGenerator, CorrelationIdGenerator>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetDoctorQueryHandler).Assembly));

        return services;
    }
    public static IServiceCollection AddConfiguretions(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<AppointmentSettings>(configuration.GetSection("AppointmentSettings"));
        services.Configure<FileStorage>(configuration.GetSection("FileStorage"));
        services.AddOptions<DoctorsSettings>().Bind(configuration.GetSection("DoctorsSettings"))
            .ValidateDataAnnotations()
            .Validate((conf) =>
            {
                if (conf.WorkTime.Start >= conf.WorkTime.End)
                {
                    return false;
                }
                return true;
            }, "Start time should be less than end time");
        return services;
    }
}
