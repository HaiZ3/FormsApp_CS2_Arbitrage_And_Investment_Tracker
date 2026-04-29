using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.Entries;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.UserConrols;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Responses;
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
    public partial class ucMainApp : UserControl
    {
        private ISheetService _sheetService;
        public ucMainApp(ISheetService sheetService)
        {
            InitializeComponent();
            _sheetService = sheetService;
            var sheetLoader = _sheetService.LoadSheets(UserSession.UserId);
            comboBox1.DataSource = sheetLoader.Result.Data;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            StyleDataGridView(dataGridView1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is Form1 mainForm)
            {
                mainForm.LoadUserControl<ucCreateSheet>();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            int sheetId = (int)comboBox1.SelectedValue;

            var result = await _sheetService.GetSheetById(sheetId);
            if (result.Success == false)
            {
                MessageBox.Show(result.ErrorMessage);
                return;
            }

            dataGridView1.DataSource = result.Data;
        }
        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 35;

            dgv.GridColor = Color.FromArgb(50, 50, 50);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
        }

        private void ucMainApp_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is Form1 mainForm)
            {
                mainForm.LoadUserControl<ucAddEntry>();
            }
        }
    }
}
