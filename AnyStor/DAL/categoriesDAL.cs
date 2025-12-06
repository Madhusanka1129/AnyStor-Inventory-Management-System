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
    internal class categoriesDAL
    {
        //Method of Daabase connection
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Method 
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                //Write SQL query for get all data from database
                String sql = "SELECT * FROM tbl_categories";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // Open db Connection 
                conn.Open();

                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        #endregion
        #region Insert New Catogory 
        public bool Insert(categoriesBLL c)
        {
            // Connecting Beelean variable and set value false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Writing sql data Insert Query 
                String sql = "INSERT INTO tbl_categories(title, description, added_date, added_by) VALUES(@title, @description, @added_date, @added_by)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pasing Values
                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);

                //Open db Connection
                conn.Open();

                //Creating int varriable to execute query 
                int rows = cmd.ExecuteNonQuery();

                //Check Quert

                if (rows > 0)
                {
                    //Sucess 
                    isSuccess = true;
                }
                else
                {
                    //Faild
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
        #region Update Catogories 
        public bool Upddate(categoriesBLL c)
        {
            // Connecting Beelean variable and set value false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Writing sql data Update Query 
                String sql = "UPDATE tbl_categories SET title = @title, description = @description, added_date = @added_date, added_by = @added_by WHERE id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pasing Values
                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);
                cmd.Parameters.AddWithValue("@id", c.id);

                //Open db Connection
                conn.Open();

                //Creating int varriable to execute query 
                int rows = cmd.ExecuteNonQuery();

                //Check Quert

                if (rows > 0)
                {
                    //Sucessfly  Execute query 
                    isSuccess = true;
                }
                else
                {
                    //Faild Execute Query
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
        #region Delete  Catogory
        public bool Delete(categoriesBLL c)
        {
            // Connecting Beelean variable and set value false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Writing sql data Delete Query 
                String sql = "DELETE FROM tbl_categories WHERE id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pasing Values
                cmd.Parameters.AddWithValue("@id", c.id);

                //Open db Connection
                conn.Open();

                //Creating int varriable to execute query 
                int rows = cmd.ExecuteNonQuery();

                //Check Quert

                if (rows > 0)
                {
                    //Sucessfly  Execute query 
                    isSuccess = true;
                }
                else
                {
                    //Faild Execute Query
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
        #region Search Date
        public DataTable Search(String keyword)
        {
            //ststic method to connect database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //To hold data from database
            DataTable dt = new DataTable();

            try
            {
                //SQL Quert for select database
                String sql = "SELECT * FROM tbl_categories WHERE id LIKE '%" + keyword + "%' OR title LIKE '%" + keyword + "%' OR description LIKE '%" + keyword + "%' ";
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
            #endregion

        }
    }
}
