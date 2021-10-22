using CourseProject.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace CourseProject.View
{
    public partial class PersonAreaPage : Page
    {
        AccountViewModel personAreaViewModel = new AccountViewModel();

        public PersonAreaPage()
        {
            InitializeComponent();
            DataContext = personAreaViewModel;
        }

        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            //infoLabel.Foreground = personAreaViewModel.ChangeDataOfUser
            //(Info = "Изменения успешно сохранены!") ? Brushes.LimeGreen : Brushes.Red;
            personAreaViewModel.ChangeDataOfUser();
        }

        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            personAreaViewModel.DeleteUser();
        }

        private void imageButton_Click(object sender, RoutedEventArgs e)
        {
            personAreaViewModel.LoadImageFromFS();
        }
    }
}
