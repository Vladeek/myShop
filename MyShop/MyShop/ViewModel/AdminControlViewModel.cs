using CourseProject.Model;
using CourseProject.Other;
using CourseProject.Repositories;
using CourseProject.View;
using CourseProject_WPF_.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CourseProject.ViewModel
{
    public class AdminControlViewModel : INotifyPropertyChanged
    {
        private AdminPageState _state;
        EfUserRepository userRepository = new EfUserRepository();
        EFItemsRepository _shopItemsRepository = new EFItemsRepository();

        ObservableCollection<User> tmpUsers = new ObservableCollection<User>();
        ObservableCollection<Item> tmpAnnouncements = new ObservableCollection<Item>();
        ObservableCollection<object> tmp = new ObservableCollection<object>();

        object selectedItem;
        string message;

        public AdminPageState State
        {
            get => _state;
            set
            {
                if (_state == value)
                {
                    return;
                }

                _state = value;
                OnPropertyChanged(nameof(State));
            }
        }

        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (value != null)
                    selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public ObservableCollection<User> Users
        {
            get
            {
                selectedItem = null;
                return tmpUsers;
            }
        }

        public ObservableCollection<Item> Items
        {
            get
            {
                selectedItem = null;
                return tmpAnnouncements;
            }
        }


        public AdminControlViewModel(ViewWindow viewWindow)
        {
            this.viewWindow = viewWindow;
            update();
        }

        public void update()
        {
            tmpUsers.Clear();
            tmpAnnouncements.Clear();

            foreach (User user in userRepository.GetAll())
            {
                if (user.Id != UserViewModel.User.Id)
                    tmpUsers.Add(user);
            }

            foreach (Item announcement in _shopItemsRepository.getAll())
                tmpAnnouncements.Add(announcement);
        }

        public void accept()
        {
            if (State == AdminPageState.Items)
            {
                var addButtonDialogWindow = new AddWindow();
                addButtonDialogWindow.ShowDialog();
            }
            else
                switch (SelectedItem)
                {
                    case User _ when UserViewModel.isAdmin():
                        {
                            if ((SelectedItem as User)?.Privilege?.Equals("admin") == true)
                                userRepository.ChangePrivilege((SelectedItem as User), "user");
                            else if (((User)SelectedItem).Privilege?.Equals("user") == true)
                                userRepository.ChangePrivilege((SelectedItem as User), "admin");

                            var alertWindow =
                                new AlertWindow(
                                    $"Пользователь {(SelectedItem as User).FirstName} {(SelectedItem as User).SecondName} теперь {(SelectedItem as User).Privilege}");
                            alertWindow.ShowDialog();
                            break;
                        }
                    case User _:
                        {
                            var alertWindow = new AlertWindow("У вас недостаточно прав для совершения данного действия");
                            alertWindow.ShowDialog();
                            break;
                        }

                    default:
                        {
                            AlertWindow alertWindow = new AlertWindow($"Выберите объект");
                            alertWindow.ShowDialog();
                            break;
                        }
                }

            update();
        }

        void DeleteUser(User user)
        {
            userRepository.Delete(user);
        }

        public void Delete()
        {
            if (SelectedItem is User)
            {
                if (UserViewModel.isAdmin())
                {
                    DialogWindow dialogWindow = new DialogWindow();
                    dialogWindow.DataContext = this;
                    Message = $"Уверены, что хотите удалить пользователя {(SelectedItem as User).FirstName} {(SelectedItem as User).SecondName}?";
                    dialogWindow.ShowDialog();
                    if (dialogWindow.DialogResult == true)
                        DeleteUser(SelectedItem as User);
                }
                else
                {
                    AlertWindow alertWindow =
                        new AlertWindow("У вас недостаточно прав для совершения данного действия");
                    alertWindow.ShowDialog();
                }
            }

            else if (SelectedItem is Item)
            {
                DialogWindow dialogWindow = new DialogWindow();
                dialogWindow.DataContext = this;
                Message = $"Уверены, что хотите удалить товар \"{(SelectedItem as Item).Name}\" ?";
                dialogWindow.ShowDialog();
                if (dialogWindow.DialogResult == true)
                    _shopItemsRepository.delete(SelectedItem as Item);
            }
            else
            {
                AlertWindow alertWindow = new AlertWindow($"Выберите объект");
                alertWindow.ShowDialog();
            }

            update();
        }

        private ViewWindow viewWindow;
        private ChangeWindow ChangeWindow;

        public void ShowInfo()
        {
            if (SelectedItem == null)
            {
                return;
            }

            if (State == AdminPageState.Items)
            {
                viewWindow.DataContext = SelectedItem;
                viewWindow.Show();
                return;
            }

        }

        public void Change()
        {
            if (SelectedItem == null)
            {
                return;
            }

            if (State == AdminPageState.Items)
            {
                ChangeWindow = new ChangeWindow(SelectedItem as Item);
                ChangeWindow.DataContext = SelectedItem;
                ChangeWindow.Show();
                return;
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