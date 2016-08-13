using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUDcsModel
{
    public interface IDataReader
    {
        int getInt(string name);
        string getString(string name);
        bool canRead();
        bool close();
        DateTime getDateTime(string name);
        double getDouble(string name);
        ErrorHandler getErrors();
    }
}
