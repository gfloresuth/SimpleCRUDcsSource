using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SimpleCRUDcsModel
{
    public class UserModel : ErrorHandler
    {
        private IDatabaseConnection _driver;
        public UserModel(IDatabaseConnection aDriver)
            : base()
        {

            _driver = aDriver;
        }
        //private string campoTexto(string nombreCampo, string valor)
        //{
        //    string respuesta;
        //    respuesta = nombreCampo + "='" + valor + "' ";
        //    return respuesta;
        //}
        public DataTable getAllUsers()
        {
            DataTable table= new DataTable();
            IDataReader reader = null;
            Dictionary<string, object> parameters;
            string sql;
            clearErrors();
            //string parametrosTexto;
            //string tipo="alumno";
            //string grupo = "cuarto";
            if (_driver.open())
            {
                //sql = "select * from users user_type='"++"'";
                //parametrosTexto = string.Format("tipoUsuario='{0}' and grupo='{1}'", tipo,grupo);
                //sql = "select * from users where " + parametrosTexto;

                //sql = "select * from users where " + campoTexto("tipoUsuario",tipo) +" and " + campoTexto("tipoUsuario", grupo);
                sql = "select * from users";
                parameters = new Dictionary<string, object>();
                reader = _driver.executeSQLReader(sql, parameters);
                if (reader != null)
                {
                    table.Columns.Add(new DataColumn("user_id"));
                    table.Columns.Add(new DataColumn("name"));
                    table.Columns.Add(new DataColumn("pwd"));
                    table.Columns.Add(new DataColumn("user_type"));
                    
                    while (reader.canRead())
                    {
                        DataRow row = table.NewRow();
                        row["user_id"]= reader.getString("user_id");
                        row["name"] = reader.getString("name");
                        row["pwd"] = reader.getString("pwd");
                        row["user_type"] = reader.getString("user_type");
                        table.Rows.Add(row);
                    }
                    reader.close();
                }

            }
            else
            {
                LastError = "Error in connection ";
            }
            if (_driver.isConnected())
            {
                _driver.close();
            }

            return table;
        }
        public SimpleResponse addUser(UserData aUser)
        {
            SimpleResponse response = SimpleResponse.create();
            string sql;
            Dictionary<string, object> parameters;
            parameters = new Dictionary<string, object>();
            sql = "insert into users(user_id,name,pwd,user_type) values(?user_id,?name,?pwd,?user_type);";
            //MySql.Data.MySqlClient.MySqlCommand cmd;
            //cmd.Parameters.AddWithValue("?grupo", a);
            parameters.Add("?user_id", aUser.UserId);
            parameters.Add("?name", aUser.Name);
            parameters.Add("?pwd", aUser.Password);
            parameters.Add("?user_type", aUser.UserType);
            clearErrors();
            if (_driver.open())
            {
                response=_driver.executeSQL(sql, parameters);
                
            }
            if (_driver.isConnected())
            {
                _driver.close();
            }
            return response;
        }

        // new code
        public SimpleResponse deleteUser(string userId)
        {
            SimpleResponse response = SimpleResponse.create();
            string sql;
            Dictionary<string, object> parameters;
            parameters = new Dictionary<string, object>();
            sql = "delete from users where user_id=?user_id;";
            parameters.Add("?user_id", userId);
            clearErrors();
            if (_driver.open())
            {
                response = _driver.executeSQL(sql, parameters);

            }
            if (_driver.isConnected())
            {
                _driver.close();
            }
            return response;
        }

        public SimpleResponse editUser(UserData aUser)
        {
            SimpleResponse response = SimpleResponse.create();
            string sql;
            Dictionary<string, object> parameters;
            parameters = new Dictionary<string, object>();
            sql = "update users set name=?name, pwd=?pwd, user_type=?user_type where user_id=?user_id;";
            parameters.Add("?name", aUser.Name);
            parameters.Add("?pwd", aUser.Password);
            parameters.Add("?user_type", aUser.UserType);
            parameters.Add("?user_id", aUser.UserId);
            clearErrors();
            if (_driver.open())
            {
                response = _driver.executeSQL(sql, parameters);

            }
            if (_driver.isConnected())
            {
                _driver.close();
            }
            return response;
        }


        public UserData getUser(string userId, string password)
        {
            UserData response = null;
            IDataReader reader = null;
            Dictionary<string, object> parameters;
            string sql;
            clearErrors();
            if (_driver.open())
            {
                sql = "select * from users where user_id=?user_id and pwd=?pwd";
                parameters = new Dictionary<string, object>();
                parameters.Add("?user_id", userId);
                parameters.Add("?pwd", password);
                reader = _driver.executeSQLReader(sql, parameters);
                if (reader != null)
                {
                    if (reader.canRead())
                    {
                        response = new UserData();
                        response.UserId = userId;
                        response.Password = password;
                        response.UserType = reader.getString("user_type");
                        response.Name = reader.getString("name");
                    }
                    reader.close();
                }

            }
            else
            {
                LastError = "Error in connection ";
            }
            if (_driver.isConnected())
            {
                _driver.close();
            }

            return response;
        }
        // new code
        public UserData getUser(string userId)
        {
            UserData response = null;
            IDataReader reader = null;
            Dictionary<string, object> parameters;
            string sql;
            clearErrors();
            if (_driver.open())
            {
                sql = "select * from users where user_id=?user_id";
                parameters = new Dictionary<string, object>();
                parameters.Add("?user_id", userId);
                reader = _driver.executeSQLReader(sql, parameters);
                if (reader != null)
                {
                    if (reader.canRead())
                    {
                        response = new UserData();
                        response.UserId = userId;
                        response.Password = reader.getString("pwd"); ;
                        response.UserType = reader.getString("user_type");
                        response.Name = reader.getString("name");
                    }
                    reader.close();
                }

            }
            else
            {
                LastError = "Error in connection ";
            }
            if (_driver.isConnected())
            {
                _driver.close();
            }

            return response;
        }

    }
}
