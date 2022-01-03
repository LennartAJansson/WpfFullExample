﻿using System.Windows.Controls;

using WpfWithWebApi.Wpf.ViewModels;

namespace WpfWithWebApi.Wpf.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView(UserViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
