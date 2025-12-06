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
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        userBLL u = new userBLL();
        userDAL dal = new userDAL();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
            //Getting Data From UI
            u.fist_name = fnameTextBox.Text;
            u.last_name = lastNameTextBox.Text;
            u.email = emailTextBox.Text;
            u.username = usernameTextBox.Text;
            u.password = passwordTextBox.Text;
            u.contact = contacTextBox.Text;
            u.address = addressTextBox.Text;
            u.gender = genderComboBox.Text;
            u.user_type = userTypeComboBox.Text;
            u.added_date = DateTime.Now;

            //Getting User Name In Logged User 
            String loggedUser = frmLogin.loggedIn;
            userBLL usr = dal.GetIdFromUsername(loggedUser);
            u.added_by = usr.id;

            //Insert Data into Database
            bool success = dal.Insert(u);

            //Check data is insert
            if (success == true)
            {
                MessageBox.Show("User Sucessfuly Created...!");
                clear();
            }
            else
            {
                MessageBox.Show("Faild to add new user...!");
            }

            //Refresh Data Grid View
            DataTable dt = dal.Select();
            datagridViweUsers.DataSource = dt; 
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            datagridViweUsers.DataSource = dt;
        }

        private void clear()
        {
            userIdTextBox.Text = "";
            fnameTextBox.Text = "";
            lastNameTextBox.Text = "";
            emailTextBox.Text = "";
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
            contacTextBox.Text = "";
            addressTextBox.Text = "";
            genderComboBox.Text = "";
            userTypeComboBox.Text = "";
        }

        private void datagridViweUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index at row
            int rowIndex = e.RowIndex;

            userIdTextBox.Text = datagridViweUsers.Rows[rowIndex].Cells[0].Value.ToString();
            fnameTextBox.Text = datagridViweUsers.Rows[rowIndex].Cells[1].Value.ToString();
            lastNameTextBox.Text = datagridViweUsers.Rows[rowIndex].Cells[2].Value.ToString();
            emailTextBox.Text = datagridViweUsers.Rows[rowIndex].Cells[3].Value.ToString();
            usernameTextBox.Text = datagridViweUsers.Rows[rowIndex].Cells[4].Value.ToString();
            passwordTextBox.Text = datagridViweUsers.Rows[rowIndex].Cells[5].Value.ToString();
            contacTextBox.Text = datagridViweUsers.Rows[rowIndex].Cells[6].Value.ToString();
            addressTextBox.Text = datagridViweUsers.Rows[rowIndex].Cells[7].Value.ToString();
            genderComboBox.Text = datagridViweUsers.Rows[rowIndex].Cells[8].Value.ToString();
            userTypeComboBox.Text = datagridViweUsers.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void upladteButton_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(userIdTextBox.Text);
            u.fist_name = fnameTextBox.Text;
            u.last_name = lastNameTextBox.Text;
            u.email = emailTextBox.Text;
            u.username = usernameTextBox.Text;
            u.password = passwordTextBox.Text;
            u.contact = contacTextBox.Text;
            u.address = addressTextBox.Text;
            u.gender = genderComboBox.Text;
            u.user_type = userTypeComboBox.Text;
            u.added_date = DateTime.Now;
            u.added_by = 1;

            //Update Data into Database
            bool success = dal.Update(u);

            //Check data is Update
            if (success == true)
            {
                MessageBox.Show("User Sucessfuly Updated...!");
                clear();
            }
            else
            {
                MessageBox.Show("Faild to Update user Details...!");
            }
            //Refresh Data Grid View
            DataTable dt = dal.Select();
            datagridViweUsers.DataSource = dt;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(userIdTextBox.Text);

            //Delete Data into Database
            bool success = dal.Delete(u);

            //Check data is Delete
            if (success == true)
            {
                MessageBox.Show("User Data Sucessfuly Deleted...!");
                clear();
            }
            else
            {
                MessageBox.Show("Faild to Delete user Details...!");
            }
            //Refresh Data Grid View
            DataTable dt = dal.Select();
            datagridViweUsers.DataSource = dt;

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            String keyword = searchTextBox.Text;
            
            //Check text box is empty
            if(keyword != null)
            {
                //Show user based on key word
                DataTable dt = dal.Search(keyword);
                datagridViweUsers.DataSource = dt;
            }
            else
            {
                //Show all data
                DataTable dt = dal.Select();
                datagridViweUsers.DataSource = dt;
            }
        }
    }
}
