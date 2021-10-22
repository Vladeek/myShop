using CourseProject.Other;
using CourseProject.ViewModel;
using CourseProject_WPF_.View;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CourseProject.View
{
    public partial class RegistrationWindow : Window
    {

        RegistrationViewModel registrationViewModel = new RegistrationViewModel();

        public RegistrationWindow()
        {
            InitializeComponent();
            DataContext = registrationViewModel;
            Title = "Регистрация";
        }

        private void collapseClose_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            infoLabel.Foreground = registrationViewModel.Registration
            (HashHelper.GetMd5Hash(pass1NameTextBox.Password), HashHelper.GetMd5Hash(pass2NameTextBox.Password)) ? Brushes.LimeGreen : Brushes.Red;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();

        }

        private void firstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            firstNameTextBox.BorderBrush = !string.IsNullOrEmpty(firstNameTextBox.Text) ? Brushes.LimeGreen : Brushes.Red;
            compare();
        }

        private void secondNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            secondNameTextBox.BorderBrush = !string.IsNullOrEmpty(secondNameTextBox.Text) ? Brushes.LimeGreen : Brushes.Red;
            compare();
        }

        private void mailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            mailTextBox.BorderBrush = !string.IsNullOrEmpty(mailTextBox.Text) ? Brushes.LimeGreen : Brushes.Red;
            compare();
        }

        private void pass1NameTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (pass2NameTextBox.Password.Equals(pass1NameTextBox.Password))
            {
                pass1NameTextBox.BorderBrush = Brushes.LimeGreen;
                pass2NameTextBox.BorderBrush = Brushes.LimeGreen;
            }
            else
            {
                pass1NameTextBox.BorderBrush = Brushes.Red;
                pass2NameTextBox.BorderBrush = Brushes.Red;
            }

            compare();

        }

        private void pass2NameTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (pass2NameTextBox.Password.Equals(pass1NameTextBox.Password))
            {
                pass1NameTextBox.BorderBrush = Brushes.LimeGreen;
                pass2NameTextBox.BorderBrush = Brushes.LimeGreen;
            }
            else
            {
                pass1NameTextBox.BorderBrush = Brushes.Red;
                pass2NameTextBox.BorderBrush = Brushes.Red;
            }

            compare();

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        void compare()
        {
            if (pass2NameTextBox.Password.Equals(pass1NameTextBox.Password) &&
                !String.IsNullOrEmpty(pass1NameTextBox.Password) &&
                !String.IsNullOrEmpty(firstNameTextBox.Text) &&
                !String.IsNullOrEmpty(secondNameTextBox.Text) &&
                !String.IsNullOrEmpty(mailTextBox.Text))
            {
                registrationButton.IsEnabled = true;
            }
            else
            {
                registrationButton.IsEnabled = false;
            }
        }
    }
}
