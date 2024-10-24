using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MaciejKloda_140054
{
    public partial class Calc : Window
    {
        private double tmpValue;
        private string tmpSign;


        private double firstValue;
        private double secondValue;
        private string sign;

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

            if (btnContent == "C")
            {
                firstValue = 0;
                secondValue = 0;
                sign = "";
                TextBox_Result.Text = "";
            }

            if (btnContent == "=")
            {
                double res = Operations(firstValue, secondValue, sign);
                TextBox_Result.Text = "";
            }

            if (firstValue != 0)
            {
                secondValue = Double.Parse(TextBox_Result.Text);
                double res = Operations(firstValue,secondValue,sign);
                TextBox_Result.Text = "";
                firstValue = res;
            } else
            {
                firstValue = Double.Parse(TextBox_Result.Text);
                sign = btnContent;
                TextBox_Result.Text = "";
            }


            //switch (btnContent)
            //{
            //    case "C":
            //        TextBox_Result.Text = "";
            //        tmpSign = "";
            //        tmpValue = 0;
            //        break;
            //    case "=":
            //        if (tmpValue != 0)
            //        {
            //            double textBoxValue = Double.Parse(TextBox_Result.Text);
            //            double res = Operations(tmpValue, textBoxValue, tmpSign);
            //            TextBox_Result.Text = res.ToString();
            //            tmpSign = "";
            //            tmpValue = 0;
            //        } else
            //        {
            //            tmpSign = "";
            //            tmpValue = 0;
            //        }
            //        break;
            //    case "+":
            //        if (TextBox_Result.Text.Length > 0)
            //        {
            //            if (tmpValue != 0)
            //            {
            //                double textBoxValue = Double.Parse(TextBox_Result.Text);
            //                tmpSign = "+";
            //                double res = Operations(tmpValue, textBoxValue, tmpSign);
            //                tmpValue = res;
            //                TextBox_Result.Text = "";
            //            } else
            //            {
            //                tmpValue = Double.Parse(TextBox_Result.Text);
            //                tmpSign = "+";
            //                TextBox_Result.Text = "";
            //            }
            //        }
            //        break;
            //    case "-":
            //        if (TextBox_Result.Text.Length > 0)
            //        {
            //            if (tmpValue != 0)
            //            {
            //                double textBoxValue = Double.Parse(TextBox_Result.Text);
            //                tmpSign = "-";
            //                double res = Operations(tmpValue, textBoxValue, tmpSign);
            //                tmpValue = res;
            //                TextBox_Result.Text = "";
            //            }
            //            else
            //            {
            //                tmpValue = Double.Parse(TextBox_Result.Text);
            //                tmpSign = "-";
            //                TextBox_Result.Text = "";
            //            }
            //        }
            //        break;
            //    case "*":
            //        if (TextBox_Result.Text.Length > 0)
            //        {
            //            if (tmpValue != 0)
            //            {
            //                double textBoxValue = Double.Parse(TextBox_Result.Text);
            //                tmpSign = "*";
            //                double res = Operations(tmpValue, textBoxValue,tmpSign);
            //                tmpValue = res;
            //                TextBox_Result.Text = "";
            //            }
            //            else
            //            {
            //                tmpValue = Double.Parse(TextBox_Result.Text);
            //                tmpSign = "*";
            //                TextBox_Result.Text = "";
            //            }
            //        }
            //        break;
            //    case "/":
            //        if (TextBox_Result.Text.Length > 0)
            //        {
            //            if (tmpValue != 0)
            //            {
            //                double textBoxValue = Double.Parse(TextBox_Result.Text);
            //                tmpSign = "/";
            //                double res = Operations(tmpValue, textBoxValue, tmpSign);
            //                tmpValue = res;
            //                TextBox_Result.Text = "";
            //            }
            //            else
            //            {
            //                tmpValue = Double.Parse(TextBox_Result.Text);
            //                tmpSign = "/";
            //                TextBox_Result.Text = "";
            //            }
            //        }
            //        break;
                                    
            //}
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