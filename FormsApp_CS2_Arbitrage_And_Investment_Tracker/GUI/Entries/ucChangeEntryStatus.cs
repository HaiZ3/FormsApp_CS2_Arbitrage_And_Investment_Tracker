using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.AppStyles;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.MainApp;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.DTOs;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Responses;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Session;
using Microsoft.Identity.Client;
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
    public partial class ucChangeEntryStatus : UserControl
    {
        ISheetService _sheetService;
        IEntryService _entryService;
        public ucChangeEntryStatus(ISheetService sheetService, IEntryService entryService)
        {
            InitializeComponent();

            _sheetService = sheetService;
            _entryService = entryService;

            Styler.StyleDataGridView(dataGridView1);

            Styler.StyleButton(button1, "Close the entry");
            Styler.StyleButton(button2, "Back to Main Menu");
            Styler.StyleButton(button3, "Load the Entries");

            BackColor = Color.FromArgb(37, 37, 38);
            comboBox1.DataSource = Enum.GetValues(typeof(EntryStatus));

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";

            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 1000000;
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Increment = 0.01M;
        }

        private async void ucChangeEntryStatus_Load(object sender, EventArgs e)
        {
            ServiceResultGeneric<ICollection<Sheet>> res = await _sheetService.LoadSheetsAsync(UserSession.UserId);
            if (!res.Success)
            {
                MessageBox.Show(res.ErrorMessage);
            }
            comboBox2.DataSource = res.Data.ToArray();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is frmMain mainForm)
            {
                mainForm.LoadUserControl<ucMainApp>();
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int sheetId = (int)comboBox2.SelectedValue;
            ServiceResultGeneric<ICollection<Entry>> res = await _entryService.GetEntriesBySheetAsync(sheetId);
            if (!res.Success)
            {
                MessageBox.Show(res.ErrorMessage);
            }
            dataGridView1.DataSource = res.Data.Where(x => x.Status == EntryStatus.Open).Select(x => new EntryDisplayDto
            {
                Name = x.Name,
                BuyPrice = x.BuyPrice,
                Status = x.Status,
                Quantity = x.Quantity,
                DateBought = x.DateBought,
                SellPrice = x.SellPrice,
                DateSold = x.DateSold
            })
            .ToArray();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            decimal sellPrice = numericUpDown1.Value;
            DateTime dateSold = dateTimePicker1.Value;
            EntryStatus newStatus = (EntryStatus)comboBox1.SelectedItem;

            int entryId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

            if(newStatus == EntryStatus.Closed && sellPrice <= 0)
            {
                MessageBox.Show("Please enter a valid sell price.");
                return;
            }

            if(newStatus == EntryStatus.Closed)
            {
                ServiceResult res = await _entryService.CloseEntryAsync(entryId, dateSold, sellPrice);
                if (!res.Success)
                {
                    MessageBox.Show(res.ErrorMessage);
                }
                else
                {
                    MessageBox.Show("Entry closed successfully.");
                }
            }
            if (newStatus == EntryStatus.Cancelled)
            {
                ServiceResult res = await _entryService.CancelEntryAsync(entryId);
                if (!res.Success)
                {
                    MessageBox.Show(res.ErrorMessage);
                }
                else
                {
                    MessageBox.Show("Entry cancelled successfully.");
                }
            }
        }
    }
}
