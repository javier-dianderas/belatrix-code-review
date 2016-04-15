using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Product.File
{
    public interface IFileWrapper
    {       

        bool Exists(string fileName);

        string ReadAllText(string fileName);

        void WriteAllText(string fileName, string message);
    }
}
