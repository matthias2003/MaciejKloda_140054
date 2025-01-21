using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace List3.ViewModels
{
    public class RentCarViewModel : INotifyPropertyChanged
    {
        
        private string _customerName;
        private object _selectedCar;
        private DateTime? _rentalStartDate;
        private DateTime? _rentalEndDate;

        public RentCarViewModel()
        {
            // fetch data
            
        }

        public string CustomerName
        {
            get => _customerName;
            set
            {
                _customerName = value;
                OnPropertyChanged();
            }
        }

        public object SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                OnPropertyChanged();
            }
        }

        public DateTime? RentalStartDate
        {
            get => _rentalStartDate;
            set
            {
                _rentalStartDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime? RentalEndDate
        {
            get => _rentalEndDate;
            set
            {
                _rentalEndDate = value;
                OnPropertyChanged();
            }
        }

        //public ObservableCollection<Car> Cars { get; }

        //public ICommand SubmitCommand { get; }

        //private void Submit(object parameter)
        //{
        //    // Logic to handle the submission
        //    // For example, save to a database or show a confirmation message
        //    System.Windows.MessageBox.Show($"Customer: {CustomerName}\n" +
        //                                    $"Car: {(SelectedCar as Car)?.Model}\n" +
        //                                    $"Start Date: {RentalStartDate:d}\n" +
        //                                    $"End Date: {RentalEndDate:d}");
        //}

        //private bool CanSubmit(object parameter)
        //{
        //    // Enable button only when all fields are filled
        //    return !string.IsNullOrWhiteSpace(CustomerName) &&
        //            SelectedCar != null &&
        //            RentalStartDate.HasValue &&
        //            RentalEndDate.HasValue &&
        //            RentalStartDate <= RentalEndDate;
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
