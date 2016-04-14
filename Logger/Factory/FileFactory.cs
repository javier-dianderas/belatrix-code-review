using Logger.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Factory
{
    class FileFactory : FactoryLogger
    {
        public override AbstractLogger CreateLogger()
        {
            return new FileLogger();
        }
    }
}
