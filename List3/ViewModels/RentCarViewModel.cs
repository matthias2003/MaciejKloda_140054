using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using List3.Models;
using List3.Commands;
using System.Windows;

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
            AvailableCars = Database.GetAvailableCars();
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

        public void Submit()
        {
            if (SelectedCar == null || string.IsNullOrWhiteSpace(CustomerName) || RentalStartDate == null || RentalEndDate == null)
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione!");
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

            bool isSuccess = Database.AddRentalToDatabase(rental);

            if (isSuccess)
            {
                MessageBox.Show("Wypożyczenie zostało pomyślnie dodane.");
            }
            else
            {
                MessageBox.Show("Wystąpił problem podczas dodawania wypożyczenia.");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
