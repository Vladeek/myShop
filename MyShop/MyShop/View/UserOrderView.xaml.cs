using CourseProject.Model;
using CourseProject_WPF_.ViewModel;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CourseProject_WPF_.View
{
    public partial class UserCartPage : Page
    {
        UserOrderViewModel viewModel;
        public UserCartPage(IEnumerable<Item> orderedItems)
        {
            viewModel= new UserOrderViewModel(orderedItems);
            InitializeComponent();
            DataContext = viewModel;
        }
        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        public void ListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            viewModel.ShowInfo();
        }
    }
}