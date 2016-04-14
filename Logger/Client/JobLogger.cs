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
        private static bool _logToFile;
        private static bool _logToConsole;
        private static bool _logMessage;
        private static bool _logWarning;
        private static bool _logError;
        private static bool _logToDatabase;
        private bool _initialized;

        private AbstractLogger _logger;

        public JobLogger(FactoryLogger factoryLogger)
        {
            _logger = factoryLogger.CreateLogger();
        }
        //public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase, bool logMessage, bool logWarning, bool logError)
        //{
        //    _logError = logError;
        //    _logMessage = logMessage;
        //    _logWarning = logWarning;
        //    _logToDatabase = logToDatabase;
        //    _logToFile = logToFile;
        //    _logToConsole = logToConsole;
        //}
        public void LogMessage(string message, bool isMessage, bool warning, bool error)
        {
            message = message.Trim();
            if (string.IsNullOrEmpty(message))
            {
                throw new Exception("Message is empty");
            }
            //if (!_logToConsole && !_logToFile && !_logToDatabase)
            //{
            //    throw new Exception("Invalid configuration");
            //}
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
