using AnyStor.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStor.DAL
{
    internal class transactionDetail
    {
        //Method of Daabase connection
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;


        #region Insert Transaction Details Method
        public bool InsertTransactionDetail(transactionDetailsBLL td)
        {
            //Create Boolean Value and set it false
            bool isSuccess = false;

            //Create sql Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {

                //Create SQL Query
                String sql = "INSERT INTO tbl_tansaction_detail(product_id, rate, qty, total, dea_cust_id, added_date, added_by) VALUES(@product_id, @rate, @qty, @total, @dea_cust_id, @added_date, @added_by); SELECT @@IDENTITY;";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@product_id", td.product_id);
                cmd.Parameters.AddWithValue("@rate", td.rate);
                cmd.Parameters.AddWithValue("@qty", td.qty);
                cmd.Parameters.AddWithValue("@total", td.total);
                cmd.Parameters.AddWithValue("@dea_cust_id", td.dea_cust_id);
                cmd.Parameters.AddWithValue("@added_date", td.added_date);
                cmd.Parameters.AddWithValue("@added_by", td.added_by);

                //Open Database Connection
                conn.Open();

                // Execyte NonQuery
                int rows = cmd.ExecuteNonQuery();

                // Check  IF Query is Execute Successfully 
                if (rows > 0)
                {
                    // Query Execute Successfully
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
    }
}
