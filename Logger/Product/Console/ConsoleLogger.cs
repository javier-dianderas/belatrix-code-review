using System;

namespace Logger.Product.Console
{
    public class ConsoleLogger : AbstractLogger
    {
        private readonly IConsole _console;
        private int _type;

        public IConsole Console
        {
            get
            {
                return _console;
            }
        }
        public int Type
        {
            get { return _type; }
        }

        public ConsoleLogger(IConsole console)
        {
            _console = console;
        }

        public override void Log(string message)
        {
            _console.WriteLine(DateTime.Now.ToShortDateString() + message);
        }

        public override void LogMessage(string message)
        {
            _console.ForegroundColor = ConsoleColor.White;
            _type = 1;
            Log(message);
        }

        public override void LogWarning(string message)
        {
            _console.ForegroundColor = ConsoleColor.Yellow;
            _type = 3;
            Log(message);
        }

        public override void LogError(string message)
        {
            _console.ForegroundColor = ConsoleColor.Red;
            _type = 2;
            Log(message);
        }
    }
}
