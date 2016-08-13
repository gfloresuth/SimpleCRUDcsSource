using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUDcsModel
{
    public class SimpleResponse:ErrorHandler
    {
        public bool ok;
        public static SimpleResponse create()
        {
            return new SimpleResponse();
        }
        public SimpleResponse()
            :base()
        {
            ok = false;
        }
    }
}
