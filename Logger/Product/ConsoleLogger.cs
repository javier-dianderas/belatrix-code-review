using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Product
{
    class ConsoleLogger : AbstractLogger
    {
        public override void Log(string message, int type)
        {
            Console.WriteLine(DateTime.Now.ToShortDateString() + message);
        }

        public override void LogMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            var t = 1;
            Log(message, t);
        }

        public override void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var t = 3;
            Log(message, t);
        }

        public override void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            var t = 2;
            Log(message, t);
        }
    }
}
