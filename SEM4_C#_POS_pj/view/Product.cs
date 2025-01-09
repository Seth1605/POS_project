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
using static System.Net.Mime.MediaTypeNames;

namespace SEM4_C__POS_pj.view
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }
        model.Product product;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            product = new model.Product();
            product.delete(dgproduct);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            product = new model.Product();

            product.name = txtName.Text;
            product.barcode = txtBarcode.Text;
            product.sellprice = txtSellPrice.Text;
            product.qtyinstock = txtQtyInStock.Text;
            product.categoryid = cboCategory.Text;


            product.CreateProduct();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            product = new model.Product();
            dgproduct.Columns.Clear();
            product.setcategory(cboCategory);
            product.loading_data(dgproduct);
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                product = new model.Product();
                product.name = txtsearch.Text;
                product.search(dgproduct);
            }
        }

        private void dgproduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            product = new model.Product();
            product.transferdata(dgproduct, txtName, txtBarcode, txtSellPrice,
             txtQtyInStock);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgproduct.SelectedRows.Count > 0)
            {
                product = new model.Product();

                DataGridViewRow selectedRow = dgproduct.SelectedRows[0];
                product.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                product.name = txtName.Text;
                product.barcode = txtBarcode.Text;
                product.sellprice = txtSellPrice.Text;
                product.qtyinstock = txtQtyInStock.Text;
                product.Update();
                product.loading_data(dgproduct);
            }
            else
            {
                MessageBox.Show("Please select a product to update.");
            }
        }
    }
}
