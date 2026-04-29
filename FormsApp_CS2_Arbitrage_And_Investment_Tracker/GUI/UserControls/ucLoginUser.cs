using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Helpers;
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
        IUserService _userService;
        public ucLoginUser(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text;
            string passwordHash = textBox2.Text;

            ServiceResult succesfullLogin = await _userService.LoginUser(username, passwordHash);

            if (this.ParentForm is Form1 mainForm && succesfullLogin.Success == true)
            {
                MessageBox.Show("Succesfful Login!");
                mainForm.LoginSuccessful();   // Switch to main app
            }
            else
            {
                MessageBox.Show(succesfullLogin.ErrorMessage);
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            // Get reference to parent Form1 and load Create Account screen
            if (this.ParentForm is Form1 mainForm)
            {
                mainForm.LoadUserControl<ucCreateUser>();
            }
        }

        private void ucLoginUser_Load(object sender, EventArgs e)
        {

        }
    }
}
