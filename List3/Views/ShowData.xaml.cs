using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using List3.Commands;
using List3.ViewModels;

namespace List3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class ShowData : Window
    {
        public ShowData()
        {
            InitializeComponent();
            this.DataContext = new ShowDataViewModel();
            var db = new Database();
            db.ConnectToDatabase();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var viewModel = (ShowDataViewModel)this.DataContext;
            Serialization.SerializeToXml(viewModel.Cars, "D://listOfCars.xml");
        }
    }
}
