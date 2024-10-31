using System.Windows;
using System.Windows.Controls;

namespace MaciejKloda_140054
{
    public partial class Calc : Window
    {
        private double currentValue = 0; 
        private double lastValue = 0;
        private string currentOperation = "";

        public Calc()
        {
            InitializeComponent();
        }

        private void Button_Number_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            String btnContent = btn.Content.ToString();

            if (TextBox_Result.Text == "0" && btnContent != ".")
            {
                TextBox_Result.Text = btnContent;
            } else
            {
                if (btnContent == "." && !TextBox_Result.Text.Contains("."))
                {
                    TextBox_Result.Text += btnContent;
                }
                else if (btnContent != ".")
                {
                    TextBox_Result.Text += btnContent;
                }
            }
        }

        private void Button_Sign_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            String btnContent = btn.Content.ToString();

            if (btnContent == "=")
            {
                Double.TryParse(TextBox_Result.Text, out double result);
                currentValue = result;
                double res = Operations(lastValue,currentValue,currentOperation);
                TextBox_Result.Text = res.ToString();
                currentValue = 0;
                lastValue = 0;
                currentOperation = "";
            } else if (btnContent == "C")
            {
                currentValue = 0;
                lastValue = 0;
                currentOperation = "";
                TextBox_Result.Text = "";
            } else
            {
                if( lastValue != 0 )
                {
                    currentValue = Double.Parse(TextBox_Result.Text);
                    double res = Operations(lastValue, currentValue, currentOperation);
                    currentValue = 0;
                    lastValue = res;
                    currentOperation = btnContent;
                    TextBox_Result.Text = "";
                } else
                {
                    lastValue = Double.Parse(TextBox_Result.Text);
                    currentOperation = btnContent;
                    TextBox_Result.Text = "";
                }
            }
        }
        private double Operations(double firstValue, double secondValue, string sign)
        {
            switch (sign)
            {
                case "+":
                    return firstValue + secondValue;
                case "-":
                    return firstValue - secondValue;
                case "*":
                    return firstValue * secondValue;
                case "/":
                    if (secondValue != 0) return firstValue / secondValue;
                    MessageBox.Show("You mustn't divide by zero!");
                    return 0;
                default:
                    return 0;
            }   
        }
    }

}