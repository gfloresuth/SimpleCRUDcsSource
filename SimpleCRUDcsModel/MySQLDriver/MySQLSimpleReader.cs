using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SimpleCRUDcsModel.MySQLDriver
{
    public class MySQLSimpleReader : ErrorHandler,IDataReader
    {
        private MySqlDataReader _reader;
        public static MySQLSimpleReader create(MySqlDataReader aReader)
        {
            MySQLSimpleReader instance = new MySQLSimpleReader(aReader);
            return instance;
        }
        public MySQLSimpleReader(MySqlDataReader aReader)
            :base()
        {
            _reader = aReader;
        }
        public bool canRead()
        {
            return _reader.Read();
        }

        public ErrorHandler getErrors()
        {
            return (ErrorHandler)this;
        }

        public int getInt(string name)
        {
            return _reader.GetInt32(name);
        }

        public string getString(string name)
        {
            return _reader.GetString(name);
        }

        public bool close()
        {
            bool response = false;
            try
            {
                _reader.Close();
            }catch(Exception ex){
                LastError = ex.Message;
            }
            return response;
        }

        public DateTime getDateTime(string name)
        {
            return _reader.GetDateTime(name);
        }


        public double getDouble(string name)
        {
            return _reader.GetDouble(name);
        }
    }
}
