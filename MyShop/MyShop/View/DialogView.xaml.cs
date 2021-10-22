using System.Windows;
using System.Windows.Input;

namespace CourseProject.View
{
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
            Title = "Dialog";
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
