using CourseProject.ViewModel;
using System.Windows;
using System.Windows.Media;

namespace CourseProject.View
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        AddItemViewModel addWindowViewModel = new AddItemViewModel();

        public AddWindow()
        {
            InitializeComponent();
            DataContext = addWindowViewModel;
            Title = "Добавление товара";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (addWindowViewModel.AddNewItem())
            {
                Close();
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            addWindowViewModel.clear();
            addButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF464648"));
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void AddImageButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (addWindowViewModel.SelectImage())
            {
                addImageButton.Content = "Изображение добавлено";
            }
        }
    }
}