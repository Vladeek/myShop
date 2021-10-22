using CourseProject.Model;
using CourseProject.Repositories;
using CourseProject.View;
using CourseProject_WPF_.Repositories;
using CourseProject_WPF_.View;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;

namespace CourseProject.ViewModel
{
    public class AccountViewModel : INotifyPropertyChanged
    {
        EfUserRepository userRepository = new EfUserRepository();
        EFItemsRepository _shopItemsRepository = new EFItemsRepository();

        string firstName;
        string secondName;
        string mail;
        string telNumber;
        string about;
        string info;

        BitmapImage bitmap = new BitmapImage();
        string bitmapImage = "";
        string message;

        Image i;

        public Image Image
        {
            get { return i; }
            set
            {
                i = value;
                OnPropertyChanged("Image");
            }
        }

        public BitmapImage BitmapImage
        {
            get { return bitmap; }
            set
            {
                bitmap = value;
                OnPropertyChanged("BitmapImage");
            }
        }

        public AccountViewModel()
        {
            firstName = UserViewModel.User.FirstName;
            secondName = UserViewModel.User.SecondName;
            mail = UserViewModel.User.Mail;
            telNumber = UserViewModel.User.TelNumber;
            about = UserViewModel.User.About;
            BitmapImage = LoadPhoto(UserViewModel.User.Id);
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (!String.IsNullOrEmpty(value))
                    firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string SecondName
        {
            get => secondName;
            set
            {
                if (!String.IsNullOrEmpty(value))
                    secondName = value;
                OnPropertyChanged("SecondName");
            }
        }

        public string Mail
        {
            get => mail;
            set
            {
                if (!String.IsNullOrEmpty(value))
                    mail = value;
                OnPropertyChanged("Main");
            }
        }

        public string TelNumber
        {
            get => telNumber;
            set
            {
                telNumber = value;
                OnPropertyChanged("TelNumber");
            }
        }

        public string About
        {
            get { return about; }
            set
            {
                about = value;
                OnPropertyChanged("About");
            }
        }

        public string BitImage
        {
            get { return bitmapImage; }
            set
            {
                bitmapImage = value;
                OnPropertyChanged("BitImage");
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

        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }

        public BitmapImage LoadPhoto(int seller)
        {
            var bitmapImage = new BitmapImage();

            if (userRepository.GetById(seller).Image == null)
            {
                return bitmapImage;
            }

            using (var ms = new MemoryStream(userRepository.GetById(seller).Image))
            {
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();
            }

            return bitmapImage;
        }

        public void LoadImageFromFS()
        {
            var open = new OpenFileDialog { Filter = "JPG (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|Png (*.png)|*.png" };
            if (open.ShowDialog() != true)
            {
                return;
            }

            var fileName = open.FileName;
            if (!File.Exists(fileName))
            {
                return;
            }

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var image = new byte[fs.Length];
                fs.Read(image, 0, image.Length);
                userRepository.Update(UserViewModel.User, new User
                {
                    FirstName = UserViewModel.User.FirstName,
                    SecondName = UserViewModel.User.SecondName,
                    Mail = UserViewModel.User.Mail,
                    TelNumber = UserViewModel.User.TelNumber,
                    About = UserViewModel.User.About,
                    Image = image
                });
                BitmapImage = LoadPhoto(UserViewModel.User.Id);
            }
        }

        public bool ChangeDataOfUser()
        {
            string firstNameRegex = @"^[А-Я]{1}[а-яё]{1,28}$|^[A-Z]{1}[a-z]{1,28}$";
            string secondNameRegex = @"^[А-Я]{1}[а-яё]{1,28}$|^[A-Z]{1}[a-z]{1,28}$";
            string tel = @"^(\+375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$";
            string mailRegex = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

            if (!String.IsNullOrEmpty(FirstName) && !String.IsNullOrEmpty(SecondName) && !String.IsNullOrEmpty(TelNumber) && !String.IsNullOrEmpty(About))
            {
                if (FirstName.Length > 1 && Regex.IsMatch(FirstName, firstNameRegex))
                {
                    if (SecondName.Length > 2 && Regex.IsMatch(SecondName, secondNameRegex))
                    {
                        if (Regex.IsMatch(TelNumber, tel))
                        {
                            if (Regex.IsMatch(Mail, mailRegex))
                            {
                                var tmp = new User
                                {
                                    FirstName = FirstName,
                                    SecondName = SecondName,
                                    Mail = UserViewModel.User.Mail,
                                    TelNumber = TelNumber,
                                    About = About,
                                    Image = UserViewModel.User.Image,
                                    Privilege = UserViewModel.User.Privilege
                                };
                                if (tmp != null)
                                {
                                    userRepository.Update(UserViewModel.User, tmp);
                                    UserViewModel.User = userRepository.GetByMail(Mail);
                                    Info = "Изменения успешно сохранены!";
                                    return true;
                                }
                            }
                            Info = "Mail введен некорректно";
                            return false;
                        }
                        Info = "Телефон введен некорректно";
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

        public void DeleteUser()
        {
            var dialogWindow = new DialogWindow { DataContext = this };
            Message =
                $"Уверены, что хотите удалить пользователя {UserViewModel.User.FirstName} {UserViewModel.User.FirstName}?";
            dialogWindow.ShowDialog();
            if (dialogWindow.DialogResult != true)
            {
                return;
            }
            App.mainWindow?.Close();
            App.mainWindow2?.Close();
            userRepository.Delete(UserViewModel.User);
            App.authWindow = new AuthWindow();
            App.authWindow.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}