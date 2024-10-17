using System.Windows;
using System.Windows.Controls;

namespace MaciejKloda_140054
{
    public partial class Calc : Window
    {
        public Calc()
        {
            InitializeComponent();
        }

        private void Button_Number_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            String btnContent = btn.Content.ToString();
            if(btnContent == "." && !TextBox_Result.Text.Contains("."))
            {
                TextBox_Result.Text += btnContent;
            } else if (btnContent != ".")
            {
                TextBox_Result.Text += btnContent;
            }
        }

        private void Button_Sign_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            String btnContent = btn.Content.ToString();
            String sign = "";
            String value = "";

            if (btnContent == "C")
            {
                TextBox_Result.Text = "";
            } else if ( btnContent != "C" && btnContent != "=")
            {
                TextBox_Result.Text = "";
                sign = btnContent;
            } else if (btnContent == "=")
            {
                TextBox_Result.Text = value + " " + sign;
            }

        }
    }

}