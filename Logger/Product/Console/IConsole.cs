using System;

namespace Logger.Product.Console
{
    public interface IConsole
    {
        ConsoleColor ForegroundColor { set; get; }
        void WriteLine(string message);
    }
}
