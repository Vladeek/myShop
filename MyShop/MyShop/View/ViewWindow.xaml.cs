using System.Windows;
using System.Windows.Input;

namespace CourseProject.View
{
    public partial class ViewWindow : Window
    {
        public ViewWindow()
        {
            InitializeComponent();
            Title = "Окно просмотра";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
