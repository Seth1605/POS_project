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

namespace SEM4_C__POS_pj.view
{
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }

        model.Supplier supplier;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            supplier = new model.Supplier();
            supplier.name = txtName.Text;
            supplier.telephone = txtTelephone.Text;
            supplier.address = txtAddress.Text;
            supplier.CreateSupplier();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgsupplier.SelectedRows.Count > 0)
            {
                supplier = new model.Supplier();

                DataGridViewRow selectedRow = dgsupplier.SelectedRows[0];
                supplier.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                supplier.name = txtName.Text;
                supplier.telephone = txtTelephone.Text;
                supplier.address = txtAddress.Text;
                supplier.Update();
                supplier.loading_data(dgsupplier);
            }
            else
            {
                MessageBox.Show("Please select a supplier to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            supplier = new model.Supplier();
            supplier.delete(dgsupplier);
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                supplier = new model.Supplier();
                supplier.name = txtsearch.Text;
                supplier.search(dgsupplier);
            }
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            supplier = new model.Supplier();
            dgsupplier.Columns.Clear();
            supplier.loading_data(dgsupplier);
            
        }

        private void dgsupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            supplier = new model.Supplier();
            supplier.transferdata(dgsupplier, txtName, txtTelephone,
             txtAddress);
        }
    }
}
