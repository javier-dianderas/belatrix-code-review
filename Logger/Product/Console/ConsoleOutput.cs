using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Product.Console
{
    class ConsoleOutput : IConsole
    {
        public ConsoleColor ForegroundColor
        {
            set
            {
                System.Console.ForegroundColor = value;
            }
            get
            {
                return System.Console.ForegroundColor;
            }
        }

        public void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
