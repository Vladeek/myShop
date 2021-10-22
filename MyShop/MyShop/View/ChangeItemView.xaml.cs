using CourseProject.ViewModel;
using System;
using System.Windows;
using System.Windows.Media;
using CourseProject.Model;
using CourseProject.Repositories;
using System.Linq;

namespace CourseProject.View
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        ChangeItemViewModel changeWindowViewModel;
        public Item OldItem { get; set; }
        private EFItemsRepository _shopItemsRepository = new EFItemsRepository();

        public ChangeWindow(Item oldItem)
        {
            InitializeComponent();
            OldItem = oldItem;
            changeWindowViewModel = new ChangeItemViewModel(OldItem);
            DataContext = changeWindowViewModel;
            Category.ItemsSource = _shopItemsRepository.getCategories().Distinct().ToList();
            Title = "Изменение товара";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (changeWindowViewModel.ChangeItem(Name.Text, Category.Text, Cost.Text, About.Text))
            {
                Close();
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            changeWindowViewModel.clear();
            addButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF464648"));
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void AddImageButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (changeWindowViewModel.SelectImage())
            {
                addImageButton.Content = "Изображение добавлено";
            }
        }

        private void Cost_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }
    }
}
