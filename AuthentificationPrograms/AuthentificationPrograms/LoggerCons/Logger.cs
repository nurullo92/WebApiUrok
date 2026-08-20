using AuthentificationPrograms.Logger;

namespace AuthentificationPrograms.LoggerCons
{
    public class Loggers : ILoggers
    {
        private static readonly ReaderWriterLockSlim _lock = new();

        private readonly string _logDirectory;

        public Loggers()
        {
            _logDirectory = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "_lock");

            Directory.CreateDirectory(_logDirectory);
        }

        public void EventLog(string evnmessage)
        {
            _lock.EnterWriteLock();

            try
            {
                using var writer = new StreamWriter(
                    Path.Combine(_logDirectory, "events.txt"),
                    append: true);

                writer.WriteLine(evnmessage);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void ErrorLog(string evnmessage)
        {
            _lock.EnterWriteLock();

            try
            {
                using var writer = new StreamWriter(
                    Path.Combine(_logDirectory, "error.txt"),
                    append: true);

                writer.WriteLine(evnmessage);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }



    }
}