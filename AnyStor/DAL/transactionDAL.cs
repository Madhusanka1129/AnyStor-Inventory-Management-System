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
    internal class transactionDAL
    {
        //Method of Daabase connection
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Insert Transaction Method
        public bool Insert_Transaction(transacionBLL t, out int transactionID)
        {
            //Create Boolean Value and set it false
            bool isSuccess = false;
            //Set the transaction value with -1
            transactionID = -1;

            //Create sql Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {

                //Create SQL Query
                String sql = "INSERT INTO tbl_transactions(type, dea_cust_id, grandTotal, transaction_date, tax, discount, added_by) VALUES(@type, @dea_cust_id, @grandTotal, @transaction_date, @tax, @discount, @added_by)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@type", t.type);
                cmd.Parameters.AddWithValue("@dea_cust_id", t.dea_cust_id);
                cmd.Parameters.AddWithValue("@grandTotal", t.grandTotal);
                cmd.Parameters.AddWithValue("@transaction_date", t.transaction_date);
                cmd.Parameters.AddWithValue("@tax", t.tax);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                cmd.Parameters.AddWithValue("@added_by", t.added_by);

                //Open Database Connection
                conn.Open();

                // Execyte NonQuery
                object o = cmd.ExecuteNonQuery();

                // Check  IF Query is Execute Successfully 
                if(o != null )
                {
                    // Query Execute Successfully
                    transactionID = int.Parse(o.ToString());
                    isSuccess = true;
                }
                else
                {
                    // Faild Query Executed
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
        #region METHOD TO DESPLAY ALL TRANSACTINS
        public DataTable DesplayTransactions()
        {
            //Create SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create data ^Table
            DataTable dt = new DataTable();

            try
            {
                //Write Sql Query 
                String sql = "SELECT * FROM tbl_transactions";

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
        #region DESPLAY TRANSACTION BASED ON TRANSACTION TYPE
        public DataTable DesplayTransactionsByType(String type)
        {
            //Create SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create data ^Table
            DataTable dt = new DataTable();

            try
            {
                //Write Sql Query 
                String sql = "SELECT * FROM tbl_transactions WHERE type = '" + type + "'";

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
