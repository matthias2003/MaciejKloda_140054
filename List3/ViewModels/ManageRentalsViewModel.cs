using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
            Rentals = Database.GetRentals();
            ExtendRentalCommand = new RelayCommand(ExtendRent);
            DeleteRentalCommand = new RelayCommand(DeleteRental);
        }

        public void ExtendRent()
        {
            ExtendRentWindow addCarnWindow = new ExtendRentWindow();
            ExtendRentViewModel viewModel = (ExtendRentViewModel)addCarnWindow.DataContext;
            addCarnWindow.ShowDialog();

            if (viewModel.IsOkPressed)
            {
                Database.UpdateRentalEndDate(SelectedCar.Id,viewModel.ExtendedEndDate);
                RefetchData();
            }
        }

        public void DeleteRental()
        {
            if (SelectedCar != null)
            {
                Database.DeleteRental(SelectedCar);
                RefetchData();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefetchData()
        {
            Rentals = Database.GetRentals();
            OnPropertyChanged(nameof(Rentals));
        }
    }
}
