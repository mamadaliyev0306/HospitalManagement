using HospitalManagement.FolderLoggers.Options;
using HospitalManagement.FolderLoggers.Proverts;

namespace HospitalManagement.Extepsions
{
    public static class FileLoggerExtension
    {
        public static ILoggingBuilder AddFileLogging(this ILoggingBuilder builder,Action<FileOption> option)
        {
            builder.Services.AddSingleton<ILoggerProvider, FileLoggerProvider>();
            builder.Services.Configure(option);
            return builder;
        }
    }
}
