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

        private void passwordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            //https://stackoverflow.com/questions/1483892/how-to-bind-to-a-passwordbox-in-mvvm
            if (DataContext != null)
            {
                ((dynamic)DataContext).Password = ((PasswordBox)sender).Password;
                ((dynamic)DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword;
            }
        }
    }
}