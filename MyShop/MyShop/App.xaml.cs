using CourseProject.View;
using CourseProject_WPF_.View;
using System.Windows;

namespace CourseProject
{
    public partial class App : Application
    {
        public static AuthWindow authWindow;
        public static MainWindow mainWindow;
        public static MainWindow2 mainWindow2;


        private void Application_Startup(object sender, StartupEventArgs e)
        {
            authWindow = new AuthWindow();
            authWindow.Show();
        }
    }
}
