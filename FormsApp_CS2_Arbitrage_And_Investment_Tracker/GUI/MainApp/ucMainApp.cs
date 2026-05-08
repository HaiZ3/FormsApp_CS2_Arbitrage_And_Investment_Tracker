using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.AppStyles;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.CurrencyConverter;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.Entries;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.DTOs;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Responses;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Session;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.MainApp
{
    public partial class ucMainApp : UserControl
    {
        private ISheetService _sheetService;
        private IEntryService _entryService;
        private frmCurrencyConverter _currencyForm;
        private readonly IServiceProvider _serviceProvider;

        public ucMainApp(ISheetService sheetService, IEntryService entryService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _sheetService = sheetService;
            _entryService = entryService;
            _serviceProvider = serviceProvider;
            Styler.StyleButton(button1, "Add Entry");
            Styler.StyleButton(button2, "Load an existing sheet");
            Styler.StyleButton(button3, "Create a new Sheet");
            Styler.StyleButton(button4, "Close an entry");
            Styler.StyleButton(button5, "Currency Converter");
            Styler.StyleDataGridView(dataGridView1);
            BackColor = Color.FromArgb(37, 37, 38);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is frmMain mainForm)
            {
                mainForm.LoadUserControl<ucCreateSheet>();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {


            int? sheetId = (int?)comboBox1.SelectedValue;

            if (!sheetId.HasValue)
            {
                ServiceResultGeneric<ICollection<Sheet>> sheetLoader = await _sheetService.LoadSheetsAsync(UserSession.UserId);
                if (!sheetLoader.Success)
                {
                    MessageBox.Show(sheetLoader.ErrorMessage);
                }
                comboBox1.DataSource = sheetLoader.Data;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
                return;
            }

            ServiceResultGeneric<Sheet> result = await _sheetService.GetSheetByIdAsync(sheetId);
            if (result.Success == false)
            {
                MessageBox.Show(result.ErrorMessage);
                return;
            }

            if (result.Data.Entries == null || result.Data.Entries.Count == 0)
            {
                MessageBox.Show("No entries found for this sheet.");
                return;
            }

            EntryDisplayDto[] dgvSource = result.Data.Entries.Select(e => new EntryDisplayDto
            {
                Id = e.Id,
                Name = e.Name,
                Quantity = e.Quantity,
                BuyPrice = $"{e.BuyPrice:f2}$",
                SellPrice = $"{e.SellPrice:f2}$",
                DateBought = e.DateBought,
                DateSold = e.DateSold,
                Status = e.Status,
                Profit = $"{e.Profit:f2}$",
                ReturnPercent = $"{e.Return:f2}%",
            }).OrderBy(x => x.Status).ToArray();

            dataGridView1.DataSource = dgvSource;
        }

        private async void ucMainApp_Load(object sender, EventArgs e)
        {
            ServiceResultGeneric<ICollection<Sheet>> sheetLoader = await _sheetService.LoadSheetsAsync(UserSession.UserId);
            if (!sheetLoader.Success)
            {
                MessageBox.Show(sheetLoader.ErrorMessage);
            }
            comboBox1.DataSource = sheetLoader.Data;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is frmMain mainForm)
            {
                mainForm.LoadUserControl<ucAddEntry>();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is frmMain mainForm)
            {
                mainForm.LoadUserControl<ucChangeEntryStatus>();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<frmCurrencyConverter>();
            form.Show();
        }
    }
}
