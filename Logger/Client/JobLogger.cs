using Logger.Factory;
using Logger.Product;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Logger.Client
{
    public class JobLogger
    {
        private readonly AbstractLogger _logger;

        public JobLogger(FactoryLogger factoryLogger)
        {
            _logger = factoryLogger.CreateLogger();
        }
        public void LogMessage(string message, bool isMessage, bool warning, bool error)
        {
            message = message.Trim();
            if (string.IsNullOrEmpty(message))
            {
                throw new Exception("Message is empty");
            }
            if (!isMessage && !warning && !error)
            {
                throw new Exception("Error or Warning or Message must be specified");
            }
            if (isMessage)
                _logger.LogMessage(message);
            if (warning)
                _logger.LogWarning(message);
            if (error)
                _logger.LogError(message);
        }
    }    
}
