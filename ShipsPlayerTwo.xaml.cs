using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            CreateBoard(true);
            CreateBoard(false);
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
                        binding = new Binding($"PlayerTwo[{counter}]");
                        binding.ConverterParameter = "First";
                        btn.Click += Button_Click__Choose_Ships;
                        Grid.SetRow(btn, i);
                    }
                    else
                    {
                        binding = new Binding($"PlayerOne[{counter}]");
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
                    GridShipsTwo.Children.Add(btn);
                }
            }
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
