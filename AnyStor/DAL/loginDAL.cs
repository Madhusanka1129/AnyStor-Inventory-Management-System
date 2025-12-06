using AnyStor.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStor.DAL
{
    internal class loginDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public bool loginCheck(loginBLL l)
        {
            //create boolen variable and set it
            bool isSuccess = false;

            //Connecet to the Database 
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                String sql = "SELECT * FROM  tbl_users WHERE username = @username AND password = @password AND user_type = @user_type";

                //Pass value
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);
                cmd.Parameters.AddWithValue("@user_type", l.user_type);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Checking rows in data table 
                if(dt.Rows.Count>0)
                {
                    //Login Sucess
                    isSuccess = true;
                }
                else
                {
                    // Login Faild
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close() ;
            }
            return isSuccess;
        }
    }
}
