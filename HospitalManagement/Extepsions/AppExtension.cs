using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace HospitalManagement.Extepsions
{
    public static class AppExtension
    {
        public static void SeriloConfig(this IHostBuilder builder)
        {
            builder.UseSerilog((context, configurationLogging) =>
            {
                var config = context.Configuration;
                var logLevel = config.GetValue("Serilog:MinimumLevel", LogEventLevel.Information);
                var logLevelString = logLevel.ToString();
                var logFilePath = $"C:\\Yangi\\HospitalManagement\\HospitalManagement\\SerilogFile\\{logLevel}-.log";
                configurationLogging
                .ReadFrom.Configuration(config)
                .WriteTo.Console()
                .WriteTo.File(logFilePath,rollingInterval:RollingInterval.Day);
            });
        }
        public static void LoggingFile(this IHostBuilder builder)
        {
            builder.ConfigureLogging((context, logging) =>
            {
                logging.AddFileLogging(option =>
                {
                    context.Configuration.GetSection("FolderLoggers:Options").Bind(option);
                });
            });
        }
    }
}
