using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUDcsModel
{
    public interface IDatabaseConnection
    {
        bool isConnected();
        bool open();
        bool close();
        SimpleResponse executeSQL(string sql, Dictionary<string, object> parameters);
        IDataReader executeSQLReader(string sql, Dictionary<string, object> parameters);
    }
}
