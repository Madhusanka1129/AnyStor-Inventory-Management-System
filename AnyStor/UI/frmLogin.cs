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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        loginBLL l = new loginBLL();
        loginDAL dal = new loginDAL();
        public static String loggedIn; 

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            l.username = usernameTextBox.Text.Trim();
            l.password = passwordTextBox.Text.Trim();
            l.user_type = userTypeComboBox.Text.Trim();

            // Checking the login 
            bool sucess = dal.loginCheck(l);
            if (sucess == true )
            {
                // Login Sucess 
                MessageBox.Show("Login Sucessful...!");
                loggedIn = l.username;

                //need open separate user window for Admin and Users 
                switch(l.user_type)
                {
                    case "Admin":
                        {
                            //Display Admin Dashborad
                            frmAdminDashbord admin = new frmAdminDashbord();
                            admin.Show();
                            this.Hide();
                        }
                        break;
                    case "User":
                        {
                            //Display User Dashborad
                            frmUserDashbord user = new frmUserDashbord();
                            user.Show();
                            this.Hide(); 

                        }
                        break;
                    default:
                        {
                            //Display Error Message.....!
                            MessageBox.Show("Invalid User Type....!");
                        }
                        break;
                }
            }
            else
            {
                // Login Faild  
                MessageBox.Show("Login Faild..! Try Again."); 
            }

        }
    }
}
