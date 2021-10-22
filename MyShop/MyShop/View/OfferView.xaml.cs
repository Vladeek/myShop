using CourseProject_WPF_.ViewModel;
using System;
using System.Windows;

namespace CourseProject_WPF_.View
{
    public partial class OfferWindow : Window
    {
        public OfferViewModel OfferViewModel { get; }

        public OfferWindow(Action<OfferViewModel> orderCompleteAction)
        {
            InitializeComponent();
            OfferViewModel = new OfferViewModel(orderCompleteAction);
            DataContext = OfferViewModel;
        }
    }
}