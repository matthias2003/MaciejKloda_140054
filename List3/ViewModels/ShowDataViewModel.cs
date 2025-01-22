using List3.Commands;
using List3.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Windows.Input;

namespace List3.ViewModels
{
    public class ShowDataViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>();

        private Car _selectedCar;

        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }

        public ICommand AddPersonCommand { get; }
        public ICommand DeletePersonCommand { get; }
        public ICommand EditPersonCommand { get; }
        

        public ShowDataViewModel()
        {
            Cars = Database.GetData();

            AddPersonCommand = new RelayCommand(AddCar);
            DeletePersonCommand = new RelayCommand(DeleteCar, CanModifyCar);
            EditPersonCommand = new RelayCommand(EditCar, CanModifyCar);
        }



        private void AddCar()
        {
            Car newCar = new Car();
            CarWindow addCarnWindow = new CarWindow("Add new car");
            CarWindowViewModel viewModel = (CarWindowViewModel)addCarnWindow.DataContext;
            addCarnWindow.ShowDialog();

            if (viewModel.IsOkPressed)
            {
                newCar.Id = 0;
                newCar.Brand = viewModel.Brand;
                newCar.Model = viewModel.Model;
                newCar.VinNumber = viewModel.VinNumber;

                Database.AddCarToDatabase(newCar);
                RefetchData();
            }
        }

        private void EditCar()
        {
            if (SelectedCar != null)
            {
                var editPersonWindow = new CarWindow("Edit car");
                CarWindowViewModel viewModel = (CarWindowViewModel)editPersonWindow.DataContext;
               
                viewModel.Brand = SelectedCar.Brand;
                viewModel.Model = SelectedCar.Model;
                viewModel.VinNumber = SelectedCar.VinNumber;

                editPersonWindow.ShowDialog();

                if (viewModel.IsOkPressed)
                {
                    SelectedCar.Brand = viewModel.Brand;
                    SelectedCar.Model = viewModel.Model;
                    SelectedCar.VinNumber = viewModel.VinNumber;

                    Database.EditCar(SelectedCar);
                    RefetchData();
                }
            }
        }

        private void DeleteCar()
        {
            if (SelectedCar != null)
            {
                Database.DeleteCar(SelectedCar);
                RefetchData();
            }
        }

        private bool CanModifyCar()
        {
            return SelectedCar != null;
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefetchData()
        {
            Cars = Database.GetData();
            OnPropertyChanged(nameof(Cars));
        }

    }
}
