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
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }
        //Hide Form
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        categoriesDAL cdal = new categoriesDAL();
        productBLL p = new productBLL();
        productDAL pdal = new productDAL();

        //Form Load
        private void frmProduct_Load(object sender, EventArgs e)
        {
            //Creating Data Tables to holde the categories from darabase
            DataTable categoriesDT = cdal.Select();

            //Specify database for category combo box
            caregoryComboBox.DataSource = categoriesDT;

            //Specify database Member and Value
            caregoryComboBox.DisplayMember = "title";
            caregoryComboBox.ValueMember = "title";

            //Refesh all Products in data gridwive
            DataTable dt = pdal.Select();
            datagridViweProducts.DataSource = dt;
        }

        //Add button
        private void addButton_Click(object sender, EventArgs e)
        {
            //Get all Values from Product Form
            p.name = nameTextBox.Text;
            p.category = caregoryComboBox.Text;
            p.description = descriptionTextBox.Text;
            p.rate = decimal.Parse(rateTextBox.Text);
            p.qty = 0 ;
            p.added_date = DateTime.Now;
            //Getting Id in added by Field
            String loggedUser = frmLogin.loggedIn;
            userBLL usr = new GetIdFormUsername(loggedUser);
            p.added_by = usr.id;

            //Create a boolean method to insert data into database
            bool success = pdal.Insert(p);

            //Check data is insert
            if (success == true)
            {
                //New category insert is successfuly
                MessageBox.Show("New Product Inserted Successfully.");
                Clear();

            }
            else
            {
                //Faild Insert new Category
                MessageBox.Show("Failed to Insert New Product");
            }

            //Refesh all Products in data gridwive
            DataTable dt = pdal.Select();
            datagridViweProducts.DataSource = dt;
        }

        //Create Clear() Method
        public void Clear()
        {
            productIdTextBxc.Text = "";
            nameTextBox.Text = "";
            caregoryComboBox.Text = "";
            descriptionTextBox.Text = "";
            rateTextBox.Text = "";
            searchTextBox.Text = "";
        }
        
        //Cell content Click Event
        private void datagridViweProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Fine the Row index and create ,mouse clock event 
            int RowIndex = e.RowIndex;

            productIdTextBxc.Text = datagridViweProducts.Rows[RowIndex].Cells[0].Value.ToString();
            nameTextBox.Text = datagridViweProducts.Rows[RowIndex].Cells[1].Value.ToString();
            caregoryComboBox.Text = datagridViweProducts.Rows[RowIndex].Cells[2].Value.ToString();
            descriptionTextBox.Text = datagridViweProducts.Rows[RowIndex].Cells[3].Value.ToString();
            rateTextBox.Text = datagridViweProducts.Rows[RowIndex].Cells[4].Value.ToString();
        }

        //Row Header Mouse Click Event
        private void datagridViweProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Fine the Row index and create ,mouse clock event 
            int RowIndex = e.RowIndex;

            productIdTextBxc.Text = datagridViweProducts.Rows[RowIndex].Cells[0].Value.ToString();
            nameTextBox.Text = datagridViweProducts.Rows[RowIndex].Cells[1].Value.ToString();
            caregoryComboBox.Text = datagridViweProducts.Rows[RowIndex].Cells[2].Value.ToString();
            descriptionTextBox.Text = datagridViweProducts.Rows[RowIndex].Cells[3].Value.ToString();
            rateTextBox.Text = datagridViweProducts.Rows[RowIndex].Cells[4].Value.ToString();

        }

        //Update Product
        private void upladteButton_Click(object sender, EventArgs e)
        {
            //Get the value from Product form
            p.id = int.Parse(productIdTextBxc.Text);
            p.name = nameTextBox.Text;
            p.category = caregoryComboBox.Text;
            p.description = descriptionTextBox.Text;
            p.rate = decimal.Parse(rateTextBox.Text);
            p.added_date = DateTime.Now;
            //Getting Id in added by Field
            String loggedUser = frmLogin.loggedIn;
            userBLL usr = new GetIdFormUsername(loggedUser);
            p.added_by = usr.id;

            //Create a boolean method to Update data into database
            bool success = pdal.Upddate(p);

            //Check data is Update
            if (success == true)
            {
                //New category Update is successfuly
                MessageBox.Show("Product Update Successfully.");
                Clear();
            }
            else
            {
                //Faild Update new Category
                MessageBox.Show("Failed to Update Product");
            }

            //Refesh all categories After Updated the data gridwive
            DataTable dt = pdal.Select();
            datagridViweProducts.DataSource = dt;

        }

        //Delete Product
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Get the Id of Product
            p.id = int.Parse(productIdTextBxc.Text);

            // Creating boolean variable for delete categoy
            bool success = pdal.Delete(p);

            //Check data is Update
            if (success == true)
            {
                //New Product Delete is successfuly
                MessageBox.Show("Product Delete Successfully.");
                Clear();
            }
            else
            {
                //Faild Delete new Product
                MessageBox.Show("Failed to Delete Product");
            }

            //Refesh all categories After DElete the data gridwive
            DataTable dt = pdal.Select();
            datagridViweProducts.DataSource = dt;
        }

        //Serch product
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            String keyword = searchTextBox.Text;

            //Check text box is empty
            if (keyword != null)
            {
                //Show user based on key word
                DataTable dt = pdal.Search(keyword);
                datagridViweProducts.DataSource = dt;
            }
            else
            {
                //Show all data
                DataTable dt = pdal.Select();
                datagridViweProducts.DataSource = dt;
            }
        }
    }
}
