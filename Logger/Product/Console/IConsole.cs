using System;

namespace Logger.Product.Console
{
    public interface IConsole
    {
        ConsoleColor ForegroundColor { set; }
        void WriteLine(string message);
    }
}
