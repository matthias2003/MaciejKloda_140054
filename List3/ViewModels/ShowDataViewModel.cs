using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using List3.Commands;
using List3.Models;

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
            LoadDataAsync();
            AddPersonCommand = new RelayCommand(AddCar);
            DeletePersonCommand = new RelayCommand(DeleteCar, CanModifyCar);
            EditPersonCommand = new RelayCommand(EditCar, CanModifyCar);
        }

        private async Task LoadDataAsync()
        {
            var cars = await Database.GetData();
            Cars = new ObservableCollection<Car>(cars);
            OnPropertyChanged(nameof(Cars));
        }

        private async void AddCar()
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

                await Database.AddCarToDatabase(newCar);
                await LoadDataAsync();
            }
        }

        private async void EditCar()
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

                    await Database.EditCar(SelectedCar);
                    await LoadDataAsync();
                }
            }
        }

        private async void DeleteCar()
        {
            if (SelectedCar != null)
            {
                await Database.DeleteCar(SelectedCar);
                await LoadDataAsync();
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
