using List3.Commands;
using System.Windows.Input;

namespace List3.ViewModels
{
    internal class MainWindowViewModel
    {
        public ICommand ShowDataView { get; }
        public ICommand ShowRentCarView { get; }
        public ICommand ShowManageRentals { get; }

        public MainWindowViewModel()
        {
            ShowDataView = new RelayCommand(ShowData);
            ShowRentCarView = new RelayCommand(ShowRent);
            ShowManageRentals = new RelayCommand(ShowManageRentalsView);
        }
        private void ShowData()
        {
            ShowData newWindow = new ShowData();
            newWindow.ShowDialog();
        }
        private void ShowRent()
        {
            RentCarWindow newWindow = new RentCarWindow();
            newWindow.ShowDialog();
        }

        private void ShowManageRentalsView()
        {
            ManageRentals newWindow = new ManageRentals();
            newWindow.ShowDialog();
        }
    }
}
