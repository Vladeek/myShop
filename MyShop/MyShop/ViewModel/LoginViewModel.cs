using CourseProject;
using CourseProject.Other;
using CourseProject.View;
using CourseProject_WPF_.Repositories;
using System;
using System.ComponentModel;

namespace CourseProject_WPF_.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        EfUserRepository eFUserRepository = new EfUserRepository();
        string password;
        string login;
        string info;

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }

        public bool CompareDataOfUser(string passwordParam)
        {
            if (!String.IsNullOrEmpty(Login) && !String.IsNullOrEmpty(passwordParam))
            {
                var tmp = eFUserRepository.GetByMail(Login);
                if (tmp != null)
                {
                    if (HashHelper.GetMd5Hash(passwordParam) == tmp.Password)
                    {
                        if (tmp.IsAdmin())
                        {
                            UserViewModel.User = tmp;
                            App.mainWindow = new MainWindow();
                            App.mainWindow.Show();
                            return true;
                        }

                        UserViewModel.User = tmp;
                        App.mainWindow2 = new MainWindow2();
                        App.mainWindow2.Show();
                        return true;
                    }

                    Info = "Проверьте введённые данные";
                    return false;
                }

                Info = "Проверьте введённые данные";
                return false;
            }

            Info = "Заполните все поля!";
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}