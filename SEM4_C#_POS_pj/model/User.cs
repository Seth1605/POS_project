using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEM4_C__POS_pj.model
{
    public class User:Action
    {
        public int id { get; set; }
        public static int userid = 0;
        public static string currentUsername { get; set; }
        public string username { get; set; }
        public string gender { get; set; }
        public string password { get; set; }
        public string email{ get; set; }
        public string status { get; set; }
        public string SQL { get; set; }
        public int roweffected { get; set; }
        public DataGridViewRow DGV;
        /*public int DGV { get; set; }*/
        public void LogIn()
        {
            try
            {
                Database.ConnectiontoDB();
                this.SQL = "SELECT * FROM tbl_user WHERE username=@username and password=@password " +
                    "and status=@status ";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.Parameters.AddWithValue("@username", this.username);
                Database.Cmd.Parameters.AddWithValue("@password", this.password);
                Database.Cmd.Parameters.AddWithValue("@status", "true");
                Database.Cmd.ExecuteNonQuery();
                Database.da = new System.Data.SqlClient.SqlDataAdapter(Database.Cmd);
                Database.tbl = new System.Data.DataTable();
                Database.da.Fill(Database.tbl);
                if (Database.tbl.Rows.Count > 0)
                {
                    User.userid = int.Parse(Database.tbl.Rows[0]["id"].ToString());
                    User.currentUsername= Database.tbl.Rows[0]["username"].ToString();
                    login login = new login();
                    login.Close();
                    MessageBox.Show("Login Success");
                    MDI mdi = new MDI();
                    mdi.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Username and Password is invalid!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }
        public void setRolename(ComboBox cboRolename)
        {
            try
            {
                this.SQL = "SELECT * FROM tbl_role";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.ExecuteNonQuery();
                Database.da = new System.Data.SqlClient.SqlDataAdapter(Database.Cmd);
                Database.tbl = new System.Data.DataTable();
                Database.da.Fill(Database.tbl);
                foreach (DataRow r in Database.tbl.Rows)
                {
                    cboRolename.Items.Add(r["name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }
        public void Create()
        {
            try
            {   
                Database.ConnectiontoDB();
                this.SQL = "INSERT INTO tbl_user(username,gender,password,email,status,createAt,createBy)  " +
                    "VALUES (@username,@gender,@password,@email,@status,GETDATE(),@createBy)";
                Database.Cmd=new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.Parameters.AddWithValue("@username", this.username);
                Database.Cmd.Parameters.AddWithValue("@gender", this.gender);
                Database.Cmd.Parameters.AddWithValue("@password", this.password);
                Database.Cmd.Parameters.AddWithValue("@email", this.email);
                Database.Cmd.Parameters.AddWithValue("@status", this.status);
                Database.Cmd.Parameters.AddWithValue("@createBy", User.userid);
                this.roweffected=Database.Cmd.ExecuteNonQuery();
                
                MessageBox.Show("User Created SuccessFull!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            /*finally
            {
                if (database.Con != null && database.Con.State == ConnectionState.Open)
                {
                    database.Con.Close();
                }
            }*/
        }
        public void Update()
        {
            SqlConnection con = new SqlConnection();
            try
            {               
                if (this.id > 0)
                {
                
                    this.SQL = "UPDATE tbl_user SET username=@username,gender=@gender,password=@password,email=@email," +
                        "status=@status,updateAt=GETDATE(),updateBy=@updateBy WHERE id=@id";
                                                           
                    Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                    Database.Cmd.Parameters.AddWithValue("@username", this.username);
                    Database.Cmd.Parameters.AddWithValue("@gender", this.gender);
                    Database.Cmd.Parameters.AddWithValue("@password", this.password);
                    Database.Cmd.Parameters.AddWithValue("@email", this.email);
                    Database.Cmd.Parameters.AddWithValue("@status", this.status);
                    Database.Cmd.Parameters.AddWithValue("@updateBy", User.userid);
                    Database.Cmd.Parameters.AddWithValue("@id", this.id);

                    int rowsAffected = Database.Cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User updated successfully!");
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
                this.SQL = "delete from tbl_user where id=@id";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.Parameters.AddWithValue("@id", this.id);
                if (MessageBox.Show("Do you really want to delete this?", "Delete",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.roweffected = Database.Cmd.ExecuteNonQuery();
                    if (this.roweffected == 1)
                    {
                        MessageBox.Show("User deleted");
                        dg.Rows.Remove(DGV);
                    }
                }

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
                this.SQL = "select * from tbl_user where username like CONCAT('%', @username , '%')";
                Database.Cmd = new SqlCommand(this.SQL, Database.Con);
                Database.Cmd.Parameters.AddWithValue("@username", this.username);
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
        public override void loading_data(DataGridView dg)
        {
            try
            {
                this.SQL = "SELECT * FROM tbl_user";
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
        public void transferdata(DataGridView dg/*,ComboBox cboRolename*/,TextBox txtUsername,ComboBox cboGender,TextBox txtPassword, 
            TextBox txtemail,RadioButton rTrue, RadioButton rFalse)
        {
            this.DGV = dg.SelectedRows[0];
            /*cboRolename.Text = DGV.Cells[0].Value.ToString();*/
            txtUsername.Text = DGV.Cells[1].Value.ToString();
            cboGender.Text = DGV.Cells[2].Value.ToString();
            txtPassword.Text = DGV.Cells[3].Value.ToString();
            txtemail.Text = DGV.Cells[4].Value.ToString();
            if (DGV.Cells[5].Value.ToString().Equals("True"))
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
