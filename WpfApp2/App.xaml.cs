using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Windows;

using WpfApp2.Configurations;
using WpfApp2.Services;
using WpfApp2.ViewModels;
using WpfApp2.Views;

namespace WpfApp2
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
                         .AddApplicationConfiguration(context)
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
