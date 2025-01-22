using System;
using System.Windows;
using Lista3.ViewModels;

namespace List3
{
    public partial class ExtendRentWindow : Window
    {
        public ExtendRentWindow()
        {
            InitializeComponent();
            var viewModel = new ExtendRentViewModel();
            this.DataContext = viewModel;

            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(viewModel.IsOkPressed))
                {
                    if (viewModel.IsOkPressed)
                    {
                        this.DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        this.DialogResult = false;
                        this.Close();
                    }
                }
            };

        }
    }
}
