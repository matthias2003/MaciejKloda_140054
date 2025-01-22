using System.Windows;
using List3.ViewModels;

namespace List3
{
    public partial class RentCarWindow : Window
    {
        public RentCarWindow()
        {
            InitializeComponent();
            this.DataContext = new RentCarViewModel();
        }
    }
}
