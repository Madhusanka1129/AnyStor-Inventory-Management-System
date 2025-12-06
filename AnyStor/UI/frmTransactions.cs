using AnyStor.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStor.UI
{
    public partial class frmTransactions : Form
    {
        public frmTransactions()
        {
            InitializeComponent();
        }

        transactionDAL tdal = new transactionDAL();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            //Desplay all transactions
            DataTable dt = tdal.DesplayTransactions();
            transactionDataGrid.DataSource = dt; 
        }

        private void transactionTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the Value From combo box
            String type = transactionTypeComboBox.Text;

            DataTable dt = tdal.DesplayTransactionsByType(type);
            transactionDataGrid.DataSource = dt;

        }

        private void allButton_Click(object sender, EventArgs e)
        {
            //Desplay all transactions
            DataTable dt = tdal.DesplayTransactions();
            transactionDataGrid.DataSource = dt;
        }
    }
}
