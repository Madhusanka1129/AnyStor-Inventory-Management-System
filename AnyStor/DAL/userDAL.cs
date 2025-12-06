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
    internal class userDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
    
    #region Select Data From DataBase
    public DataTable Select()
      {
            //ststic method to connect database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //To hold data from database
            DataTable dt = new DataTable();

            try
            {
                //SQL Quert for select database
                String sql = "SELECT * FROM tbl_users";
                //For executing Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Get the data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Database Connection Open
                conn.Open();
                //Fill Data In our Data Table
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Show message some error occer
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Closing Connection 
                conn.Close();
            }
            return dt;
        }
        #endregion

    #region Insert Data into Database
        public bool Insert(userBLL u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                String sql = "INSERT INTO tbl_users(" +
                    "fist_name," +
                    "last_name," +
                    "email," +
                    "username," +
                    "password, " +
                    "contact, " +
                    "address, " +
                    "gender, " +
                    "user_type, " +
                    "added_date, " +
                    "added_by) " +
                    "VALUES(" +
                    "@fist_name, " +
                    "@last_name, " +
                    "@email, " +
                    "@username, " +
                    "@password, " +
                    "@contact, " +
                    "@address, " +
                    "@gender, " +
                    "@user_type, " +
                    "@added_date, " +
                    "@added_by)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@fist_name", u.fist_name);
                cmd.Parameters.AddWithValue("@last_name", u.last_name);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@contact", u.contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        #endregion

    #region Update Data in Database
    public bool Update(userBLL u)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                String sql = "UPDATE tbl_users SET fist_name=@fist_name, last_name=@last_name, email=@email, username=@username, password=@password, contact=@contact, address=@address, gender=@gender, user_type=@user_type, added_date=@added_date, added_by=@added_by WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@fist_name", u.fist_name);
                cmd.Parameters.AddWithValue("@last_name", u.last_name);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@contact", u.contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                cmd.Parameters.AddWithValue("@id", u.id);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return isSuccess;
        }
        #endregion

    #region Delete Data From Database
        public bool Delete(userBLL u)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                String sql = "DELETE FROM tbl_users WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", u.id);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close(); 
            }

            return isSuccess;

        }
        #endregion

        #region Serch Data Using Text Box
        public DataTable Search(String keyword)
        {
            //ststic method to connect database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //To hold data from database
            DataTable dt = new DataTable();

            try
            {
                //SQL Quert for select database
                String sql = "SELECT * FROM tbl_users WHERE id LIKE '%" + keyword +"%' OR fist_name LIKE '%" + keyword +"%' OR last_name LIKE '%" + keyword +"%' OR username LIKE '%" + keyword +"%' ";
                //For executing Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Get the data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Database Connection Open
                conn.Open();
                //Fill Data In our Data Table
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Show message some error occer
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Closing Connection 
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region Getting User Id from User Name
        public userBLL GetIdFromUsername(String username)
        {
            userBLL u = new userBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable(); 

            try
            {
                String sql = "SELECT * FROM tbl_users WHERE username = '" + username + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0 )
                {
                    u.id = int.Parse(dt.Rows[0]["id"].ToString());
                }

            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            finally
            {
                conn.Close();
            }
            return u;
        }
        #endregion
    }
}
