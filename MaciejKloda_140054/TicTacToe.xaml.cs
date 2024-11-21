using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MaciejKloda_140054
{
    public partial class TicTacToe : Window
    {
        Game game = new Game();
        private string _player = "X";

        public TicTacToe()
        {
            InitializeComponent();
            TicTacToeGrid.DataContext = game;
        }
         
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            game.tab[Convert.ToInt16(btn.Tag)] = _player;
            _player = (_player == "X") ? "O" : "X";
            game.CheckWinner();
        }
    }

    class StringToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string && (string)value == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Boolean && (Boolean)value)
            {
                return "";
            }
            else
            {
                return "";
            }
        }
    }
}
