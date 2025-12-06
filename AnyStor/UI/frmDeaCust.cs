using AnyStor.BLL;
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
    public partial class frmDeaCust : Form
    {
        public frmDeaCust()
        {
            InitializeComponent();
        }
        
        //Hide the Database
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        DeaCustBLL dc = new DeaCustBLL();
        DeaCustDAL dcdal = new DeaCustDAL();

        userDAL uDal = new userDAL();

        //Insert Data
        private void addButton_Click(object sender, EventArgs e)
        {
            //Get all Values from Product Form
            dc.type = typeComboBox.Text;
            dc.name = nameTextBox.Text;
            dc.email = emailTexxtBox.Text;
            dc.contact = contactTextBox.Text;
            dc.address = addressTextBox.Text;
            dc.added_date = DateTime.Now;
            //Getting Id in added by Field
            String loggedUser = frmLogin.loggedIn;
            userBLL usr = new GetIdFormUsername(loggedUser);
            dc.added_by = usr.id;

            //Create a boolean method to insert data into database
            bool success = dcdal.Insert(dc);

            //Check data is insert
            if (success == true)
            {
                //New category insert is successfuly
                MessageBox.Show("New Dealer or Customer Inserted Successfully.");
                Clear();

            }
            else
            {
                //Faild Insert new Category
                MessageBox.Show("Failed to Insert New Dealer or Customer");
            }

            //Refesh all Products in data gridwive
            DataTable dt = dcdal.Select();
            datagridViweDeAndCust.DataSource = dt;
        }

        //Clear Method
        public void Clear()
        {
            deCustIdTextBox.Text = "";
            typeComboBox.Text = "";
            nameTextBox.Text = "";
            emailTexxtBox.Text = "";
            contactTextBox.Text = "";
            addressTextBox.Text = "";
            searchTextBox.Text = "";
        }

        //Form Load Event
        private void frmDeaCust_Load(object sender, EventArgs e)
        {
            //Refesh all Products in data gridwive
            DataTable dt = dcdal.Select();
            datagridViweDeAndCust.DataSource = dt;
        }

        //Row Click Event
        private void datagridViweDeAndCust_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Fine the Row index and create ,mouse clock event 
            int RowIndex = e.RowIndex;

            deCustIdTextBox.Text = datagridViweDeAndCust.Rows[RowIndex].Cells[0].Value.ToString();
            typeComboBox.Text = datagridViweDeAndCust.Rows[RowIndex].Cells[1].Value.ToString();
            nameTextBox.Text = datagridViweDeAndCust.Rows[RowIndex].Cells[2].Value.ToString();
            emailTexxtBox.Text = datagridViweDeAndCust.Rows[RowIndex].Cells[3].Value.ToString();
            contactTextBox.Text = datagridViweDeAndCust.Rows[RowIndex].Cells[4].Value.ToString();
            addressTextBox.Text = datagridViweDeAndCust.Rows[RowIndex].Cells[5].Value.ToString();
        }

        //Update
        private void upladteButton_Click(object sender, EventArgs e)
        {
            //Get all Values from Product Form
            dc.id = int.Parse(deCustIdTextBox.Text);
            dc.type = typeComboBox.Text;
            dc.name = nameTextBox.Text;
            dc.email = emailTexxtBox.Text;
            dc.contact = contactTextBox.Text;
            dc.address = addressTextBox.Text;
            dc.added_date = DateTime.Now;
            //Getting Id in added by Field
            String loggedUser = frmLogin.loggedIn;
            userBLL usr = new GetIdFormUsername(loggedUser);
            dc.added_by = usr.id;

            //Create a boolean method to Update data into database
            bool success = dcdal.Upddate(dc);

            //Check data is Update
            if (success == true)
            {
                //New category Dealer or Custemor is successfuly
                MessageBox.Show("Dealer or Custemor Update Successfully.");
                Clear();
            }
            else
            {
                //Faild Update new Category
                MessageBox.Show("Failed to Update Dealer or Custemor");
            }

            //Refesh all categories After Updated the data gridwive
            DataTable dt = dcdal.Select();
            datagridViweDeAndCust.DataSource = dt;
        }

        //Delete
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Get the Id of Product
            dc.id = int.Parse(deCustIdTextBox.Text);

            // Creating boolean variable for delete categoy
            bool success = dcdal.Delete(dc);

            //Check data is Update
            if (success == true)
            {
                //New Dealer or Custemor Delete is successfuly
                MessageBox.Show("Dealer or Custemor Delete Successfully.");
                Clear();
            }
            else
            {
                //Faild Delete new Dealer or Custemor
                MessageBox.Show("Dealer or Custemor to Delete Product");
            }

            //Refesh all categories After DElete the data gridwive
            DataTable dt = dcdal.Select();
            datagridViweDeAndCust.DataSource = dt;
        }

        //search
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            String keyword = searchTextBox.Text;

            //Check text box is empty
            if (keyword != null)
            {
                //Show user based on key word
                DataTable dt = dcdal.Search(keyword);
                datagridViweDeAndCust.DataSource = dt;
            }
            else
            {
                //Show all data
                DataTable dt = dcdal.Select();
                datagridViweDeAndCust.DataSource = dt;
            }
        }
    }
}
