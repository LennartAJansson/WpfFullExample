using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
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
        private MainWindow mainWindow;

        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => ConfigureAppServices(context, services))
                .Build();
            ServiceProvider = host.Services;
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
            mainWindow = ServiceProvider.GetRequiredService<MainWindow>();

            if (System.IO.File.Exists(@".\windowsinfo.json"))
            {
                string json = System.IO.File.ReadAllText(@".\windowsinfo.json");
                var state = System.Text.Json.JsonSerializer.Deserialize<WindowsInfo>(json);
                mainWindow.Height = state.Height;
                mainWindow.Width = state.Width;
                mainWindow.Left = state.Left;
                mainWindow.Top = state.Top;
                mainWindow.WindowState = state.State;
            }
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            var state = new WindowsInfo
            {
                Height = mainWindow.Height,
                Width = mainWindow.Width,
                Left = mainWindow.Left,
                Top = mainWindow.Top,
                State = mainWindow.WindowState
            };
            string json = System.Text.Json.JsonSerializer.Serialize(state);
            System.IO.File.WriteAllText(@".\windowsinfo.json", json);

            using (host)
            {
                await host.StopAsync();
            }
            base.OnExit(e);
        }
    }

    public class WindowsInfo
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public double Left { get; set; }

        public double Top { get; set; }

        public WindowState State { get; set; }
    }
}