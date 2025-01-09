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

namespace SEM4_C__POS_pj
{
    public partial class login : System.Windows.Forms.Form
    {

        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Database.ConnectiontoDB();
            model.User user = new model.User();
            user.username = txtUsername.Text;
            user.password = txtPassword.Text;
            user.LogIn();
            

        }

        private void login_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtUsername;
        }

        private void login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Database.ConnectiontoDB();
                model.User user = new model.User();
                user.username = txtUsername.Text;
                user.password = txtPassword.Text;
                user.LogIn();
                

            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Database.ConnectiontoDB();
                model.User user = new model.User();
                user.username = txtUsername.Text;
                user.password = txtPassword.Text;
                user.LogIn();
                

            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Database.ConnectiontoDB();
                model.User user = new model.User();
                user.username = txtUsername.Text;
                user.password = txtPassword.Text;
                user.LogIn();
                

            }
        }
        public void signout()
        {
            this.Close();
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
