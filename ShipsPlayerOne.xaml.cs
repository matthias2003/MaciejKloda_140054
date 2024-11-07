using System.Windows;
using System.Windows.Controls;

namespace MaciejKloda_140054
{
    /// <summary>
    /// Logika interakcji dla klasy ShipsPlayerOne.xaml
    /// </summary>
    public partial class ShipsPlayerOne : Window
    {
        public ShipsPlayerOne()
        {
            InitializeComponent();
            int[] upperTab = new int[25];
            int[] lowerTab = new int[25];
            ShipsPlayerTwo secondWindow = new ShipsPlayerTwo();
            secondWindow.Show();
            GameShips ships = new GameShips(upperTab, lowerTab);
            this.DataContext = ships;
            secondWindow.DataContext = ships;
        }

        private void Button_Click__Choose_Ships(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
         
            if (((GameShips)this.DataContext).PlayerOne[Convert.ToInt32(btn.Tag.ToString())] == 0)
            {
                ((GameShips)this.DataContext).PlayerOne[Convert.ToInt32(btn.Tag.ToString())] += 1;
            } else if (((GameShips)this.DataContext).PlayerOne[Convert.ToInt32(btn.Tag.ToString())] == 1)
            {
                ((GameShips)this.DataContext).PlayerOne[Convert.ToInt32(btn.Tag.ToString())] -= 1;
            }
        }

        private void Button_Click__Shoot(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (((GameShips)this.DataContext).PlayerTwo[Convert.ToInt32(btn.Tag.ToString())] == 0 || ((GameShips)this.DataContext).PlayerTwo[Convert.ToInt32(btn.Tag.ToString())] == 1)
                ((GameShips)this.DataContext).PlayerTwo[Convert.ToInt32(btn.Tag.ToString())] += 2;
        }
    }
}
