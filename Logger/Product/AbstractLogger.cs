using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Product
{
    public abstract class AbstractLogger
    {
        public abstract void Log(string message, int type);
        public abstract void LogMessage(string message);
        public abstract void LogWarning(string message);
        public abstract void LogError(string message);
    }
}
