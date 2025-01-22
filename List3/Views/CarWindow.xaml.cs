using System.Windows;
using List3.ViewModels;

namespace List3
{
    public partial class CarWindow : Window
    {
        public CarWindow()
        {
            InitializeComponent();
        }

        public CarWindow(string title)
        {
            InitializeComponent();
            CarWindowViewModel viewModel = new CarWindowViewModel();
            this.DataContext = viewModel;
            TextBlockTitle.Text = title;
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.IsOkPressed))
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
                }
            };
        }
    }
}