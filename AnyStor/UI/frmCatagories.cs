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
    public partial class frmCatagories : Form
    {
        public frmCatagories()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        categoriesBLL c = new categoriesBLL() ;
        categoriesDAL dal = new categoriesDAL() ;
        userDAL udal = new userDAL();

        // Add Button code
        private void addButton_Click(object sender, EventArgs e)
        {
            //Get the Values from catogory
            c.title = titleTextBox.Text;
            c.description = descriptionTextBox.Text;
            c.added_date = DateTime.Now;

            //Getting Id in added by Field
            String loggedUser = frmLogin.loggedIn;
            userBLL usr = new GetIdFormUsername(loggedUser);
            c.added_by = usr.id;

            //Create a boolean method to insert data into database
            bool success = dal.Insert(c);

            //Check data is insert
            if(success == true )
            {
                //New category insert is successfuly
                MessageBox.Show("New Category Inserted Successfully.");
                Clear();
            }
            else
            {
                //Faild Insert new Category
                MessageBox.Show("Failed to Insert New Query");
            }

            //Refesh all categories in data gridwive
            DataTable dt = dal.Select();
            datagridViweCategories.DataSource = dt;
        }

        //Create Clear Method
        public void Clear()
        {
            categortIDTextBox.Text = "";
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            searchTextBox.Text = "";
        }

        //Form Load code
        private void frmCatagories_Load(object sender, EventArgs e)
        {
            //Desplay all categories in data gridwive
            DataTable dt = dal.Select();
            datagridViweCategories.DataSource = dt;
        }

        //Data grid code
        private void datagridViweCategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Fine the Row index and create ,ouse clock event 
            int RowIndex = e.RowIndex;

            categortIDTextBox.Text = datagridViweCategories.Rows[RowIndex].Cells[0].Value.ToString();
            titleTextBox.Text = datagridViweCategories.Rows[RowIndex].Cells[1].Value.ToString();
            descriptionTextBox.Text = datagridViweCategories.Rows[RowIndex].Cells[2].Value.ToString();

        }

        //Update button code
        private void upladteButton_Click(object sender, EventArgs e)
        {
            //Get the value from catogory form
            c.id = int.Parse(categortIDTextBox.Text);
            c.title = titleTextBox.Text;
            c.description = descriptionTextBox.Text;
            c.added_date = DateTime.Now;
            //Getting Id in added by Field
            String loggedUser = frmLogin.loggedIn;
            userBLL usr = new GetIdFormUsername(loggedUser);
            c.added_by = usr.id;

            //Create a boolean method to Update data into database
            bool success = dal.Upddate(c);

            //Check data is Update
            if (success == true)
            {
                //New category Update is successfuly
                MessageBox.Show("New Category Update Successfully.");
                Clear();
            }
            else
            {
                //Faild Update new Category
                MessageBox.Show("Failed to Update New Query");
            }

            //Refesh all categories After Updated the data gridwive
            DataTable dt = dal.Select();
            datagridViweCategories.DataSource = dt;

        }

        //Delete button code
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Get the Id of category
            c.id = int.Parse(categortIDTextBox.Text);

            // Creating boolean variable for delete categoy
            bool success = dal.Delete(c);

            //Check data is Update
            if (success == true)
            {
                //New category Delete is successfuly
                MessageBox.Show("New Category Delete Successfully.");
                Clear();
            }
            else
            {
                //Faild Delete new Category
                MessageBox.Show("Failed to Delete New Query");
            }

            //Refesh all categories After DElete the data gridwive
            DataTable dt = dal.Select();
            datagridViweCategories.DataSource = dt;

        }

        //Search button code
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            String keyword = searchTextBox.Text;

            //Check text box is empty
            if (keyword != null)
            {
                //Show user based on key word
                DataTable dt = dal.Search(keyword);
                datagridViweCategories.DataSource = dt;
            }
            else
            {
                //Show all data
                DataTable dt = dal.Select();
                datagridViweCategories.DataSource = dt;
            }
        }
    }
}
