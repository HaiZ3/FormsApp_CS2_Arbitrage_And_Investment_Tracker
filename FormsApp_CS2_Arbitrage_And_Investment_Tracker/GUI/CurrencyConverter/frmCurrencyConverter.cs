using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.AppStyles;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.CurrencyConverter
{
    public partial class frmCurrencyConverter : Form
    {
        private ICurrencyService _currencyService;
        private List<string> _currenices = new List<string>() { "USD","CNY","EUR"};
        public frmCurrencyConverter(ICurrencyService currencyService)
        {
            InitializeComponent();
            this.Icon = new Icon("Resources/CS2Tracker_logo.ico");
            _currencyService = currencyService;
            Styler.StyleButton(button1, "Convert");
            Styler.StyleButton(button2, "Refresh Rates");
            Styler.StyleButton(button3, "Close the converter");
            Styler.StyleButton(button4, "Swap currencies");
            BackColor = Color.FromArgb(37, 37, 38);
            this.ControlBox = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string fromCurrency = comboBox1.Text;
            string toCurrency = comboBox2.Text;

            decimal amount = decimal.Parse(textBox1.Text);

            ServiceResultGeneric<decimal> res = await _currencyService.ConvertCurrencyAsync(fromCurrency, toCurrency, amount);

            if (!res.Success)
            {
                MessageBox.Show(res.ErrorMessage);
                return;
            }

            textBox2.Text = $"{res.Data:f2}";
        }
        private void frmCurrencyConverter_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = _currenices.ToList();
            comboBox2.DataSource = _currenices.ToList();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ServiceResult res = await _currencyService.FetchCurrencyInfoAndSaveRatesAsync();
            if (!res.Success)
            {
                MessageBox.Show(res.ErrorMessage);
                return;
            }
            MessageBox.Show("Rates refreshed");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var tempFrom = comboBox1.SelectedItem;
            comboBox1.SelectedItem = comboBox2.SelectedItem;
            comboBox2.SelectedItem = tempFrom;

            var tempAmount = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = tempAmount;
        }
    }
}
