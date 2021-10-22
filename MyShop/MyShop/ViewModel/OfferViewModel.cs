using CourseProject;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace CourseProject_WPF_.ViewModel
{
    public class OfferViewModel : ViewModelBase
    {
        private readonly Action<OfferViewModel> _orderComplete;

        public OfferViewModel(Action<OfferViewModel> orderComplete)
        {
            _orderComplete = orderComplete;
            OrderCommand = new RelayCommand(OrderCommandExecute, OrderCommandCanExecute);
        }
        string info;
        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }
        public string Name { get; set; } = UserViewModel.User.FirstName ?? string.Empty;
        public string SecondName { get; set; } = UserViewModel.User.SecondName ?? string.Empty;
        public string Email { get; set; } = UserViewModel.User.Mail ?? string.Empty;
        public string Phone { get; set; } = UserViewModel.User.TelNumber ?? string.Empty;
        public string Address { get; set; } = string.Empty;

        public ICommand OrderCommand { get; }

        private void OrderCommandExecute(object obj)
        {
            _orderComplete?.Invoke(this);
            //MessageBox.Show("Мы с вами свяжемся в ближайшее время!", "Заказ сделан", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private bool OrderCommandCanExecute(object arg)
        {
            string NameRegex = @"^[А-Я]{1}[а-яё]{1,28}$|^[A-Z]{1}[a-z]{1,28}$";
            string SecondNameRegex = @"^[А-Я]{1}[а-яё]{1,28}$|^[A-Z]{1}[a-z]{1,28}$";
            string tel = @"^(\+375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$";

            if (Name.Length > 0 && Name.Length < 20 && Regex.IsMatch(Name, NameRegex))
            {
                if (SecondName.Length > 0 && SecondName.Length < 20 && Regex.IsMatch(SecondName, SecondNameRegex))
                {
                    if (Address.Length > 0 && Address.Length < 50)
                    {
                        if (Regex.IsMatch(Phone, tel))
                        {
                            if (Regex.IsMatch(Phone, tel))
                            {
                                Info = "Всё введено корректно";
                                return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(SecondName) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Phone) && !string.IsNullOrEmpty(Address);
                            }
                            Info = "Адрес слишком длинный";
                            return false;
                        }
                        Info = "Телефон введён некорректно";
                        return false;
                    }
                    Info = "Адрес введён некорректно";
                    return false;
                }
                Info = "Фамилия введена некорректно";
                return false;
            }
            Info = "Имя введено некорректно";
            return false;
        }
    }
}
