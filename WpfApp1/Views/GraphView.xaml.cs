
using System.Windows.Controls;

using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for GraphView.xaml
    /// </summary>
    public partial class GraphView : UserControl
    {
        public GraphView(GraphViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
