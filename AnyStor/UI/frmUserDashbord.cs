using AnyStor.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStor
{
    public partial class frmUserDashbord : Form
    {
        public frmUserDashbord()
        {
            InitializeComponent();
        }

        //Create Public Static Method
        public static string transactionType; 

        private void frmUserDashbord_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void frmUserDashbord_Load(object sender, EventArgs e)
        {
            userNameLabel.Text = frmLogin.loggedIn;
        }

        private void dealerAndCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeaCust deaCust = new frmDeaCust();
            deaCust.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set the value of transactionType
            transactionType = "PURCHASE";

            frmPerchesAndSales ps = new frmPerchesAndSales();
            ps.Show();

        }

        private void salesFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set the value of transactionType
            transactionType = "SALES";

            frmPerchesAndSales sal = new frmPerchesAndSales();
            sal.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventory inventory = new frmInventory();
            inventory.Show();
        }
    }
}
