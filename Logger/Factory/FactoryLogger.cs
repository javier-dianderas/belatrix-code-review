using Logger.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Factory
{
    public abstract class FactoryLogger
    {
        public abstract AbstractLogger CreateLogger();
    }
}
