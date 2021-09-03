using Microsoft.Extensions.Logging;

using System.Windows;

using WpfWithWebApi.Wpf.ViewModels;

namespace WpfWithWebApi.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILogger<MainWindow> logger;

        public MainWindow(ILogger<MainWindow> logger, MainViewModel viewModel)
        {
            InitializeComponent();
            this.logger = logger;
            DataContext = viewModel;
            this.logger.LogDebug("Constructing MainWindow");
        }
    }
}