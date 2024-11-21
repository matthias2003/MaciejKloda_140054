using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            GameShips ships = new GameShips(upperTab, lowerTab);
            this.DataContext = ships;

            CreateBoard(true);
            CreateBoard(false);

            ShipsPlayerTwo secondWindow = new ShipsPlayerTwo();
            secondWindow.Show();
            secondWindow.DataContext = ships;
        }

        public void CreateBoard(bool parameter)
        {
            var boolConverter = new BoolConverter();
            int counter = 0;
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button btn = new Button();
                    Binding binding;

                    if (parameter)
                    {
                        binding = new Binding($"PlayerOne[{counter}]");
                        binding.ConverterParameter = "First";
                        btn.Click += Button_Click__Choose_Ships;
                        Grid.SetRow(btn, i);
                    } else
                    {
                        binding = new Binding($"PlayerTwo[{counter}]");
                        btn.Click += Button_Click__Shoot;
                        Grid.SetRow(btn, i + 6);
                    }

                    binding.Mode = BindingMode.OneWay;
                    binding.Converter = boolConverter;
                    btn.Tag = counter;
                    counter++;
                    btn.Content = $"{i},{j + 1}";
                    BindingOperations.SetBinding(btn, Button.BackgroundProperty, binding);
                    Grid.SetColumn(btn, j);
                    GridShipsOne.Children.Add(btn);
                }
            }
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
