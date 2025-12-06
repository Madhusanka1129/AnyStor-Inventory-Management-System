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
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
        }

        categoriesDAL cdal = new categoriesDAL();
        productDAL pdal = new productDAL();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            //Desplay all categories in combobox
            DataTable cDt = cdal.Select();

            categoryComboBox.DataSource = cDt;

            //Give the Value Member and desplay member for ComboBox
            categoryComboBox.DisplayMember = "title";
            categoryComboBox.ValueMember = "title";

            //Display all data in Data Grid
            DataTable pdt = pdal.Select();
            inventoryDataGrid.DataSource = pdt;
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Desplay all the Product Based on Category
            String category = categoryComboBox.Text;

            DataTable dt = pdal.DesplayProductsByCategory(category);
            inventoryDataGrid.DataSource = dt;
        }

        private void allButton_Click(object sender, EventArgs e)
        {
            //Display all the product that button is Click
            DataTable dt = pdal.Select();
            inventoryDataGrid.DataSource = dt; 
        }
    }
}
