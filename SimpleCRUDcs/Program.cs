using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleCRUDcsModel;

namespace SimpleCRUDcs
{
    static class Program
    {
        public static IDatabaseConnection cn;
        public static UserModel uModel;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            cn = new  SimpleCRUDcsModel.MySQLDriver.MySQLDriver("localhost", "root","usbw","basiccrud") ;
            uModel = new UserModel(cn);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
