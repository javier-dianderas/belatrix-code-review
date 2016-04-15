using System;

namespace Logger.Product.File
{
    public class FileLogger : AbstractLogger
    {
        private readonly string _fileName;
        private readonly IFileWrapper _file;
        private readonly DateTime _dateTime;
        private int _type;
        public int Type 
        {
            get { return _type; }
        }

        public FileLogger(string fileName, IFileWrapper file, DateTime dateTime)
        {
            _fileName = fileName;
            _file = file;
            _dateTime = dateTime;
        }
        public override void Log(string message)
        {
            string l = string.Empty;
            if (_file.Exists(_fileName))
            {                
                l = _file.ReadAllText(_fileName);
            }            
            l = l + "|" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss:") + message;
            _file.WriteAllText(_fileName, l);            
        }

        public override void LogMessage(string message)
        {
            _type = 1;
            Log(message);
        }

        public override void LogWarning(string message)
        {
            _type = 3;
            Log(message);
        }

        public override void LogError(string message)
        {
            _type = 2;
            Log(message);
        }
    }
}
