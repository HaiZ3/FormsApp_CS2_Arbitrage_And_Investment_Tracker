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
    public partial class ucCreateUser : UserControl
    {
        public ucCreateUser()
        {
            InitializeComponent();
        }

        private void ucCreateUser_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //create userService and get the data from the text boxes
            UserService userService = new UserService(Common.Common._context);
            string username = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;

            //create the user
            userService.CreateUser(username, email, password);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is Form1 mainForm)
            {
                mainForm.LoadUserControl(new ucLoginUser());
            }
        }
    }
}
