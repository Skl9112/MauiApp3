using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MauiApp3
{
    public partial class CurrencyConverterPage : ContentPage
    {
        private readonly IRateService _rateService;
        private IEnumerable<Rate> _rates;

        public CurrencyConverterPage(IRateService rateService)
        {
            InitializeComponent();
            _rateService = rateService;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadRates(DateTime.Today);
        }

        private async void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            await LoadRates(e.NewDate);
        }

        private async Task LoadRates(DateTime date)
        {
            _rates = await _rateService.GetRates(date);
            CurrencyPicker.ItemsSource = _rates.Select(r => r.Cur_Name).ToList();
        }

        private void OnConvertClicked(object sender, EventArgs e)
        {
            if (_rates == null || !double.TryParse(AmountEntry.Text, out double amount))
            {
                return;
            }

            var selectedCurrency = CurrencyPicker.SelectedItem as string;
            var rate = _rates.FirstOrDefault(r => r.Cur_Name == selectedCurrency);

            if (rate != null)
            {
                double convertedAmount = amount / rate.Cur_OfficialRate;
                ResultLabel.Text = $"{amount} BYN = {convertedAmount} {rate.Cur_Abbreviation}";
            }
        }
    }
}