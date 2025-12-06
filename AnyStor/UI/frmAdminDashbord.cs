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
    public partial class frmAdminDashbord : Form
    {
        public frmAdminDashbord()
        {
            InitializeComponent();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers user = new frmUsers();
            user.ShowDialog();
        }

        private void frmAdminDashbord_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void frmAdminDashbord_Load(object sender, EventArgs e)
        {
            lblUserLogign.Text = frmLogin.loggedIn;
        }

        private void categortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatagories catagories = new frmCatagories();
            catagories.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct product = new frmProduct();
            product.Show();
        }

        private void dealerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeaCust deaCust = new frmDeaCust();
            deaCust.Show();
        }

        private void tansactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransactions trn = new frmTransactions();
            trn.Show(); 
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventory inventory = new frmInventory();
            inventory.Show();
        }
    }
}
