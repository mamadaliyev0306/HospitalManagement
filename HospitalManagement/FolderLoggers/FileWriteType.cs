
using HospitalManagement.FolderLoggers.Proverts;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HospitalManagement.FolderLoggers
{
    public class FileWriteType : ILogger
    {
        private readonly FileLoggerProvider _options;
        public FileWriteType(FileLoggerProvider options)
        {
            _options = options;
        }
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            bool result=(logLevel==LogLevel.None);
            return result;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                return;
            }
            string fileName = $"log_{logLevel}_{DateTimeOffset.Now:yyyy-MM-dd}.log";
            string filePath = Path.Combine(_options.Options.FolderPath, fileName);
            string logMessage = $"| {DateTimeOffset.Now:yyyy-MM-dd HH:mm:ss+00} | {logLevel} | {exception} | {eventId} | {formatter(state,exception)} | {exception?.StackTrace??""}";
            using(var streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(logMessage);
            }
        }
    }
}
