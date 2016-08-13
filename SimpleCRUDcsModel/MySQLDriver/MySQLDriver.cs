using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SimpleCRUDcsModel.MySQLDriver
{
    public class MySQLDriver : ErrorHandler, IDatabaseConnection
    {
        private MySqlConnection _connection;
        public MySQLDriver(string host, string user, string pwd, string database)
        {
            string connectionString = string.Format("host={0};user={1};pwd={2};database={3};", host, user, pwd, database);
            _connection = new MySqlConnection(connectionString);
            
        }
        

        public bool close()
        {
            bool response=false;
            if(isConnected())
            {
                _connection.Close();
                response = true;
            }
            return response;
        }

        public SimpleResponse executeSQL(string sql, Dictionary<string, object> parameters)
        {
            SimpleResponse response = SimpleResponse.create();

            MySqlCommand cmd;
            try
            {
                cmd = new MySqlCommand(sql, _connection);
                foreach (string paramName in parameters.Keys)
                {
                    cmd.Parameters.AddWithValue(paramName, parameters[paramName]);
                }
                cmd.ExecuteNonQuery();
                response.ok = true;
            }
            catch (Exception ex)
            {
                response.ok = false;
                response.LastError = ex.Message;
                LastError = ex.Message;
            }

            return response;
           
        }

        public IDataReader executeSQLReader(string sql, Dictionary<string, object> parameters)
        {
            MySQLSimpleReader reader=null;
            MySqlDataReader dr;
            MySqlCommand cmd;
            try
            {
                cmd = new MySqlCommand(sql, _connection);
                foreach(string paramName in parameters.Keys)
                {
                    cmd.Parameters.AddWithValue(paramName, parameters[paramName]);
                }
                dr = cmd.ExecuteReader();
                reader =MySQLSimpleReader.create(dr);
            }catch(Exception ex)
            {
                LastError = ex.Message;
            }
            return reader;

        }

        public bool isConnected()
        {
            return _connection.State == System.Data.ConnectionState.Open;
        }

        public bool open()
        {
            bool response = false;
            try
            {
                _connection.Open();
                response = true;
            }catch(Exception ex)
            {
                LastError = ex.Message;
            }
            return response;
        }
    }
}
