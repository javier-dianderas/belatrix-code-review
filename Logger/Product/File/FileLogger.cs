using System;

namespace Logger.Product.File
{
    class FileLogger : AbstractLogger
    {
        private readonly string _fileName;
        private readonly IFileWrapper _file;
        private readonly DateTime _dateTime;

        public FileLogger(string fileName, IFileWrapper file, DateTime dateTime)
        {
            _fileName = fileName;
            _file = file;
            _dateTime = dateTime;
        }
        public override void Log(string message, int type)
        {
            string l = string.Empty;
            if (!_file.Exists(_fileName))
            {
                l = _file.ReadAllText(_fileName);
            }            
            l = l + DateTime.Now.ToShortDateString() + message + "\n";
            _file.WriteAllText(_fileName, l);            
        }

        public override void LogMessage(string message)
        {
            var t = 1;
            Log(message, t);
        }

        public override void LogWarning(string message)
        {
            var t = 3;
            Log(message, t);
        }

        public override void LogError(string message)
        {
            var t = 2;
            Log(message, t);
        }
    }
}
