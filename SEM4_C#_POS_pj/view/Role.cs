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
using System.Xml.Linq;

namespace SEM4_C__POS_pj.view
{
    public partial class Role : Form
    {
        public Role()
        {
            InitializeComponent();
        }

        model.Role role;
        private void Role_Load(object sender, EventArgs e)
        {
            role = new model.Role();
            dgrole.Columns.Clear();
            role.loading_data(dgrole);
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            role = new model.Role();

            role.rolename = txtRolename.Text;
            if (rTrue.Checked)
            {
                role.status = rTrue.Text;
            }
            else
            {
                role.status = rFalse.Text;
            }
            role.CreateRole();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            role = new model.Role();
            role.delete(dgrole);
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                role = new model.Role();
                role.rolename= txtsearch.Text;
                role.search(dgrole);
            }
        }

        private void dgrole_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            role = new model.Role();
            role.transferdata(dgrole, txtRolename, rTrue, rFalse);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgrole.SelectedRows.Count > 0)
            {
                role = new model.Role();

                DataGridViewRow selectedRow = dgrole.SelectedRows[0];
                role.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                role.rolename = txtRolename.Text;
                role.status = rTrue.Checked ? rTrue.Text : rFalse.Text;
                role.Update();
                role.loading_data(dgrole);
            }
            else
            {
                MessageBox.Show("Please select a role to update.");
            }
        }
    }
}
