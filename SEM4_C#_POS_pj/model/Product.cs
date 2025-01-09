using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEM4_C__POS_pj.model
{
    public class Product:Action
    {
        public int id { get; set; }
        public static int userid = 0;

        public string name { get; set; }
        public string barcode { get; set; }
        public string sellprice { get; set; }
        public string qtyinstock { get; set; }
        public string image { get; set; }
        public string categoryid { get; set; }
        public string SQL { get; set; }
        public int roweffected { get; set; }
        public DataGridViewRow DGV;    
           
        public void setcategory(ComboBox cboCategory)
        {
            try
            {
                this.SQL = "SELECT * FROM tbl_category";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.ExecuteNonQuery();
                Database.da = new System.Data.SqlClient.SqlDataAdapter(Database.Cmd);
                Database.tbl = new System.Data.DataTable();
                Database.da.Fill(Database.tbl);
                foreach (DataRow r in Database.tbl.Rows)
                {
                    cboCategory.Items.Add(r["name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        public void CreateProduct()
        {
            try
            {
                Database.ConnectiontoDB();
                this.SQL = "INSERT INTO tbl_product(name, barcode, sellPrice, qtyInstock, createAt, createBy)  " +
                    "VALUES (@productName, @barcode, @sellPrice, @qtyInstock, GETDATE(), @createBy)";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.Parameters.AddWithValue("@productName", this.name);
                Database.Cmd.Parameters.AddWithValue("@barcode", this.barcode);
                Database.Cmd.Parameters.AddWithValue("@sellPrice", this.sellprice);
                Database.Cmd.Parameters.AddWithValue("@qtyInstock", this.qtyinstock);
                //Database.Cmd.Parameters.AddWithValue("@categoryID", this.categoryid);
                Database.Cmd.Parameters.AddWithValue("@createBy", User.userid);
                this.roweffected = Database.Cmd.ExecuteNonQuery();

                MessageBox.Show("Product Created SuccessFull!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

        }
        public void Update()
        {

            try
            {
                if (this.id > 0)
                {
                    this.SQL = "UPDATE tbl_product SET name=@name,barcode=@barcode, sellprice=@sellprice,qtyinstock=@qtyinstock, updateAt=GETDATE(), updateBy=@updateBy WHERE id=@id";
                    Database.ConnectiontoDB();
                    Database.Cmd = new SqlCommand(this.SQL, Database.Con);

                    Database.Cmd.Parameters.AddWithValue("@name", this.name);
                    Database.Cmd.Parameters.AddWithValue("@barcode", this.barcode);
                    Database.Cmd.Parameters.AddWithValue("@sellprice", this.sellprice);
                    Database.Cmd.Parameters.AddWithValue("@qtyinstock", this.qtyinstock);                
                    //Database.Cmd.Parameters.AddWithValue("@categoryID", this.categoryid);
                    Database.Cmd.Parameters.AddWithValue("@updateBy", User.userid);
                    Database.Cmd.Parameters.AddWithValue("@id", this.id);

                    int rowsAffected = Database.Cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Update failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Please specify a valid role ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            /*finally
            {
                if (database.Con != null && database.Con.State == ConnectionState.Open)
                {
                    database.Con.Close();
                }
            }*/
        }
        public override void delete(DataGridView dg)
        {
            try
            {
                if (dg.Rows.Count < 0)
                {
                    return;
                }

                this.DGV = dg.SelectedRows[0];
                this.id = int.Parse(DGV.Cells[0].Value.ToString());
                this.SQL = "delete from tbl_product where id=@id";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.Parameters.AddWithValue("@id", this.id);
                if (MessageBox.Show("Do you really want to delete this?", "Delete",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.roweffected = Database.Cmd.ExecuteNonQuery();
                    if (this.roweffected == 1)
                    {
                        MessageBox.Show("product deleted");
                        dg.Rows.Remove(DGV);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }
        public override void loading_data(DataGridView dg)
        {
            try
            {
                this.SQL = "SELECT * FROM tbl_product";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.ExecuteNonQuery();
                Database.da = new System.Data.SqlClient.SqlDataAdapter(Database.Cmd);
                Database.tbl = new System.Data.DataTable();
                Database.da.Fill(Database.tbl);
                dg.DataSource = Database.tbl;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public override void search(DataGridView dg)
        {
            try
            {
                this.SQL = "select * from tbl_product where name like CONCAT('%', @name , '%')";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.Parameters.AddWithValue("@name", this.name);
                Database.Cmd.ExecuteNonQuery();
                Database.da = new System.Data.SqlClient.SqlDataAdapter(Database.Cmd);
                Database.tbl = new System.Data.DataTable();
                Database.da.Fill(Database.tbl);
                dg.DataSource = Database.tbl;
                /*dg.Rows.Clear();*/
                /*foreach (DataRow r in database.tbl.Rows)
                {
                    object[] row = { r["id"], r["username"], r["gender"], r["password"], r["email"], r["status"], r["createAt"]
                    , r["createBy"], r["updateAt"], r["updateBy"] };
                    dg.Rows.Add(row);
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void transferdata(DataGridView dg, TextBox txtName, TextBox txtBarcode, TextBox txtSellPrice,
            TextBox txtQtyInStock)
        {
            this.DGV = dg.SelectedRows[0];
            /*cboRolename.Text = DGV.Cells[0].Value.ToString();*/
            txtName.Text = DGV.Cells[1].Value.ToString();
            txtBarcode.Text = DGV.Cells[2].Value.ToString();
            txtSellPrice.Text = DGV.Cells[3].Value.ToString();
            txtQtyInStock.Text = DGV.Cells[4].Value.ToString();
        }



    }
}
