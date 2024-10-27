using System;
using System.Windows;
using System.Windows.Controls;
using netproject2.ViewModels;

namespace netproject2.Views
{
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
            if (DataContext is SignUpViewModel viewModel)
            {
                viewModel.CloseAction = () => this.Close();
            }
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is SignUpViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }

    }

}
