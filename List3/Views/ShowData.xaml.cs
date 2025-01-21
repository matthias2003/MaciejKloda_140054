using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using List3.Commands;
using List3.ViewModels;

namespace List3
{
    public partial class ShowData : Window
    {
        public ShowData()
        {
            InitializeComponent();
            this.DataContext = new ShowDataViewModel();
        }
    }
}
