using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.UserConrols
{
    public partial class ucLoginUser : UserControl
    {
        public ucLoginUser()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //create the UserService and login the user
            UserService userService = new UserService(Common.Common._context);

            string username = textBox1.Text;
            string passwordHash = textBox2.Text;

            userService.LoginUser(username, passwordHash);

            if (this.ParentForm is Form1 mainForm)
            {
                mainForm.LoginSuccessful();   // Switch to main app
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            // Get reference to parent Form1 and load Create Account screen
            if (this.ParentForm is Form1 mainForm)
            {
                mainForm.LoadUserControl(new ucCreateUser());
            }
        }
    }
}
