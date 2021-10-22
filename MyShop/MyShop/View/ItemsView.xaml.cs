using CourseProject.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace CourseProject.View
{
    public partial class AllAnnouncement : Page
    {
        public ItemsViewModel viewModel;

        public AllAnnouncement()
        {
            InitializeComponent();
            viewModel = new ItemsViewModel();
            DataContext = viewModel;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.search();
        }

        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            if (down.Visibility == Visibility.Visible)
            {
                viewModel.Sort();
                down.Visibility = Visibility.Hidden;
                up.Visibility = Visibility.Visible;
            }
            else
            {
                viewModel.Sort();
                up.Visibility = Visibility.Hidden;
                down.Visibility = Visibility.Visible;
            }

        }

        private void ListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            viewModel.ShowInfo();
        }
    }
}
