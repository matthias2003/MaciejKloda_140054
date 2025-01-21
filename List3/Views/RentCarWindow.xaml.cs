using System;
using System.Windows;
using List3.Commands;
using List3.ViewModels;

namespace List3
{
    /// <summary>
    /// Logika interakcji dla klasy RentCarWindow.xaml
    /// </summary>
    public partial class RentCarWindow : Window
    {
        public RentCarWindow()
        {
            InitializeComponent();
            this.DataContext = new RentCarViewModel();

            
        }
    }
}
