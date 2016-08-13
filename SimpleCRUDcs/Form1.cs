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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserData data;
            data = Program.uModel.getUser(txtUser.Text, txtPassword.Text);
            if (data==null)
            {
                // not found
                if (Program.uModel.AnyErrors)
                {
                    MessageBox.Show("Error: " + Program.uModel.LastError);
                }
                else
                {
                    MessageBox.Show("Not found");
                }
            }
            else
            {
                txtPassword.Text = "";
                txtUser.Text = "";
                // user found
                MessageBox.Show("Hello " + data.Name);
                if(data.UserType == "admin")
                {
                    this.Hide();
                    Form2 dataWindow = new SimpleCRUDcs.Form2();
                    dataWindow.ShowDialog();
                    this.Show();

                }
            }
        }
    }
}
