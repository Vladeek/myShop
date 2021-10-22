using CourseProject.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace CourseProject
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private static User user;
#pragma warning disable CS0169 // Поле "UserViewModel.users" никогда не используется.
        private static User users;
#pragma warning restore CS0169 // Поле "UserViewModel.users" никогда не используется.
        string name;

        public static IList<Item> OrderedItems { get; } = new List<Item>();

        public static User User
        {
            get { return user; }
            set
            {
                user = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public static bool isAdmin()
        {
            if (User.Privilege.Equals("admin"))
                return true;
            return false;
        }

        public override string ToString()
        {
            return User.FirstName + " " + User.SecondName;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
