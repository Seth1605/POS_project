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
    public class Category:Action
    {
        public int id { get; set; }

        public static int userid = 0;
        public string categoryName { get; set; }
        public string status { get; set; }
        public string SQL { get; set; }
        public int roweffected { get; set; }
        public DataGridViewRow DGV;

        public void CreateCategory()
        {
            try
            {
                Database.ConnectiontoDB();
                this.SQL = "INSERT INTO tbl_category(name,status,createAt,createBy)  " +
                    "VALUES (@categoryname,@status,GETDATE(), @createBy)";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.Parameters.AddWithValue("@categoryname", this.categoryName);
                Database.Cmd.Parameters.AddWithValue("@status", this.status);
                Database.Cmd.Parameters.AddWithValue("@createBy", User.userid);
                this.roweffected = Database.Cmd.ExecuteNonQuery();

                MessageBox.Show("Category Created SuccessFull!");

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
                    this.SQL = "UPDATE tbl_category SET name=@username, status=@status," +
                        " updateAt=GETDATE(), updateBy=@updateBy WHERE id=@id";
                    Database.ConnectiontoDB();
                    Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                    Database.Cmd.Parameters.AddWithValue("@username", this.categoryName);              
                    Database.Cmd.Parameters.AddWithValue("@status", this.status);
                    Database.Cmd.Parameters.AddWithValue("@updateBy", User.userid);
                    Database.Cmd.Parameters.AddWithValue("@id", this.id);

                    int rowsAffected = Database.Cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Category updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Update failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Please specify a valid user ID.");
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
        public override void search(DataGridView dg)
        {
           
            try
            {
                this.SQL = "select * from tbl_category where name like CONCAT('%', @name , '%')";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.Parameters.AddWithValue("@name", this.categoryName);
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
                this.SQL = "delete from tbl_category where id=@id";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.Parameters.AddWithValue("@id", this.id);
                if (MessageBox.Show("Do you really want to delete this?", "Delete",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.roweffected = Database.Cmd.ExecuteNonQuery();
                    if (this.roweffected == 1)
                    {
                        MessageBox.Show("Category deleted");
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
                this.SQL = "SELECT * FROM tbl_category";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.ExecuteNonQuery();
                Database.da = new System.Data.SqlClient.SqlDataAdapter(Database.Cmd);
                Database.tbl = new System.Data.DataTable();
                Database.da.Fill(Database.tbl);
                dg.DataSource = Database.tbl;
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
        public void transferdata(DataGridView dg, TextBox txtCategoryname, RadioButton rTrue, RadioButton rFalse)
        {
            this.DGV = dg.SelectedRows[0];
            /*cboRolename.Text = DGV.Cells[0].Value.ToString();*/
            txtCategoryname.Text = DGV.Cells[1].Value.ToString();
            if (DGV.Cells[2].Value.ToString().Equals("True"))
            {
                rTrue.Checked = true;
            }
            else
            {
                rFalse.Checked = true;
            }

        }
    }
}
