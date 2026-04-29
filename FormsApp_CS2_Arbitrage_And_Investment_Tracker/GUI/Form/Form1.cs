
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.MainApp;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.UserConrols;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker
{
    public partial class Form1 : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISheetService _sheetService;

        public Form1(IServiceProvider serviceProvider, ISheetService sheetService)
        {
            _serviceProvider = serviceProvider;
            _sheetService = sheetService;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the app with Login screen
            LoadUserControl<ucLoginUser>();
        }

        // Central method to switch screens
        public void LoadUserControl<T>() where T : UserControl
        {
            var uc = _serviceProvider.GetRequiredService<T>();
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        // Called from ucLogin when login is successful
        public void LoginSuccessful()
        {
            LoadUserControl<ucMainApp>();
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}