using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Logger.Product.Database
{
    public interface IRepository
    {        
        IDbConnection Connection { get; set; }
        void InsertLog(string message, int type);
    }
}
