
using Logger.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logger.Product.Console;

namespace Logger.Factory
{
    class ConsoleFactory : FactoryLogger
    {
        public override AbstractLogger CreateLogger()
        {
            IConsole console = new ConsoleOutput();
            return new ConsoleLogger(console);
        }
    }
}
