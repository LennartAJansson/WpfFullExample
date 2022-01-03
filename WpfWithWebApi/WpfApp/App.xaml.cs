using System.Windows;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WpfWithWebApi.Wpf.Configuration;
using WpfWithWebApi.Wpf.Services;
using WpfWithWebApi.Wpf.ViewModels;
using WpfWithWebApi.Wpf.Views;

namespace WpfWithWebApi.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App() =>
            //Microsoft.Windows.Themes.ThemeColor.Metallic
            host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(builder => builder.AddJsonFile("WindowsInfo.json", optional: true))
                .ConfigureServices((context, services) => services
                    .AddApplicationConfigurations(context)
                    .AddApplicationViewModels()
                    .AddApplicationViews()
                    .AddApplicationServices())
                .Build();

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