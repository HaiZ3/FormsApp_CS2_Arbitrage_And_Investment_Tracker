using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.UserConrols;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Services;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.MainApp
{
    public partial class ucCreateSheet : UserControl
    {
        private CS2TrackerContext _context;
        public ucCreateSheet(CS2TrackerContext context)
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(SheetType));
            _context = context;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string sheetName = textBox1.Text;
            SheetType sheetType = (SheetType)comboBox1.SelectedItem;
            SheetService sheetService = new SheetService(_context);
            ServiceResult isSheetCreated = await sheetService.CreateSheet(UserSession.UserId, sheetName, sheetType);
            if(isSheetCreated.Success is false)
            {
                MessageBox.Show(isSheetCreated.ErrorMessage);
                return;
            }
            MessageBox.Show("Succesffully created the sheet");
            if (this.ParentForm is Form1 mainForm)
            {
                mainForm.LoadUserControl(new ucMainApp(_context));
            }
        }
    }
}
