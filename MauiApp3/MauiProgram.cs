using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace MauiApp3
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            
            builder.Services.AddHttpClient<IRateService, RateService>(opt =>
                opt.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates"));

            builder.Services.AddSingleton<CurrencyConverterPage>();

            return builder.Build();
        }
    }
}


