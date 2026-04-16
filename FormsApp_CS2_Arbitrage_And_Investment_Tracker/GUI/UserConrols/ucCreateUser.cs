using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
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
        private CS2TrackerContext _context;
        public ucCreateUser(CS2TrackerContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void ucCreateUser_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //create userService and get the data from the text boxes
            UserService userService = new UserService(_context);
            string username = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;

            //create the user
            ServiceResult serviceResult = await userService.CreateUser(username, email, password);
            if(serviceResult.Success == true)
            {
                MessageBox.Show("Created the acount succesffully!");
            }
            else
            {
                MessageBox.Show(serviceResult.ErrorMessage);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is Form1 mainForm)
            {
                mainForm.LoadUserControl(new ucLoginUser(_context));
            }
        }
    }
}
