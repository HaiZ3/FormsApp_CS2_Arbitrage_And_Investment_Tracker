using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Enums;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.AppStyles;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.MainApp;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Responses;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Session;
using System.Data;

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

            var items = new List<string> { "None" };
            items.AddRange(Enum.GetNames(typeof(ItemType)));
            comboBox4.DataSource = items;

            comboBox4.DisplayMember = "Name";  // if needed
            comboBox4.SelectedIndex = 0;  // default to "None"

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
            var result = await _sheetService.LoadSheetsAsync(UserSession.UserId);
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
            ItemType? itemType = null;
            if (comboBox4.SelectedIndex == 0)
            {

            }
            else
            {
                itemType = (ItemType)Enum.Parse(typeof(ItemType), comboBox4.SelectedItem.ToString());
            }

            var res = await _entryService.AddEntryAsync(sheetId, name, quantity
                , buyTime, null, buyPrice, null, itemFloat, skinCondition, skinVariant, itemType);

            if (res.Success == false)
            {
                MessageBox.Show(res.ErrorMessage);
            }
            else
            {
                MessageBox.Show("Entry added successfully!");
            }

            textBox1.Text = "";
            numericUpDown3.Value = 0.00m;
            numericUpDown2.Value = 0.00m;

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            int sheetId = (int)comboBox3.SelectedValue;

            ServiceResultGeneric<int[]> res = await _entryService.ImportFromCsvToSheetAsync(sheetId);

            if (res.Success)
            {
                MessageBox.Show($"Successfully imported {res.Data[1]} entries from CSV. Failed entries: {res.Data[0]}");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
