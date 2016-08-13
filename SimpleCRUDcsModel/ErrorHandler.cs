using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUDcsModel
{
    public class ErrorHandler
    {
        private string _lastError;
        private bool _anyErrors;


        public ErrorHandler()
        {
            clearErrors();
        }

        public void clearErrors()
        {
            _anyErrors = false;
            _lastError = "";
        }

        public string LastError
        {
            get
            {
                return _lastError;
            }

            set
            {
                _anyErrors = true;
                _lastError = value;
            }
        }

        public bool AnyErrors
        {
            get
            {
                return _anyErrors;
            }
        }
    }
}
