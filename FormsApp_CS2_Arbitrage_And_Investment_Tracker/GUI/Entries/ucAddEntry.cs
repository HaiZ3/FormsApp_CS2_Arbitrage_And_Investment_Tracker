using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.AppStyles;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.MainApp;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Responses;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Services;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.Entries
{
    public partial class ucAddEntry : UserControl
    {
        ISheetService _sheetService;
        IEntryService _entryService;
        public ucAddEntry(IEntryService entryService, ISheetService sheetService)
        {
            _entryService = entryService;
            _sheetService = sheetService;

            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(SkinCondition))
                .Cast<SkinCondition>()
                .Select(e => new { Value = (SkinCondition?)e, Text = e.ToString() })
                .Prepend(new { Value = (SkinCondition?)null, Text = "None" })
                .ToList();

            Styler.StyleButton(button1, "Add the Entry");
            Styler.StyleButton(button2, "Back to Main Menu");
            Styler.StyleButton(button3, "Import from the CSV");
            BackColor = Color.FromArgb(37, 37, 38);

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";

            comboBox2.DataSource = Enum.GetValues(typeof(SkinVariant));

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";

            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 100000;
            numericUpDown1.DecimalPlaces = 0;
            numericUpDown1.Value = 1;

            numericUpDown2.Minimum = 0;
            numericUpDown2.Maximum = 1;
            numericUpDown2.DecimalPlaces = 10;
            numericUpDown2.Increment = 0.0000000001M;


            numericUpDown3.Minimum = 0;
            numericUpDown3.Maximum = 1000000;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown3.Increment = 0.01M;
        }

        private async void ucAddEntry_Load(object sender, EventArgs e)
        {
            var result = await _sheetService.LoadSheets(UserSession.UserId);
            if (!result.Success)
            {
                MessageBox.Show("Failed to load sheets.");
                return;
            }
            comboBox3.DataSource = result.Data;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            decimal? itemFloat = (decimal)numericUpDown2.Value;

            if (itemFloat == 0)
            {
                itemFloat = null;
            }

            SkinCondition? skinCondition = (SkinCondition?)comboBox1.SelectedValue;
            SkinVariant skinVariant = (SkinVariant)comboBox2.SelectedValue;
            DateTime buyTime = (DateTime)dateTimePicker1.Value;
            int quantity = (int)numericUpDown1.Value;
            int sheetId = (int)comboBox3.SelectedValue;
            decimal buyPrice = numericUpDown3.Value;

            var res = await _entryService.AddEntry(sheetId, name, quantity
                , buyTime, null, buyPrice, null, itemFloat, skinCondition, skinVariant);

            if (res.Success == false)
            {
                MessageBox.Show(res.ErrorMessage);
            }
            else
            {
                MessageBox.Show("Entry added successfully!");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is Form1 mainForm)
            {
                mainForm.LoadUserControl<ucMainApp>();
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int sheetId = (int)comboBox3.SelectedValue;

            ServiceResultGeneric<int[]> res = await _entryService.ImportFromCsvToSheet(sheetId);

            if (res.Success)
            {
                MessageBox.Show($"Successfully imported {res.Data[1]} entries from CSV. Failed entries: {res.Data[0]}");
            }
        }
    }
}
