using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Logger.Product.Database
{
    class RepositoryDatabase : IRepository
    {
        public RepositoryDatabase(IDbConnection connection)
        {
            Connection = connection;
        }

        public IDbConnection Connection { get; set; }

        public void InsertLog(string message, int type)
        {
            using (Connection)
            {
                using (var command = Connection.CreateCommand())
                {
                    //Create parameters
                    IDbDataParameter messageParameter = command.CreateParameter();
                    messageParameter.ParameterName = "@Message";
                    messageParameter.DbType = DbType.String;
                    messageParameter.Value = message;
                    command.Parameters.Add(messageParameter);

                    IDbDataParameter typeParameter = command.CreateParameter();
                    typeParameter.ParameterName = "@Type";
                    typeParameter.Value = type;
                    typeParameter.DbType = DbType.Int32;
                    command.Parameters.Add(typeParameter);

                    //Open connection
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_InsertLog";
                    Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
