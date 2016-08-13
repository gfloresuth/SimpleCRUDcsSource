using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleCRUDcsModel;

namespace SimpleCRUDcs
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserData user = new UserData();
            user.UserId = txtUserId.Text;
            user.Name = txtName.Text;
            user.Password = txtPassword.Text;
            user.UserType = txtUserType.Text;
            SimpleResponse response;
            response = Program.uModel.addUser(user);
            if (response.ok)
            {
                MessageBox.Show("User added");
                this.Close();
            }
            else
            {
                MessageBox.Show("Not added: " + response.LastError);

            }

        }
    }
}
