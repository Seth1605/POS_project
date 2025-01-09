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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        model.Category category;

        private void btnCreate_Click(object sender, EventArgs e)
        {
            category = new model.Category();

            category.categoryName = txtCategoryname.Text;
            if (rTrue.Checked)
            {
                category.status = rTrue.Text;
            }
            else
            {
                category.status = rFalse.Text;
            }
            category.CreateCategory();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            category = new model.Category();
            dgcategory.Columns.Clear();
            category.loading_data(dgcategory);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgcategory.SelectedRows.Count > 0)
            {
                category = new model.Category();

                DataGridViewRow selectedRow = dgcategory.SelectedRows[0];
                category.id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                category.categoryName = txtCategoryname.Text;
                category.status = rTrue.Checked ? rTrue.Text : rFalse.Text;
                category.Update();
                category.loading_data(dgcategory);
            }
            else
            {
                MessageBox.Show("Please select a category to update.");
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            category = new model.Category();
            category.delete(dgcategory);
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                category = new model.Category();
                category.categoryName = txtsearch.Text;
                category.search(dgcategory);
            }
        }

        private void dgcategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            category = new model.Category();
            category.transferdata(dgcategory, txtCategoryname, rTrue, rFalse);
        }
    }
}
