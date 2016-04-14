using System.Configuration;
using System.Data.SqlClient;
using Logger.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logger.Product.Database;

namespace Logger.Factory
{
    public class DatabaseFactory : FactoryLogger
    {
        public override AbstractLogger CreateLogger()
        {
            //TODO: Include in the document
            if (ConfigurationManager.ConnectionStrings["ConnectionStringDatabase"] == null)
            {
                throw new Exception("ConnectionString key does not exist in the configuration file");
            }
            IRepository repository = new RepositoryDatabase(new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]));
            return new DatabaseLogger(repository);
        }
    }
}
