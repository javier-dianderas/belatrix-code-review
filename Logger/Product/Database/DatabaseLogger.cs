namespace Logger.Product.Database
{
    public class DatabaseLogger : AbstractLogger
    {
        private readonly IRepository _repository;
        private int _type;

        public int Type 
        { 
            get { return _type; } 
        }

        public DatabaseLogger(IRepository repository)
        {
            _repository = repository;
        }

        public override void Log(string message)
        {
            _repository.InsertLog(message, _type);
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
