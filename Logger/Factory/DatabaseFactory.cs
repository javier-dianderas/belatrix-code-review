using Logger.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Factory
{
    class DatabaseFactory : FactoryLogger
    {
        public override AbstractLogger CreateLogger()
        {
            return new DatabaseLogger();
        }
    }
}
