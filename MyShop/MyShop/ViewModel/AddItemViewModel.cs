using CourseProject.Model;
using CourseProject.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace CourseProject.ViewModel
{
    public class AddItemViewModel : INotifyPropertyChanged
    {
        private EFItemsRepository _shopItemsRepository = new EFItemsRepository();

        string name;
        string category;
        string about;
        int quntity;
        string region;
        decimal cost;
        string info;
        private byte[] readedImage;
        string statusName = "Не заполнено название";
        string statusCategory = "Не заполнено категория";
        string statusCost = "Не заполнена цена";
        string statusAbout = "Не заполнено описание";

        List<string> tmpCategories = new List<string>();
        List<string> tmpRegions = new List<string>();

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length >= 5 && value.Length < 50)
                {
                    name = value;
                    statusName = "";
                }
                else
                    statusName = "Название слишком коротокое";

                OnPropertyChanged("Name");
            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    category = value;
                    statusCategory = "";
                }
                else
                    statusCategory = "Првоерьте категорию";

                OnPropertyChanged("Category");
            }
        }

        public int Quntity
        {
            get { return quntity; }
            set
            {
                quntity = value;


                OnPropertyChanged("Quntity");
            }
        }

        public string About
        {
            get { return about; }
            set
            {
                if (value.Length >= 10 && value.Length < 1000)
                {
                    about = value;
                    statusAbout = "";
                }
                else
                    statusAbout = "Описание слишком короткое";

                OnPropertyChanged("About");
            }
        }

        public string Region
        {
            get { return region; }
            set { region = value; }
        }

        public string Cost
        {
            get { return cost.ToString(); }
            set
            {
                if (Decimal.TryParse(value, out cost) && Decimal.Parse(value) >= 0)
                {
                    if (Decimal.Parse(value) > Decimal.MaxValue)
                        cost = Decimal.MaxValue;
                    else
                        cost = Decimal.Parse(value);

                    statusCost = "";
                }
                else
                {
                    statusCost = "Некорректно задана цена)";
                    cost = 0;
                }

                OnPropertyChanged("Cost");
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

        public List<string> Categories
        {
            get { return tmpCategories; }
        }

        public List<string> Regions
        {
            get { return tmpRegions; }
        }

        public AddItemViewModel()
        {
            tmpCategories = _shopItemsRepository.getCategories().Distinct().ToList();
        }

        bool IsCorrected()
        {
            if (!String.IsNullOrEmpty(statusName))
            {
                Info = statusName;
                return false;
            }

            if (!String.IsNullOrEmpty(statusCost))
            {
                Info = statusCost;
                return false;
            }

            if (!String.IsNullOrEmpty(statusCategory))
            {
                Info = statusCategory;
                return false;
            }

            if (!String.IsNullOrEmpty(statusAbout))
            {
                Info = statusAbout;
                return false;
            }

            return true;
        }

        public bool AddNewItem()
        {
            if (string.IsNullOrEmpty(about) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }

            var item = new Item()
            {
                About = about,
                Category = Category,
                Cost = cost,
                Name = Name,
                BitmapImage = readedImage,
                Quntity = quntity
            };
            _shopItemsRepository.add(item);
            return true;
        }

        public bool SelectImage()
        {
            var open = new OpenFileDialog { Filter = "JPG (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|Png (*.png)|*.png" };
            var result = open.ShowDialog();
            if (!(result == DialogResult.Yes || result == DialogResult.OK))
            {
                return false;
            }

            var fileName = open.FileName;
            if (!File.Exists(fileName))
            {
                return false;
            }

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var image = new byte[fs.Length];
                fs.Read(image, 0, image.Length);
                readedImage = image;
            }

            return true;
        }

        public void clear()
        {
            name = "";
            cost = 0;
            about = "";
            category = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}