using CourseProject.Model;
using CourseProject_WPF_.Repositories;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace CourseProject.ViewModel
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        EfUserRepository userRepository = new EfUserRepository();

        string firstName;
        string secondName;
        string mail;
        string password1;
        string password2;
        string info;


        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string SecondName
        {
            get { return secondName; }
            set
            {
                secondName = value;
                OnPropertyChanged("SecondName");
            }
        }

        public string Mail
        {
            get { return mail; }
            set
            {
                mail = value;
                OnPropertyChanged("Mail");
            }
        }

        public string Password1
        {
            get { return password1; }
            set
            {
                password1 = value;
                OnPropertyChanged("Password1");
            }
        }

        public string Password2
        {
            get { return password2; }
            set
            {
                password2 = value;
                OnPropertyChanged("Password2");
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

        public bool Registration(string password1, string password2)
        {
            Password1 = password1;
            Password2 = password2;

            string firstNameRegex = @"^[А-Я]{1}[а-яё]{1,28}$|^[A-Z]{1}[a-z]{1,28}$";
            string secondNameRegex = @"^[А-Я]{1}[а-яё]{1,28}$|^[A-Z]{1}[a-z]{1,28}$";
            string mailRegex = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            if (!String.IsNullOrEmpty(FirstName) && !String.IsNullOrEmpty(SecondName) && !String.IsNullOrEmpty(Mail) && !String.IsNullOrEmpty(Password1) && !String.IsNullOrEmpty(Password2))
            {
                if (FirstName.Length > 1 && Regex.IsMatch(FirstName, firstNameRegex))
                {
                    if (SecondName.Length > 2 && Regex.IsMatch(SecondName, secondNameRegex))
                    {
                        if (Regex.IsMatch(Mail, mailRegex, RegexOptions.IgnoreCase))
                        {
                            if (Password1.Length > 0 && Password2.Length > 0)
                            {

                                if (Password1.Equals(Password2))
                                {
                                    var tmp = userRepository.GetByMail(Mail);
                                    if (tmp == null)
                                    {
                                        userRepository.Add(new User
                                        {
                                            FirstName = FirstName,
                                            SecondName = SecondName,
                                            Mail = Mail,
                                            Password = Password1,
                                            Privilege = "user"
                                        });
                                        Info = "Зареган!";
                                        return true;
                                    }

                                    Info = "Пользователь с таким Mail уже есть";
                                    return false;
                                }

                                Info = "Пароли должны совпадать";
                                return false;
                            }
                        }

                        Info = "Email введен некорректно";
                        return false;
                    }

                    Info = "Фамилия введена некорректно";
                    return false;
                }

                Info = "Имя введено некорректно";
                return false;
            }

            Info = "Вы не заполнили все поля!";
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