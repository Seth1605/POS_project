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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        model.Customer customer;

        private void btnCreate_Click(object sender, EventArgs e)
        {
            customer = new model.Customer();

            customer.name = txtName.Text;
            customer.gender = cboGender.Text;
            customer.telephone = txtTelephone.Text;
            customer.address = txtAddress.Text;
            customer.CreateCustomer();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            customer = new model.Customer();
            dgcustomer.Columns.Clear();
            customer.loading_data(dgcustomer);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgcustomer.SelectedRows.Count > 0)
            {
                customer = new model.Customer();

                DataGridViewRow selectedRow = dgcustomer.SelectedRows[0];
                customer.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                customer.name = txtName.Text;
                customer.gender = cboGender.Text;
                customer.telephone = txtTelephone.Text;
                customer.address = txtAddress.Text;
                customer.Update();
                customer.loading_data(dgcustomer);
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            customer = new model.Customer();
            customer.delete(dgcustomer);
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                customer = new model.Customer();
                customer.name = txtsearch.Text;
                customer.search(dgcustomer);
            }
        }

        private void dgcustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            customer = new model.Customer();
            customer.transferdata(dgcustomer, txtName, cboGender, txtTelephone,
             txtAddress);
        }
    }
}
