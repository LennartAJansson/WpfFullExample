using System.Windows.Controls;

using WpfApp1.ViewModels;

namespace WpfApp1.Views
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