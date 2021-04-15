using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Windows;

using WpfApp1.Configuration;
using WpfApp1.Services;
using WpfApp1.ViewModels;
using WpfApp1.Views;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(builder => builder.AddJsonFile("WindowsInfo.json", optional: true))
                .ConfigureServices((context, services) => services
                    .AddApplicationConfigurations(context)
                    .AddApplicationViewModels()
                    .AddApplicationViews()
                    .AddApplicationServices())
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            host.Services
                .GetRequiredService<MainWindow>()
                .Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync();
            }

            base.OnExit(e);
        }
    }
}