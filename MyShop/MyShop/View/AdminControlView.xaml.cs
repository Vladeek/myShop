using CourseProject.Model;
using CourseProject.Other;
using CourseProject.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace CourseProject.View
{

    public partial class AdminPage : Page
    {
        User User = UserViewModel.User;

        AdminControlViewModel adminPageViewModel = new AdminControlViewModel(new ViewWindow());

        public AdminPage()
        {
            InitializeComponent();
            DataContext = adminPageViewModel;
            radio1.IsChecked = true;
        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            adminPageViewModel.accept();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            adminPageViewModel.Delete();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            adminPageViewModel.Change();
        }

        private void radio1_Checked(object sender, RoutedEventArgs e)
        {
            adminPageViewModel.State = AdminPageState.Users;
            NoButton.Content = "Удалить";
            OkButton.Content = "Изменить\nпривелегии";
            OkButton.IsEnabled = true;
            ChangeButton.IsEnabled = false;
        }


        private void Radio4_OnChecked(object sender, RoutedEventArgs e)
        {
            adminPageViewModel.State = AdminPageState.Items;
            OkButton.Content = "Добавить";
            NoButton.Content = "Удалить";
            ChangeButton.IsEnabled = true;
        }
    }
}
