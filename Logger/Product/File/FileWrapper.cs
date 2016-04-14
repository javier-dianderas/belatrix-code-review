using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Product.File
{
    class FileWrapper : IFileWrapper
    {
        public bool Exists(string fileName)
        {
            return System.IO.File.Exists(fileName);
        }

        public string ReadAllText(string fileName)
        {
            return System.IO.File.ReadAllText(fileName);
        }

        public void WriteAllText(string fileName, string message)
        {
            System.IO.File.WriteAllText(fileName, message);
        }
    }
}
