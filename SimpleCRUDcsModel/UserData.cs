using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUDcsModel
{
    public class UserData
    {
        private string _userId;
        private string _name;
        private string _password;
        private string _userType;

        public string UserId
        {
            get
            {
                return _userId;
            }

            set
            {
                _userId = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string UserType
        {
            get
            {
                return _userType;
            }

            set
            {
                _userType = value;
            }
        }
    }
}
