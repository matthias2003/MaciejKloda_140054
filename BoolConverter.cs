using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Media;

namespace MaciejKloda_140054
{
    public class BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool useFirstConverter = parameter?.ToString() == "First";

            Debug.WriteLine(value);
            switch (value)
            {
                case 3:
                    return new SolidColorBrush(Colors.Red);
                case 2:
                    return new SolidColorBrush(Colors.Yellow);
                case 1:
                    return new SolidColorBrush(useFirstConverter ? Colors.Black : Colors.Transparent);
                case 0:
                    return new SolidColorBrush(Colors.Transparent);
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is SolidColorBrush brush)
            {
               
            }
            return 0;
        }
    }
}
