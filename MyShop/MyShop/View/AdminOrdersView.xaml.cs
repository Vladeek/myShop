using CourseProject.Model;
using CourseProject.Repositories;
using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.ViewModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseProject_WPF_.View
{
    public partial class AdminOrdersPage : Page
    {
        public AdminOrdersPage()
        {
            InitializeComponent();
            DataContext = new AdminOrdersPageViewModel();
        }
    }

    public class AdminOrdersPageViewModel : ViewModelBase
    {
        private EFItemsRepository _efItemsRepository = new EFItemsRepository();
        private EFOrderRepository _basketRepository = new EFOrderRepository();

        public AdminOrdersPageViewModel()
        {
            var baskets = _basketRepository.GetAll().ToList();
            var shopItems = _efItemsRepository.getAll().ToList();
            foreach (var basket in baskets)
            {
                var targetItems = shopItems.Where(x => x.Orders.Any(y => y == basket));
                basket.Items = targetItems.ToList();
            }

            OrderedItems = new ObservableCollection<Order>(baskets);
            Remove = new RelayCommand(arg =>
            {
                if (!(arg is Order basket))
                {
                    return;
                }

                OrderedItems.Remove(basket);
                _basketRepository.Remove(basket);
                OnPropertyChanged(nameof(OrderedItems));
            });
        }

        public ObservableCollection<Order> OrderedItems { get; set; }
        public ICommand Remove { get; }
    }
}