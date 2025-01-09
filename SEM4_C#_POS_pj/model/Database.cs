using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEM4_C__POS_pj.model
{
    public class Database
    {

        public static SqlConnection Con = new SqlConnection
            (@"Data Source=TRAVYYY;
            Initial Catalog=DB_SU34_POS_MIDTERM;Integrated Security=True");

        /*Please change the integrated security according to your sql authentication type */
        public static SqlCommand Cmd;
        public static SqlDataAdapter da;
        public static DataTable tbl;    
        public static void ConnectiontoDB()
        {
            try
            {              
                if (Con.State == System.Data.ConnectionState.Closed)
                {
                    Con.Open();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }


    }
}
