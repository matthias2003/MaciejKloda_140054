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

namespace List3
{
    /// <summary>
    /// Interaction logic for AddPerson.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        public bool IsOkPressed { get; private set; } = false;
        public PersonWindow()
        {
            InitializeComponent();
        }

        public PersonWindow(string title)
        {
            InitializeComponent();
            TextBlockTitle.Text = title;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Content.ToString() == "Save")
            {
                IsOkPressed = true;
            } else if (btn.Content.ToString() == "Cancel")
            {
                IsOkPressed = false;
            }
            this.DialogResult = true;
        }
    }
}
