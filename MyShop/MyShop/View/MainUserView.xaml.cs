using CourseProject.Model;
using CourseProject.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseProject.View
{
    public partial class MainWindow2 : Window
    {
        User User = UserViewModel.User;
        MainWindow2ViewModel mainWindow2ViewModel = new MainWindow2ViewModel();

        public MainWindow2()
        {
            InitializeComponent();
            DataContext = mainWindow2ViewModel;
            Title = "Главное окно";
        }

        void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        void GridBarTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        void fullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            this.MaxHeight = SystemParameters.WorkArea.Height + 10;

            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        void minScreenButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        void outButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow2ViewModel.OutFromMain();
        }

        private void menuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MoveCursorMenu(mainWindow2ViewModel.SelectedIndex);
        }

        private void MoveCursorMenu(int index)
        {
            TransitionSlider.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, 40 + (100 * index), 0, 0);
        }

        private void chip_Click(object sender, RoutedEventArgs e)
        {
            mainWindow2ViewModel.SelectedIndex = 1;
        }


    }

}