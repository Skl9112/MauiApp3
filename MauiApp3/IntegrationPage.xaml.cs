using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiApp3
{
    public partial class IntegrationPage : ContentPage
    {
        private CancellationTokenSource _cts;

        public IntegrationPage()
        {
            InitializeComponent();
        }

        private async void OnStartClicked(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();
            StatusLabel.Text = "Вычисление...";
            Progress.Progress = 0;
            ProgressLabel.Text = "0%";

            try
            {
                double result = await CalculateIntegralAsync(_cts.Token);
                StatusLabel.Text = $"Результат вычисления интеграла: {result}";
            }
            catch (OperationCanceledException)
            {
                StatusLabel.Text = "Задание отменено";
            }
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            _cts?.Cancel();
        }

        private async Task<double> CalculateIntegralAsync(CancellationToken token)
        {
            double a = 0;
            double b = 1;
            double step = 0.00000001;
            double result = 0;

            int totalSteps = (int)((b - a) / step);
            for (int i = 0; i < totalSteps; i++)
            {
                token.ThrowIfCancellationRequested();

                double x = a + i * step;
                result += Math.Sin(x) * step;

                if (i % 100000 == 0)
                {
                    Progress.Progress = (double)i / totalSteps;
                    ProgressLabel.Text = $"{Progress.Progress:P0}";

                    
                    for (int j = 0; j < 100000; j++)
                    {
                        double dummy = Math.Sqrt(j);
                    }

                    await Task.Yield();
                }
            }

            return result;
        }
    }
}