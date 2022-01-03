using System.Windows.Controls;

using WpfWithWebApi.Wpf.ViewModels;

namespace WpfWithWebApi.Wpf.Views
{
    /// <summary>
    /// Interaction logic for PeopleView.xaml
    /// </summary>
    public partial class PeopleView : UserControl
    {
        public PeopleView(PeopleViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}