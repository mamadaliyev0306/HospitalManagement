
using HospitalManagement.FolderLoggers.Options;
using Microsoft.Extensions.Options;

namespace HospitalManagement.FolderLoggers.Proverts
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private bool disposedValue;
        public readonly FileOption Options;
        public FileLoggerProvider(IOptions<FileOption> options)
        {
            Options=options.Value;
            if(!Directory.Exists(Options.FolderPath))
            {
              Directory.CreateDirectory(Options.FolderPath);
            }
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new FileWriteType(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
