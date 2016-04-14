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

        public AbstractLogger Logger { get; set; }

        public JobLogger(FactoryLogger factoryLogger)
        {
            _logger = factoryLogger.CreateLogger();
        }
        public void LogMessage(string message, bool isMessage, bool warning, bool error)
        {
            message = message.Trim();
            if (string.IsNullOrEmpty(message))
            {
                //TODO: include in the document
                throw new ArgumentException("Message is empty");
            }
            if (!isMessage && !warning && !error)
            {
                throw new ArgumentException("Error or Warning or Message must be specified");
            }
            if ((isMessage && (warning || error)) || (warning && (isMessage || error)) || (error && (isMessage || warning)))
            {
                throw new ArgumentException("More than one type of message are not permitted");
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
