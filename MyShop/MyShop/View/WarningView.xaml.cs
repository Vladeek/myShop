using System.Windows;
using System.Windows.Input;

namespace CourseProject.View
{
    /// <summary>
    /// Логика взаимодействия для AlertWindow.xaml
    /// </summary>
    public partial class AlertWindow : Window
    {
        string message;

        public string Message
        {
            get { return message; }
        }

        public AlertWindow()
        {
            InitializeComponent();
            Title = "Сообщение";
        }
        public AlertWindow(string message)
        {
            InitializeComponent();
            DataContext = this;
            this.message = message;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
