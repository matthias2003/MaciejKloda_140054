using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using List3.Commands;
using List3.Models;

namespace List3.ViewModels
{
    public class RentCarViewModel : INotifyPropertyChanged
    {
        private string _customerName;
        private object _selectedCar;
        private DateTime? _rentalStartDate;
        private DateTime? _rentalEndDate;

        public ICommand SubmitCommand { get; }

        public ObservableCollection<Car> AvailableCars { get; private set; }

        public RentCarViewModel()
        {
            LoadAvailableCarsAsync();
            SubmitCommand = new RelayCommand(Submit);
        }

        public string CustomerName
        {
            get => _customerName;
            set
            {
                _customerName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        public object SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }

        public DateTime? RentalStartDate
        {
            get => _rentalStartDate;
            set
            {
                _rentalStartDate = value;
                OnPropertyChanged("RentalStartDate");
            }
        }

        public DateTime? RentalEndDate
        {
            get => _rentalEndDate;
            set
            {
                _rentalEndDate = value;
                OnPropertyChanged("RentalEndDate");
            }
        }
        private async Task LoadAvailableCarsAsync()
        {
            AvailableCars = await Database.GetAvailableCars();
            OnPropertyChanged(nameof(AvailableCars));
        }

        public async void Submit()
        {
            if (SelectedCar == null || string.IsNullOrWhiteSpace(CustomerName) || RentalStartDate == null || RentalEndDate == null)
            {
                MessageBox.Show("All fields must be filled in!");
                return;
            }

            var rental = new Rental
            {
                CarId = ((Car)SelectedCar).Id,
                CustomerName = CustomerName,
                RentalStartDate = RentalStartDate.Value,
                RentalEndDate = RentalEndDate.Value,
                Car = (Car)SelectedCar  
            };

            bool isSuccess = await Database.AddRentalToDatabase(rental);


            if (isSuccess)
            {
                MessageBox.Show("The rental has been successfully added.");
            }
            else
            {
                MessageBox.Show("An error occurred while adding the rental.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
