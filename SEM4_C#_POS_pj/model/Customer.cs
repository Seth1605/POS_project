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
    public class Customer:Action
    {
        public int id { get; set; }
        public static int userid = 0;

        public string name { get; set; }
        public string gender { get; set; }
        public string telephone { get; set; }
        public string address { get; set; }
        public string SQL { get; set; }
        public int roweffected { get; set; }
        public DataGridViewRow DGV;

        public void CreateCustomer()
        {
            try
            {
                Database.ConnectiontoDB();
                this.SQL = "INSERT INTO tbl_customer(name, gender, telephone, address, createAt, createBy)  " +
                    "VALUES (@customerName, @gender, @telephone, @address, GETDATE(), @createBy)";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.Parameters.AddWithValue("@customerName", this.name);
                Database.Cmd.Parameters.AddWithValue("@gender", this.gender);
                Database.Cmd.Parameters.AddWithValue("@telephone", this.telephone);
                Database.Cmd.Parameters.AddWithValue("@address", this.address);
                Database.Cmd.Parameters.AddWithValue("@createBy", User.userid);
                this.roweffected = Database.Cmd.ExecuteNonQuery();

                MessageBox.Show("Customer Created SuccessFull!");

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
                    this.SQL = "UPDATE tbl_customer SET name=@customername,gender=@gender,telephone=@telephone," +
                        "address=@address, updateAt=GETDATE(), updateBy=@updateBy WHERE id=@id";
                    Database.ConnectiontoDB();
                    Database.Cmd = new SqlCommand(this.SQL, Database.Con);

                    Database.Cmd.Parameters.AddWithValue("@customername", this.name);
                    Database.Cmd.Parameters.AddWithValue("@gender", this.gender);
                    Database.Cmd.Parameters.AddWithValue("@telephone", this.telephone);
                    Database.Cmd.Parameters.AddWithValue("@address", this.address);
                    Database.Cmd.Parameters.AddWithValue("@updateBy", User.userid);
                    Database.Cmd.Parameters.AddWithValue("@id", this.id);

                    int rowsAffected = Database.Cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("customer updated successfully!");
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
                this.SQL = "delete from tbl_customer where id=@id";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.Parameters.AddWithValue("@id", this.id);
                if (MessageBox.Show("Do you really want to delete this?", "Delete",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.roweffected = Database.Cmd.ExecuteNonQuery();
                    if (this.roweffected == 1)
                    {
                        MessageBox.Show("customer deleted");
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
                this.SQL = "SELECT * FROM tbl_customer";
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
                this.SQL = "select * from tbl_customer where name like CONCAT('%', @name , '%')";
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
        public void transferdata(DataGridView dg, TextBox txtname, ComboBox cboGender, TextBox txtTelephone,
            TextBox txtAddress)
        {
            this.DGV = dg.SelectedRows[0];
            /*cboRolename.Text = DGV.Cells[0].Value.ToString();*/
            txtname.Text = DGV.Cells[1].Value.ToString();
            cboGender.Text = DGV.Cells[2].Value.ToString();
            txtTelephone.Text = DGV.Cells[3].Value.ToString();
            txtAddress.Text = DGV.Cells[4].Value.ToString();
        }



    }
}
