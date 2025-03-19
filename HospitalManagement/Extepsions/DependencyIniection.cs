using EntityManagement.DataAcces.DbContext_Entity;
using HospitalManagement.FolderLoggers;
using Microsoft.EntityFrameworkCore;
using Services.ModdelRepozitory;
using ServicesManagement.Configurations;
using ServicesManagement.ModdelRepository;
using ServicesManagement.ModdelRepository.InterfaceRepository;
using ServicesManagement.ModdelService;
using ServicesManagement.ModdelService.Interfaces;

namespace HospitalManagement.Extepsions
{
    public static  class DependencyIniection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository,DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<ICorrelationIdGenerator, CorrelationIdGenerator>();
            return services;
        }

    }
}
