using List3.Commands;
using List3.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
            if (File.Exists("D://listOfCars.xml"))
            {
                var persons = Serialization.DeserializeToObject<List<Car>>("D://listOfCars.xml");
                foreach (var person in persons)
                {
                    Cars.Add(person);
                }
            }
            else
            {
                Cars.Add(new Car("aaaa", "bbbb", "1231232"));
                Cars.Add(new Car("aaaa", "bbbb", "1231232"));
                Cars.Add(new Car("aaaa", "bbbb", "1231232"));
            }

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
                newCar.Brand = viewModel.Brand;
                newCar.Model = viewModel.Model;
                newCar.VinNumber = viewModel.VinNumber;

                Cars.Add(newCar);
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
                }
            }
        }

        private void DeleteCar()
        {
            if (SelectedCar != null)
            {
                Cars.Remove(SelectedCar);
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

    }
}
