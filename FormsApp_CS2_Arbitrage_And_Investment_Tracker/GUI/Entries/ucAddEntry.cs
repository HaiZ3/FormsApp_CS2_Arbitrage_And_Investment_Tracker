using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.Entries
{
    public partial class ucAddEntry : UserControl
    {
        CS2TrackerContext _context;
        public ucAddEntry(CS2TrackerContext context)
        {
            _context = context;
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(SkinCondition))
                .Cast<SkinCondition>()
                .Select(e => new { Value = (SkinCondition?)e, Text = e.ToString() })
                .Prepend(new { Value = (SkinCondition?)null, Text = "None" })
                .ToList();

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

            //SkinCondition? skinCondition = (SkinCondition?)comboBox1.SelectedValue;
        }

        private void ucAddEntry_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            decimal? itemFloat = (decimal)numericUpDown2.Value;
            if(itemFloat == 0)
            {
                itemFloat = null;
            }
            SkinCondition? skinCondition = (SkinCondition?)comboBox1.SelectedItem;
            SkinVariant skinVariant = (SkinVariant)comboBox2.SelectedItem;
            DateTime buyTime = (DateTime)dateTimePicker1.Value;
            int quantity = (int)numericUpDown1.Value;
            EntryService entryService = new EntryService(_context);
            ServiceResult res = entryService.AddEntry();
            //Add the sheet id and we are nearly done with adding a new entry
        }
    }
}
