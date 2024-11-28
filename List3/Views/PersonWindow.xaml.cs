using List3.ViewModels;
using System.Windows;

namespace List3
{
    /// <summary>
    /// Interaction logic for AddPerson.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        public PersonWindow()
        {
            InitializeComponent();
        }

        public PersonWindow(string title)
        {
            InitializeComponent();
            PersonWindowViewModel viewModel = new PersonWindowViewModel();
            this.DataContext = viewModel;
            TextBlockTitle.Text = title;

            viewModel.PropertyChanged += (sender, e) =>
            {
                if (viewModel.IsOkPressed)
                {
                    this.DialogResult = true; 
                    this.Close(); 
                }
                else if (!viewModel.IsOkPressed)
                {
                    this.DialogResult = false;
                    this.Close();
                }
            };
        }
    }
}
