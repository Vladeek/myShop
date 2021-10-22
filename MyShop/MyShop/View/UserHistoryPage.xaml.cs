using CourseProject;
using CourseProject.Model;
using CourseProject.Repositories;
using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyShop.View
{
    /// <summary>
    /// Логика взаимодействия для UserHistoryPage.xaml
    /// </summary>
    public partial class UserHistoryPage : Page
    {
        public UserHistoryPage()
        {
            InitializeComponent();
            DataContext = new UserHistoryPageViewModel();
        }
    }
    public class UserHistoryPageViewModel : ViewModelBase
    {
        private EFItemsRepository _efItemsRepository = new EFItemsRepository();
        private EFOrderRepository _basketRepository = new EFOrderRepository();

        public UserHistoryPageViewModel()
        {
            var baskets = _basketRepository.GetAll().ToList();
            var shopItems = _efItemsRepository.getAll().ToList();
            foreach (var basket in baskets)
            {
                var targetItems = shopItems.Where(x => x.Orders.Any(y => y == basket));
                basket.Items = targetItems.ToList();
            }

            OrderedItems = new ObservableCollection<Order>();

            PreOrderedItems = new ObservableCollection<Order>(baskets);
            foreach (Order or in PreOrderedItems)
                if (or.Email == UserViewModel.User.Mail)
                    OrderedItems.Add(or);

        }

        public ObservableCollection<Order> OrderedItems { get; set; }
        public ObservableCollection<Order> PreOrderedItems { get; set; }
        //public ICommand Remove { get; }
    }
}
