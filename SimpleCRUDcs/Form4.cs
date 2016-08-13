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
    public partial class Form4 : Form
    {
        public UserData aUser;
        public Form4()
        {
            InitializeComponent();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            aUser.UserId = txtUserId.Text;
            aUser.Name = txtName.Text;
            aUser.Password = txtPassword.Text;
            aUser.UserType = txtUserType.Text;
            SimpleResponse response;
            response = Program.uModel.editUser(aUser);
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

        private void Form4_Load(object sender, EventArgs e)
        {
            txtUserId.Text = aUser.UserId;
            txtName.Text=aUser.Name;
            txtPassword.Text = aUser.Password;
            txtUserType.Text = aUser.UserType;

        }
    }
}
