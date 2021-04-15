using System.Windows.Controls;

using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {
        public PersonView(PersonViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}