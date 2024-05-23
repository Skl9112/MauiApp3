using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnOpenCurrencyConverterClicked(object sender, EventArgs e)
        {
            var rateService = App.Current.Handler.MauiContext.Services.GetService<IRateService>();
            await Navigation.PushAsync(new CurrencyConverterPage(rateService));
        }

        private async void OnOpenIntegrationPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IntegrationPage());
        }
    }
}