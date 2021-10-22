using CourseProject.View;
using CourseProject_WPF_.View;
using MyShop.View;
using System.ComponentModel;

namespace CourseProject.ViewModel
{
    public class MainWindow2ViewModel : INotifyPropertyChanged
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
                setPage(selectedIndex);
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
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string FirstSymbols
        {
            get { return firstSymbols; }
            set
            {
                firstSymbols = UserViewModel.User.FirstName.Substring(0, 1) +
                               UserViewModel.User.SecondName.Substring(0, 1);
                OnPropertyChanged("FirstSymbols");
            }
        }

        public MainWindow2ViewModel()
        {
            Content = new AllAnnouncement();
            UserName = UserViewModel.User?.FirstName + " " + UserViewModel.User?.SecondName;
            SelectedIndex = 0;
        }

        public void setPage(int index)
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
                        Content = new UserCartPage(UserViewModel.OrderedItems);
                        break;
                    }
                case 3:
                    {
                        Content = new UserHistoryPage();
                        break;
                    }
                default:
                    Content = new AllAnnouncement();
                    break;
            }
        }

        public void Update()
        {
            FirstSymbols = UserViewModel.User.FirstName.Substring(0, 1) + UserViewModel.User.SecondName.Substring(0, 1);
            UserName = UserViewModel.User.ToString();
        }

        public static void OutFromMain()
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