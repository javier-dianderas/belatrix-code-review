using System.Configuration;
using Logger.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logger.Product.File;

namespace Logger.Factory
{
    public class FileFactory : FactoryLogger
    {
        public override AbstractLogger CreateLogger()
        {
            if (ConfigurationManager.AppSettings["LogFileDirectory"] == null)
            {
                throw new Exception("LogFileDirectory key does not exist in the configuration file");
            }
            var logDirectory = ConfigurationManager.AppSettings["LogFileDirectory"];
            if (!System.IO.Directory.Exists(logDirectory))
            {
                throw new Exception("LogFileDirectory path does not exist in the file system");
            }

            DateTime dateTime = DateTime.Now;
            string name = ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile." +
                          dateTime.ToString("dd.MM.yyyy") + ".txt";
            IFileWrapper file = new FileWrapper();
            return new FileLogger(name, file, dateTime);
        }
    }
}
