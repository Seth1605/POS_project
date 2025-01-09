using SEM4_C__POS_pj.view;
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
    public partial class MDI : Form
    {
        private int childFormNumber = 0;

        public MDI()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            User user = new User();
            user.MdiParent = this;
            user.Show();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.MdiParent = this;
            product.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.MdiParent = this;
            customer.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.MdiParent = this;
            category.Show();

        }

        private void roleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Role role = new Role();
            role.MdiParent = this;
            role.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            supplier.MdiParent = this;
            supplier.Show();
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            /*lblCurrentUser.Text = User.currentUsername;*/
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            login login = new login();
            this.Hide();
            login.Show();

        }
    }
}
