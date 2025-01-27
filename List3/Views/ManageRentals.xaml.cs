using System.Windows;
using List3.ViewModels;

namespace List3
{
    public partial class ManageRentals : Window
    {
        public ManageRentals()
        {
            InitializeComponent();
            this.DataContext = new ManageRentalsViewModel();
        }
    }
}
