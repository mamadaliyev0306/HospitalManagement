
using EntityManagement.DataAcces.DbContext_Entity;
using HospitalManagement.AutoMapper;
using HospitalManagement.Extepsions;
using HospitalManagement.Middlewares;
using HospitalManagement.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using ServicesManagement.ModdelService;
using ServicesManagement.Settings;
using System.Reflection;

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
            builder.Services.AddConfiguretions(configuration);
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(typeof(MapperProfile));
            //Serilog configuration
            builder.Host.SeriloConfig();

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
