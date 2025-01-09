using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEM4_C__POS_pj.view;

namespace SEM4_C__POS_pj.model
{
    public class Supplier:Action
    {
        public int id { get; set; }
        public static int userid = 0;

        public string name { get; set; }
        public string telephone { get; set; }
        public string address { get; set; }
        public string SQL { get; set; }
        public int roweffected { get; set; }
        public DataGridViewRow DGV;

        
        public void CreateSupplier()
        {
            try
            {
                Database.ConnectiontoDB();
                this.SQL = "INSERT INTO tbl_supplier(name, telephone, address, createAt, createBy)  " +
                    "VALUES (@Name, @telephone, @address, GETDATE(), @createBy)";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.Parameters.AddWithValue("@Name", this.name);
                Database.Cmd.Parameters.AddWithValue("@telephone", this.telephone);
                Database.Cmd.Parameters.AddWithValue("@address", this.address);
                Database.Cmd.Parameters.AddWithValue("@createBy", User.userid);
                this.roweffected = Database.Cmd.ExecuteNonQuery();

                MessageBox.Show("supplier Created SuccessFull!");

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
                    this.SQL = "UPDATE tbl_supplier SET name=@suppliername,telephone=@telephone,address=@address," +
                        " updateAt=GETDATE(), updateBy=@updateBy WHERE id=@id";
                    Database.ConnectiontoDB();
                    Database.Cmd = new SqlCommand(this.SQL, Database.Con);

                    Database.Cmd.Parameters.AddWithValue("@suppliername", this.name);
                    Database.Cmd.Parameters.AddWithValue("@telephone", this.telephone);
                    Database.Cmd.Parameters.AddWithValue("@address", this.address);
                    Database.Cmd.Parameters.AddWithValue("@updateBy", User.userid);

                    Database.Cmd.Parameters.AddWithValue("@id", this.id);

                    int rowsAffected = Database.Cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("supplier updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Update failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Please specify a valid supplier ID.");
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
                this.SQL = "delete from tbl_supplier where id=@id";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.Parameters.AddWithValue("@id", this.id);
                if (MessageBox.Show("Do you really want to delete this?", "Delete",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.roweffected = Database.Cmd.ExecuteNonQuery();
                    if (this.roweffected == 1)
                    {
                        MessageBox.Show("supplier deleted");
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
                this.SQL = "SELECT * FROM tbl_supplier";
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
                this.SQL = "select * from tbl_supplier where name like CONCAT('%', @name , '%')";
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
                    object[] row = { r["id"], r["username"], r["password"], r["email"], r["status"], r["createAt"]
                    , r["createBy"], r["updateAt"], r["updateBy"] };
                    dg.Rows.Add(row);
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void transferdata(DataGridView dg, TextBox txtname, TextBox txtTelephone,
            TextBox txtAddress)
        {
            this.DGV = dg.SelectedRows[0];
            /*cboRolename.Text = DGV.Cells[0].Value.ToString();*/
            txtname.Text = DGV.Cells[1].Value.ToString();
            txtTelephone.Text = DGV.Cells[2].Value.ToString();
            txtAddress.Text = DGV.Cells[3].Value.ToString();
        }

    }
}
