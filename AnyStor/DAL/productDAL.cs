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
    internal class productDAL
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
                String sql = "SELECT * FROM tbl_products";

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
        public bool Insert(productBLL p)
        {
            // Connecting Beelean variable and set value false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Writing sql data Insert Query 
                String sql = "INSERT INTO tbl_products(name, category, description, rate, qty, added_date, added_by) VALUES(@name, @category, @description, @rate, @qty, @added_date, @added_by)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pasing Values
                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@category", p.category);
                cmd.Parameters.AddWithValue("@description", p.description);
                cmd.Parameters.AddWithValue("@rate", p.rate);
                cmd.Parameters.AddWithValue("@qty", p.qty);
                cmd.Parameters.AddWithValue("@added_date", p.added_date);
                cmd.Parameters.AddWithValue("@added_by", p.added_by);


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
        public bool Upddate(productBLL p)
        {
            // Connecting Beelean variable and set value false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Writing sql data Update Query 
                String sql = "UPDATE tbl_products SET name = @name, category = @category, description = @description, rate = @rate, added_date = @added_date, added_by = @added_by WHERE id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pasing Values
                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@category", p.category);
                cmd.Parameters.AddWithValue("@description", p.description);
                cmd.Parameters.AddWithValue("@rate", p.rate);
                cmd.Parameters.AddWithValue("@qty", p.qty);
                cmd.Parameters.AddWithValue("@added_date", p.added_date);
                cmd.Parameters.AddWithValue("@added_by", p.added_by);
                cmd.Parameters.AddWithValue("@id", p.id);

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
        public bool Delete(productBLL p)
        {
            // Connecting Beelean variable and set value false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Writing sql data Delete Query 
                String sql = "DELETE FROM tbl_products WHERE id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pasing Values
                cmd.Parameters.AddWithValue("@id", p.id);

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
        #region Search Products
        public DataTable Search(String keyword)
        {
            //ststic method to connect database
            SqlConnection conn = new SqlConnection(myconnstrng);
            //To hold data from database
            DataTable dt = new DataTable();

            try
            {
                //SQL Quert for select database
                String sql = "SELECT * FROM tbl_products WHERE id LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%' OR description LIKE '%" + keyword + "%' OR category LIKE '%" + keyword + "%'  ";
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

        #region METHOD TO SEARCH PRODUCT IN TRANSACTIN MODULE
        public productBLL ProductForTransaction(String keyword)
        {
            //Create object for productBLL and return it
            productBLL p = new productBLL();

            //Sql Cpnnection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Data Table to stre data temparaly
            DataTable dt = new DataTable();

            try
            {
                //Write the qury for get the details
                String sql = "SELECT name, rate, qty FROM tbl_products WHERE id LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%' ";

                //Create SQL Data Adapter for Execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                //Open Sql connection
                conn.Open();

                //Transfer value from adapter to dt
                adapter.Fill(dt);

                //Set the value from product BL
                if(dt.Rows.Count > 0)
                {
                    p.name = dt.Rows[0]["name"].ToString();
                    p.rate = decimal.Parse(dt.Rows[0]["rate"].ToString());
                    p.qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
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

            return p;
        }
        #endregion
        #region METHOD TO GET PRODUCT ID BASED ON PRODUCT NAME
        public productBLL GetDeaProductIDFromName(String ProductName)
        {
            //Create object and reteun it
            productBLL p = new productBLL();

            //Sql Connection Hear
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Crreate data Table to hold data
            DataTable dt = new DataTable();

            try
            {
                //SQL Query for get the Id fron name
                String sql = "SELECT id FROM tbl_products WHERE name = '" + ProductName + "'";

                //Create SQL Data Adapter EXecute the Query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                // Pasing the data Adapter to Database
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    //Pass the Value 
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
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

            return p;
        }
        #endregion
        #region METHOD OF GE CURREN QUENTITY BASER ON PRODUCT ID
        public decimal ProductQty(int productID)
        {
            //Create Sql Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create decimal value and set defalt value in 0 
            decimal qty = 0;

            //Crate Data Table to store data in database
            DataTable dt = new DataTable();

            try
            {
                //Write the SQL query for get the Quentity from database
                String sql = "SELECT qty FROM tbl_products WHERE id = " + productID;

                //Create Sql Command Statement
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create SQL Data Adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                conn.Open();

                //Pass Value 
                adapter.Fill(dt);

                //If Check Database has value or not
                if(dt.Rows.Count > 0 )
                {
                    qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
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

            return qty; 
        }
        #endregion
        #region METHOD TO UPDATE QUERY 
        public bool UpdatteQuery(int productId, decimal qty)
        {
            //Create boolean Value and set it vale False
            bool success = false;

            //Create Sql Connecion
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Write the SQL Qery for Update 
                String sql = "UPDATE tbl_products SET qty = @qty WHERE id = @id";

                //Create SQL Command for Execute Qury
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pasing the value truth parameter
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@id", productId);

                //Open DB Connection
                conn.Open();

                //Create int Variable and Check Update 
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    //Query is Successfuly
                    success = true;
                }
                else
                {
                    //Query is Faild
                    success = false;
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

            return success; 
        }
        #endregion
        #region METHOD TO INCRASE PRODUCT
        public bool IncraseProduct(int productId, decimal incraseQty)
        {
            //Create boolean Value and set it vale False
            bool success = false;

            //Create Sql Connecion
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Gett the current QTY from database on id 
                decimal currentQty = ProductQty(productId);

                decimal newQty = currentQty + incraseQty;

                //Update the product Quantity Now
                success = UpdatteQuery(productId, newQty);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return success;
        }
        #endregion
        #region METHOD TO DESCREASE PRODUCT
        public bool DescreasProduct(int productId, decimal qty)
        {
            //Create boolean Value and set it vale False
            bool success = false;

            //Create Sql Connecion
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Gett the current QTY from database on id 
                decimal currentQty = ProductQty(productId);

                decimal newQty = currentQty - qty;

                //Update the product Quantity Now
                success = UpdatteQuery(productId, newQty);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return success;
        }
        #endregion
        #region DESPLAY PRODUCTS BASED ON THE CATOGORY
        public DataTable DesplayProductsByCategory(String category)
        {
            //Create SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create data ^Table
            DataTable dt = new DataTable();

            try
            {
                //Write Sql Query 
                String sql = "SELECT * FROM tbl_products WHERE category = '" + category + "'";

                //SQL command to Execute Query 
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Crate SQL Data adapter 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database CDonnection 
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
    }
}
