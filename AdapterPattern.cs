using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    // Сторонний класс
    public class ExternalLogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"External log: {message}");
        }
    }

    // Целевой интерфейс
    public interface ILogger
    {
        void Log(string message);
    }

    // Адаптер
    public class LoggerAdapter : ILogger
    {
        private ExternalLogger externalLogger;

        public LoggerAdapter(ExternalLogger logger)
        {
            externalLogger = logger;
        }

        public void Log(string message)
        {
            externalLogger.LogMessage(message);
        }
    }

}
