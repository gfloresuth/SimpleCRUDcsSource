using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCRUDcsModel;
using System.Data;

namespace SimpleCRUDcsModelTests
{
    [TestClass]
    public class UnitTest1
    {
        SimpleCRUDcsModel.IDatabaseConnection cn;
        [TestMethod]
        public void TestConnection()
        {
            cn = new SimpleCRUDcsModel.MySQLDriver.MySQLDriver("localhost", "root", "usbw", "basiccrud");
            bool ok = cn.open();
            Assert.AreEqual(ok, true);

            if (ok)
            {
                cn.close();
            }
        }

        [TestMethod]
        public void TestSearchUser()
        {
            cn = new SimpleCRUDcsModel.MySQLDriver.MySQLDriver("localhost", "root", "usbw", "basiccrud");
            UserData uData;
            UserModel uModel = new UserModel(cn);
            uData=uModel.getUser("admin", "123123");
            Assert.AreNotEqual(null, uData);
            if (uData != null)
            {
                Assert.AreEqual("admin", uData.UserType);
            }
            Assert.AreEqual(false, cn.isConnected());
        }
        [TestMethod]
        public void TestGetAllUsers()
        {
            cn = new SimpleCRUDcsModel.MySQLDriver.MySQLDriver("localhost", "root", "usbw", "basiccrud");
            DataTable table;
            UserModel uModel = new UserModel(cn);
            table = uModel.getAllUsers();
            Assert.AreEqual(1, table.Rows.Count);
        }
    }
}
