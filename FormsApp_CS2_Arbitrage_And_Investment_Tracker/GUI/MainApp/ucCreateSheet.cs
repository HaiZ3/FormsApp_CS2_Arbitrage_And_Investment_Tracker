using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.UserConrols;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
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
        private readonly ISheetService _sheetService;

        public ucCreateSheet(ISheetService sheetService)
        {
            _sheetService = sheetService;
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(SheetType));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string sheetName = textBox1.Text;
            SheetType sheetType = (SheetType)comboBox1.SelectedItem;

            ServiceResult isSheetCreated = await _sheetService.CreateSheet(UserSession.UserId, sheetName, sheetType);

            if (!isSheetCreated.Success)
            {
                MessageBox.Show(isSheetCreated.ErrorMessage);
                return;
            }

            MessageBox.Show("Successfully created the sheet");

            if (this.ParentForm is Form1 mainForm)
            {
                mainForm.LoadUserControl<ucMainApp>();
            }
        }

        private void ucCreateSheet_Load(object sender, EventArgs e)
        {
        }
    }
}