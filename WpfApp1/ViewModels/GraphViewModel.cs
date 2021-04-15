using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

using ScottPlot;

using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public class GraphViewModel : ObservableObject
    {
        private WpfPlot wpfPlot;

        public AsyncRelayCommand<WpfPlot> LoadedCommand { get; }

        public GraphViewModel()
        {
            LoadedCommand = new AsyncRelayCommand<WpfPlot>(LoadedWpfPlot);
        }

        private Task LoadedWpfPlot(WpfPlot wpfPlot)
        {
            this.wpfPlot = wpfPlot;

            return Task.CompletedTask;
        }
    }
}
