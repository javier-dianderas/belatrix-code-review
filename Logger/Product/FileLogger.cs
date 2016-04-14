using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Logger.Product
{
    class FileLogger : AbstractLogger
    {
        public override void Log(string message, int type)
        {
            string l = string.Empty;
            if (!System.IO.File.Exists(ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt"))
            {
                l = System.IO.File.ReadAllText(ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt");
            }            
            l = l + DateTime.Now.ToShortDateString() + message;
            System.IO.File.WriteAllText(ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt", l);            
        }

        public override void LogMessage(string message)
        {
            var t = 1;
            Log(message, t);
        }

        public override void LogWarning(string message)
        {
            var t = 3;
            Log(message, t);
        }

        public override void LogError(string message)
        {
            var t = 2;
            Log(message, t);
        }
    }
}
