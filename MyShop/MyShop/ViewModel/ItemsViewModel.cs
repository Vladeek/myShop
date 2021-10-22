using CourseProject.Model;
using CourseProject.Repositories;
using CourseProject.View;
using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CourseProject.ViewModel
{
    public class ItemsViewModel : INotifyPropertyChanged
    {
        private readonly EfUserRepository _userRepository = new EfUserRepository();
        private readonly EFItemsRepository _shopItemsRepository = new EFItemsRepository();


        ObservableCollection<Item> tmpAnnouncements = new ObservableCollection<Item>();
        List<string> tmpCategories = new List<string>();
        List<string> tmpSellers = new List<string>();
        List<string> tmpRegions = new List<string>();

        Item selectedItem;

        private string _seller = "";
        private string _category = "";
        private string _info = "";
        private string _searchText = "";
        private decimal _minCost;
        private decimal _maxCost;
        decimal MAX_COST;
        private string _count;
        string sellerInfo;
        string regionInfo;
        string region;
        int selectedIndex;

        bool flag = false;

        public ObservableCollection<Item> Announcements
        {
            get { return tmpAnnouncements; }
            set { tmpAnnouncements = value; }
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                if (value != null)
                    Count = (Announcements.IndexOf(SelectedItem) + 1).ToString();

                OnPropertyChanged("SelectedItem");
            }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (value >= 0)
                    selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }

        public List<string> Categories
        {
            get { return tmpCategories; }
        }

        public List<string> Sellers
        {
            get { return tmpSellers; }
        }

        public List<string> Regions
        {
            get { return tmpRegions; }
        }

        public string Seller
        {
            get { return _seller; }
            set
            {
                _seller = value;
                OnPropertyChanged("Seller");
            }
        }

        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged("Category");
            }
        }

        public string Region
        {
            get { return region; }
            set
            {
                region = value;
                OnPropertyChanged("Region");
            }
        }

        public string Info
        {
            get { return _info; }
            set
            {
                _info = $"Найдено {Announcements.Count} товара";
                OnPropertyChanged("Info");
            }
        }

        public string MinCost
        {
            get { return _minCost.ToString(); }
            set
            {
                if (Decimal.TryParse(value.ToString(), out _minCost) && Decimal.Parse(value) >= 0)
                    _minCost = Decimal.Parse(value);
                else
                    _minCost = 0;
                OnPropertyChanged("MinCost");
            }
        }

        public string MaxCost
        {
            get { return _maxCost.ToString(); }
            set
            {
                if (Decimal.TryParse(value.ToString(), out _maxCost) && Decimal.Parse(value) >= 0)
                    _maxCost = Decimal.Parse(value);
                else
                    _maxCost = MAX_COST;
                OnPropertyChanged("MaxCost");
            }
        }

        public string Count
        {
            get { return $"{_count} -е  из {Announcements.Count} объявлений"; }
            set
            {
                _count = value;
                OnPropertyChanged("Count");
            }
        }

        public string SellerInfo
        {
            get { return sellerInfo; }
            set
            {
                sellerInfo = value;
                OnPropertyChanged("SellerInfo");
            }
        }

        public string RegionInfo
        {
            get { return regionInfo; }
            set
            {
                regionInfo = value;
                OnPropertyChanged("RegionInfo");
            }
        }

        ViewWindow viewWindow;

        public ICommand AddInCart { get; }

        public ItemsViewModel()
        {
            IsNotAdmin = !UserViewModel.isAdmin();
            AddInCart = new RelayCommand(AddInCartExecute, AddInCartCanExecute);
            var announcements = GetAnnouncements().ToList();
            Announcements.Clear();
            foreach (var a in announcements)
            {
                Announcements.Add(a);
            }


            tmpCategories = _shopItemsRepository.getCategories().Distinct().ToList();
            tmpSellers = _userRepository.GetAllNames().Distinct().ToList();
            SelectedIndex = 0;
            Info = $"Найдено {Announcements.Count}";
            try
            {
                MAX_COST = _shopItemsRepository.MaxCost();
            }
            catch
            {
                MAX_COST = 0;
            }

            MaxCost = MAX_COST.ToString();

            viewWindow = new ViewWindow();
            viewWindow.Visibility = System.Windows.Visibility.Hidden;
        }

        private bool AddInCartCanExecute(object arg)
        {
            if (!(arg is Item shopItem))
            {
                return false;
            }

            return UserViewModel.OrderedItems.FirstOrDefault(x => x.Id == shopItem.Id) == null;
        }

        private void AddInCartExecute(object obj)
        {
            if (!(obj is Item shopItem))
            {
                return;
            }


            UserViewModel.OrderedItems.Add(shopItem);
        }

        public BitmapImage LoadPhoto(int seller)
        {
            var bitmapImage = new BitmapImage();

            if (_userRepository.GetById(seller).Image == null)
            {
                return bitmapImage;
            }

            using (var ms = new MemoryStream(_userRepository.GetById(seller).Image))
            {
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();
            }

            return bitmapImage;
        }

        private bool _isNotAdmin;
        public bool IsNotAdmin
        {
            get { return _isNotAdmin; }
            set
            {
                _isNotAdmin = value;
                OnPropertyChanged("IsNotAdmin");
            }
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
        }

        public void search()
        {
            selectedItem = null;
            Announcements.Clear();
            var regex = new Regex(@"(\w*)(?i)" + SearchText + @"(\w*)");
            int regionId = SelectedIndex;
            var tmp1 = new HashSet<Item>();
            var tmp2 = new HashSet<Item>();

            if (SelectedIndex != 0)
            {}
            else
            {
                foreach (var announcement in _shopItemsRepository.getAll())
                    tmp1.Add(announcement);
            }

            if (!string.IsNullOrEmpty(Category))
            {
                foreach (var announcement in tmp1.Where(x => x?.Category?.Equals(Category) == true))
                    tmp2.Add(announcement);
                tmp1.Clear();
            }
            else
            {
                foreach (var announcement in tmp1)
                    tmp2.Add(announcement);
                tmp1.Clear();
            }

            if (!string.IsNullOrEmpty(Seller))
            {
            }
            else
            {
                foreach (var announcement in tmp2)
                    tmp1.Add(announcement);
                tmp2.Clear();
            }

            if (!string.IsNullOrEmpty(SearchText))
            {
                foreach (var announcement in tmp1?.Where(announcement =>
                    regex.IsMatch(announcement.About ?? string.Empty) || regex.IsMatch(announcement.Name ?? string.Empty)))
                {
                    if (_maxCost == 0)
                    {
                        if (announcement.Cost <= _maxCost && announcement.Cost >= MAX_COST)
                            tmp2.Add(announcement);
                    }
                    else
                    {
                        if (announcement.Cost <= _maxCost && announcement.Cost >= _minCost)
                            tmp2.Add(announcement);
                    }
                }
            }
            else
            {
                foreach (var announcement in tmp1)
                {
                    if (_maxCost == 0)
                    {
                        if (announcement.Cost <= _maxCost && announcement.Cost >= MAX_COST)
                            tmp2.Add(announcement);
                    }
                    else
                    {
                        if (announcement.Cost <= _maxCost && announcement.Cost >= _minCost)
                            tmp2.Add(announcement);
                    }
                }
            }

            foreach (var announcement in tmp2)
                Announcements.Add(announcement);

            tmp1.Clear();
            tmp2.Clear();

            Info = $"Найдено {Announcements.Count}";
        }

        public IEnumerable<Item> GetAnnouncements()
        {
            return _shopItemsRepository.getAll();
        }

        public void DeleteAnnouncement(Item tmp)
        {
            _shopItemsRepository.delete(tmp);
        }



        public void AddAnnouncement(Item shopItem)
        {
            _shopItemsRepository.add(shopItem);
        }

        public void NextItem()
        {
            if (Announcements.IndexOf(SelectedItem) < Announcements.Count - 1)
                SelectedItem = Announcements.ElementAt(Announcements.IndexOf(SelectedItem) + 1);
        }

        public void PreviousItem()
        {
            if (Announcements.IndexOf(SelectedItem) > 0)
                SelectedItem = Announcements.ElementAt(Announcements.IndexOf(SelectedItem) - 1);
        }

        public void Sort()
        {
            if (flag)
            {
                Announcements.Clear();
                foreach (var ann in GetAnnouncements().OrderBy(x => x.Cost))
                    Announcements.Add(ann);
                flag = false;
            }
            else
            {
                Announcements.Clear();
                foreach (var ann in GetAnnouncements().OrderByDescending(x => x.Cost))
                    Announcements.Add(ann);
                flag = true;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}