using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using List3.ViewModels;
using Lista3.ViewModels;

namespace List3
{
    /// <summary>
    /// Interaction logic for ExtendRentWindow.xaml
    /// </summary>
    public partial class ExtendRentWindow : Window
    {
        public ExtendRentWindow()
        {
            InitializeComponent();
            this.DataContext = new ExtendRentViewModel();
        }
    }
}
