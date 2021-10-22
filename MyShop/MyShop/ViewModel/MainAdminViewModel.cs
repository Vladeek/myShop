using CourseProject.View;
using CourseProject_WPF_.View;
using System.ComponentModel;

namespace CourseProject.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        int selectedIndex;
        object content;
        string userName;
        string firstSymbols;

        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                selectedIndex = value;
                SetPage(selectedIndex);
                OnPropertyChanged("SelectedIndex");
            }
        }

        public object Content
        {
            get => content;
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string FirstSymbols
        {
            get => firstSymbols;
            set
            {
                firstSymbols = UserViewModel.User.FirstName.Substring(0, 1) +
                               UserViewModel.User.SecondName.Substring(0, 1);
                OnPropertyChanged("FirstSymbols");
            }
        }

        public MainWindowViewModel()
        {
            Content = new AllAnnouncement();
        }

        public void SetPage(int index)
        {
            switch (index)
            {
                case 0:
                    Content = new AllAnnouncement();
                    break;
                case 1:
                    Content = new PersonAreaPage();
                    break;
                case 2:
                    {
                        if (UserViewModel.isAdmin())
                            Content = new AdminPage();
                        break;
                    }
                case 3:
                    {
                        Content = new AdminOrdersPage();
                        break;
                    }
                default:
                    Content = new AllAnnouncement();
                    break;
            }
        }

        public void OutFromMain()
        {
            UserViewModel.User = null;
            App.authWindow = new AuthWindow();
            App.authWindow.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}