using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Common;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.MainApp;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.UserConrols;
using System;
using System.Windows.Forms;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the app with Login screen
            LoadUserControl(new ucLoginUser());
        }

        // Central method to switch screens
        public void LoadUserControl(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        // Called from ucLogin when login is successful
        public void LoginSuccessful()
        {
            LoadUserControl(new ucMainApp());   // Load your main application
        }
    }
}