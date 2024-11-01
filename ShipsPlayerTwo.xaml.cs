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

namespace MaciejKloda_140054
{
    /// <summary>
    /// Logika interakcji dla klasy ShipsPlayerTwo.xaml
    /// </summary>
    public partial class ShipsPlayerTwo : Window
    {
        public ShipsPlayerTwo()
        {
            InitializeComponent();
        }
        private void Button_Click__Choose_Ships(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (((GameShips)this.DataContext).PlayerTwo[Convert.ToInt32(btn.Tag.ToString())] == 0)
            {
                ((GameShips)this.DataContext).PlayerTwo[Convert.ToInt32(btn.Tag.ToString())] += 1;
            }
            else if (((GameShips)this.DataContext).PlayerTwo[Convert.ToInt32(btn.Tag.ToString())] == 1)
            {
                ((GameShips)this.DataContext).PlayerTwo[Convert.ToInt32(btn.Tag.ToString())] -= 1;
            }
        }

        private void Button_Click__Shoot(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (((GameShips)this.DataContext).PlayerOne[Convert.ToInt32(btn.Tag.ToString())] == 0 || ((GameShips)this.DataContext).PlayerOne[Convert.ToInt32(btn.Tag.ToString())] == 1)
                ((GameShips)this.DataContext).PlayerOne[Convert.ToInt32(btn.Tag.ToString())] += 2;
        }
    }
}
