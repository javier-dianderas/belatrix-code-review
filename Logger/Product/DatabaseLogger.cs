using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Logger.Product
{
    class DatabaseLogger : AbstractLogger
    {
        public override void Log(string message, int type)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {                
                using (SqlCommand command = new SqlCommand("Insert into Log Values('" + message + "', " + type.ToString() + ")", connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
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
