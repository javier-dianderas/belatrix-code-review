namespace Logger.Product.Database
{
    class DatabaseLogger : AbstractLogger
    {
        private readonly IRepository _repository;
        public DatabaseLogger(IRepository repository)
        {
            _repository = repository;
        }

        public override void Log(string message, int type)
        {
            _repository.InsertLog(message, type);
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
