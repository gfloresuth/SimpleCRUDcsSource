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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void showData()
        {
            dataGridView1.DataSource = Program.uModel.getAllUsers();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Form3 addWindow = new Form3();
            addWindow.ShowDialog();
            showData();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            UserData aUser;
            string userId;
            int row;
            if (dataGridView1.SelectedCells.Count > 0)
            {
                row = dataGridView1.SelectedCells[0].RowIndex;
                userId = dataGridView1.Rows[row].Cells[0].Value.ToString();
                aUser = Program.uModel.getUser(userId);
                if (aUser != null)
                {
                    Form4 editWindow = new Form4();
                    editWindow.aUser = aUser;
                    editWindow.ShowDialog();
                    showData();
                }
                else
                {
                    if (Program.uModel.AnyErrors)
                    {
                        MessageBox.Show("Error " + Program.uModel.LastError);
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a user to edit");
            }

        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            UserData aUser;
            string userId;
            int row;
            if (dataGridView1.SelectedCells.Count > 0)
            {
                row = dataGridView1.SelectedCells[0].RowIndex;
                userId = dataGridView1.Rows[row].Cells[0].Value.ToString();
                aUser = Program.uModel.getUser(userId);
                if (aUser != null)
                {
                    if (MessageBox.Show("Delete user?", "Delete user?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        SimpleResponse resp = Program.uModel.deleteUser(userId);
                        if (resp.ok)
                        {
                            MessageBox.Show("User deleted");
                        }
                        else
                        {
                            MessageBox.Show("Unable to delete " + resp.LastError);
                        }
                        showData();

                    }
                }
                else
                {
                    if (Program.uModel.AnyErrors)
                    {
                        MessageBox.Show("Error " + Program.uModel.LastError);
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a user to edit");
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout?", "Logout?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {

            }
        }
    }
}
