using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using List3.Commands;
using List3.Models;
using Lista3.ViewModels;

namespace List3.ViewModels
{
    internal class ManageRentalsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Rental> _rentals;
        private Rental _selectedCar;

        public ICommand ExtendRentalCommand { get; }
        public ICommand DeleteRentalCommand { get; }

        public ObservableCollection<Rental> Rentals
        {
            get => _rentals;
            set
            {
                _rentals = value;
                OnPropertyChanged("Rentals");
            }
        }

        public Rental SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                OnPropertyChanged("SelectedRental");
            }
        }

        public ManageRentalsViewModel()
        {
            LoadDataAsync();
            ExtendRentalCommand = new RelayCommand(ExtendRent);
            DeleteRentalCommand = new RelayCommand(DeleteRental);
        }

        public async Task LoadDataAsync()
        {
            var rentals = await Database.GetRentals();
            Rentals = new ObservableCollection<Rental>(rentals);
            OnPropertyChanged(nameof(Rentals));
        }

        public async void ExtendRent()
        {
            ExtendRentWindow addCarnWindow = new ExtendRentWindow();
            ExtendRentViewModel viewModel = (ExtendRentViewModel)addCarnWindow.DataContext;
            addCarnWindow.ShowDialog();

            if (viewModel.IsOkPressed)
            {
                if (SelectedCar != null)
                {
                    await Database.UpdateRentalEndDate(SelectedCar.Id, viewModel.ExtendedEndDate);
                    await LoadDataAsync();
                } 
            }
        }

        public async void DeleteRental()
        {
            if (SelectedCar != null)
            {
                await Database.DeleteRental(SelectedCar);
                await LoadDataAsync();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
