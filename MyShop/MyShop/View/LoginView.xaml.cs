using CourseProject.View;
using CourseProject_WPF_.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CourseProject_WPF_.View
{

    public partial class AuthWindow : Window
    {
        private readonly LoginViewModel _authWindowViewModel;
        public AuthWindow()
        {
            InitializeComponent();
            _authWindowViewModel = new LoginViewModel();
            DataContext = _authWindowViewModel;
            Title = "Авторизация";
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridBarTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void collapseClose_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            if (_authWindowViewModel.CompareDataOfUser(passwordBox.Password))
            {
                Close();
            }

            //for Design
            // ...

        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            var registrationWindow = new RegistrationWindow();
            registrationWindow.Show();

            //for Design
            //...

        }

        private void mailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            mailTextBox.BorderBrush = string.IsNullOrEmpty(mailTextBox.Text) ? Brushes.Red : Brushes.LimeGreen;
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            passwordBox.BorderBrush = string.IsNullOrEmpty(passwordBox.Password) ? Brushes.Red : Brushes.LimeGreen;
        }

    }
}
