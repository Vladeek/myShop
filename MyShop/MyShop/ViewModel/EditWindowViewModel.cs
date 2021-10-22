using CourseProject.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CourseProject.ViewModel
{
    public class EditWindowViewModel : INotifyPropertyChanged
    {
        EFItemsRepository _shopItemsRepository = new EFItemsRepository();

        string name;
        string category;
        string region;
        string about;
        decimal cost;
        string info;

        string statusName;
        string statusCategory;
        string statusCost;
        string statusAbout;

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

        public string Region
        {
            get { return region; }
            set { region = value; }
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


        bool IsCorrected()
        {
            if (!String.IsNullOrEmpty(statusName))
            {
                Info = statusName;
                return false;
            }

            if (!string.IsNullOrEmpty(statusCost))
            {
                Info = statusCost;
                return false;
            }

            if (!string.IsNullOrEmpty(statusCategory))
            {
                Info = statusCategory;
                return false;
            }

            if (!string.IsNullOrEmpty(statusAbout))
            {
                Info = statusAbout;
                return false;
            }

            return true;
        }

        public EditWindowViewModel()
        {
            tmpCategories = _shopItemsRepository.getCategories().Distinct().ToList();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}