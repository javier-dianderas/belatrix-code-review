using System;

namespace Logger.Product.Console
{
    public class ConsoleLogger : AbstractLogger
    {
        private readonly IConsole _console;

        public IConsole Console
        {
            get
            {
                return _console;
            }
        }       

        public ConsoleLogger(IConsole console)
        {
            _console = console;
        }

        public override void Log(string message, int type)
        {
            _console.WriteLine(DateTime.Now.ToShortDateString() + message);
        }

        public override void LogMessage(string message)
        {
            _console.ForegroundColor = ConsoleColor.White;
            var t = 1;
            Log(message, t);
        }

        public override void LogWarning(string message)
        {
            _console.ForegroundColor = ConsoleColor.Yellow;
            var t = 3;
            Log(message, t);
        }

        public override void LogError(string message)
        {
            _console.ForegroundColor = ConsoleColor.Red;
            var t = 2;
            Log(message, t);
        }
    }
}
