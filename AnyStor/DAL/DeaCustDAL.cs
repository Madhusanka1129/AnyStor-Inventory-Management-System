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
    internal class DeaCustDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Method 
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                //Write SQL query for get all data from database
                String sql = "SELECT * FROM tbl_dea_cust";

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
        public bool Insert(DeaCustBLL dc)
        {
            // Connecting Beelean variable and set value false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Writing sql data Insert Query 
                String sql = "INSERT INTO tbl_dea_cust(type,name,email,contact,address, added_date, added_by) VALUES(@type,@name,@email,@contact,@address, @added_date, @added_by)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pasing Values
                cmd.Parameters.AddWithValue("@type", dc.type);
                cmd.Parameters.AddWithValue("@name", dc.name);
                cmd.Parameters.AddWithValue("@email", dc.email);
                cmd.Parameters.AddWithValue("@contact", dc.contact);
                cmd.Parameters.AddWithValue("@address", dc.address);
                cmd.Parameters.AddWithValue("@added_date", dc.added_date);
                cmd.Parameters.AddWithValue("@added_by", dc.added_by);


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
        public bool Upddate(DeaCustBLL dc)
        {
            // Connecting Beelean variable and set value false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Writing sql data Update Query 
                String sql = "UPDATE tbl_dea_cust SET type = @type, name = @name, email = @email, contact = @contact, address = @address,  added_date = @added_date,  added_by = @added_by WHERE id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pasing Values
                cmd.Parameters.AddWithValue("@type", dc.type);
                cmd.Parameters.AddWithValue("@name", dc.name);
                cmd.Parameters.AddWithValue("@email", dc.email);
                cmd.Parameters.AddWithValue("@contact", dc.contact);
                cmd.Parameters.AddWithValue("@address", dc.address);
                cmd.Parameters.AddWithValue("@added_date", dc.added_date);
                cmd.Parameters.AddWithValue("@added_by", dc.added_by);
                cmd.Parameters.AddWithValue("@id", dc.id);

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
        public bool Delete(DeaCustBLL dc)
        {
            // Connecting Beelean variable and set value false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Writing sql data Delete Query 
                String sql = "DELETE FROM tbl_dea_cust WHERE id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pasing Values
                cmd.Parameters.AddWithValue("@id", dc.id);

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
                String sql = "SELECT * FROM tbl_dea_cust WHERE id LIKE '%" + keyword + "%' OR type LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%' ";
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
        #region METHOD TO SEARCH or CUSTOMER FOR TRANSACTION MODULE
        public DeaCustBLL SelectDealerCustemorForTransaction(string keyword)
        {
            //Create the Object for DeaCstBLL Class
            DeaCustBLL dc = new DeaCustBLL();

            //Create Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create data Table
            DataTable dt = new DataTable(); 

            try
            {
                //SQL Quert for select database
                String sql = "SELECT name, email, contact, address FROM tbl_dea_cust WHERE id LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%' ";

                // Create Sql Data Adapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                //Open sql Connection 
                conn.Open();

                //Transfer data from Sql DataAdapter
                adapter.Fill(dt);

                //If we have Values on dt we need to save it in dealerCusstomer BLL
                if(dt.Rows.Count  > 0)
                {
                    dc.name = dt.Rows[0]["name"].ToString();
                    dc.email = dt.Rows[0]["email"].ToString();
                    dc.contact = dt.Rows[0]["contact"].ToString();
                    dc.address = dt.Rows[0]["address"].ToString();
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
            return dc;
        }
        #endregion
        #region METOD TO GET ID OF THE DEALER OR CUSTEMER BASED ON NAME 
        public DeaCustBLL GetDeaCustIDFromName(String name)
        {
            //Create object and reteun it
            DeaCustBLL dc = new DeaCustBLL();

            //Sql Connection Hear
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Crreate data Table to hold data
            DataTable dt = new DataTable();

            try
            {
                //SQL Query for get the Id fron name
                String sql = "SELECT id FROM tbl_dea_cust WHERE name = '" + name + "'";

                //Create SQL Data Adapter EXecute the Query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                // Pasing the data Adapter to Database
                adapter.Fill(dt); 

                if (dt.Rows.Count > 0)
                {
                    //Pass the Value 
                    dc.id = int.Parse(dt.Rows[0]["id"].ToString());
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

            return dc; 
        }
        #endregion
    
    }
}
