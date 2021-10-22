using CourseProject;
using CourseProject.Model;
using CourseProject.Repositories;
using CourseProject.View;
using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CourseProject_WPF_.ViewModel
{
    public class UserOrderViewModel : ViewModelBase
    {
        private readonly EFItemsRepository _shopItemsRepository = new EFItemsRepository();
        private readonly EFOrderRepository _basketRepository = new EFOrderRepository();
        ViewWindow viewWindow;

        string sum;
        
        public string Sum
        {
            get => sum;
            set
            {
                if (!String.IsNullOrEmpty(value))
                    sum = value;
                OnPropertyChanged("Sum");
            }
        }

        public decimal? getSum()
        {
            decimal? sum = 0;
            foreach (var item in OrderedItems)
            {
                sum += item.Cost * item.Count;
            }
            return sum;
        }

        public UserOrderViewModel(IEnumerable<Item> orderedItems)
        {
            OrderedItems = orderedItems.ToList();
            OrderCommand = new RelayCommand(OrderCommandExecute, OrderCommandCanExecute);
            DeleteFromCartCommand = new RelayCommand(DeleteFromCartCommandExecute);
            viewWindow = new ViewWindow();
            viewWindow.Visibility = System.Windows.Visibility.Hidden;
            Sum = getSum().ToString();
        }

        private void DeleteFromCartCommandExecute(object obj)
        {
            if (!(obj is Item shopItem))
            {
                return;
            }

            var foundedItem = OrderedItems.FirstOrDefault(x => x.Id == shopItem.Id);
            if (foundedItem == null)
            {
                return;
            }

            UserViewModel.OrderedItems.Remove(foundedItem);
            OrderedItems = UserViewModel.OrderedItems.ToList();
            OnPropertyChanged(nameof(OrderedItems));
            Sum = getSum().ToString();
        }

        private OfferWindow _orderWindow;

        private void OrderCommandExecute(object obj)
        {
            _orderWindow = new OfferWindow(OnOrderComplete);
            _orderWindow?.Show();
        }

        private void OnOrderComplete(ViewModel.OfferViewModel complete)
        {
            var basket = new Order
            {
                UserName = _orderWindow.OfferViewModel.Name,
                Address = _orderWindow.OfferViewModel.Address,
                Email = _orderWindow.OfferViewModel.Email,
                TelNumber = _orderWindow.OfferViewModel.Phone,
                Items = UserViewModel.OrderedItems,
                Sum = getSum().ToString()
        };
            foreach (var item in UserViewModel.OrderedItems)
            {
                if (item.Count > item.Quntity)
                {
                    MessageBox.Show("Не хватает товаров на складе");
                    return;
                }
                if (item.Count < 1)
                {
                    MessageBox.Show("Укажите кол-во товара");
                    return;
                }
            }
            MessageBox.Show("Мы свяжемся с вами");
            foreach (var item in UserViewModel.OrderedItems)
            {
                var itemdb = _shopItemsRepository.getByName(item.Name);
                int coun = itemdb.Quntity - item.Count;
                _shopItemsRepository.update(itemdb.Name, coun);
            }
            _basketRepository.Add(basket);

            UserViewModel.OrderedItems.Clear();
            OrderedItems = null;
            _orderWindow.Close();
            OnPropertyChanged(nameof(OrderedItems));
            Sum = "0";
        }

        public void ShowInfo()
        {
            if (SelectedItem == null)
            {
                return;
            }

            viewWindow.DataContext = SelectedItem;
            if (viewWindow.Visibility == System.Windows.Visibility.Hidden && SelectedItem != null)
                viewWindow.Show();
            Sum = getSum().ToString();
        }

        private bool OrderCommandCanExecute(object arg)
        {
            return UserViewModel.OrderedItems?.Any() == true;
        }

        public List<Item> OrderedItems { get; set; }
        public ICommand OrderCommand { get; }

        public ICommand DeleteFromCartCommand { get; }
        public Item SelectedItem { get; set; }
    }
}