using SEM4_C__POS_pj.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SEM4_C__POS_pj
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }
        model.User user;
        public static string currentUsername { get; internal set; }

        private void User_Load(object sender, EventArgs e)
        {
            
            user = new model.User();
            user.setRolename(cboRolename);
            dguser.Columns.Clear();
            user.loading_data(dguser);

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            user = new model.User();

            user.username = txtUsername.Text;
            user.gender = cboGender.Text;
            user.password = txtPassword.Text;
            user.email = txtemail.Text;

            if(rTrue.Checked )
            {
                user.status = rTrue.Text;
            }
            else
            {
                user.status = rFalse.Text;
            }
            user.Create();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            user = new model.User();
            user.delete(dguser);

            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dguser.SelectedRows.Count > 0)
            {
                user = new model.User();

                DataGridViewRow selectedRow = dguser.SelectedRows[0];
                user.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                user.username = txtUsername.Text;
                user.gender = cboGender.Text;
                user.password = txtPassword.Text;
                user.email = txtemail.Text;
                user.status = rTrue.Checked ? rTrue.Text : rFalse.Text;
                user.Update();
                user.loading_data(dguser);
            }
            else
            {
                MessageBox.Show("Please select a user to update.");
            }

        }
        private void dguser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            user = new model.User();
            user.transferdata( dguser,txtUsername,cboGender,txtPassword,
             txtemail,  rTrue, rFalse);
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                user = new model.User();
                user.username = txtsearch.Text;
                user.search(dguser);
            }
        }
    }
}
