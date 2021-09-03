using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Windows;

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

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => ConfigureAppServices(context, services))
                .Build();
        }

        private static void ConfigureAppServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddApplicationConfiguration(context);
            services.AddApplicationViewModels();
            services.AddApplicationServices();
            services.AddTransient<MainWindow>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            host.Services.GetRequiredService<MainWindow>().Show();

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