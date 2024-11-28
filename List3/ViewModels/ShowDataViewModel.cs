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
        public ObservableCollection<Person> Persons { get; set; } = new ObservableCollection<Person>();

        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson));
            }
        }

        public ICommand AddPersonCommand { get; }
        public ICommand DeletePersonCommand { get; }
        public ICommand EditPersonCommand { get; }


        public ShowDataViewModel()
        {
            if (File.Exists("D://listOfPersons.xml"))
            {
                var persons = Serialization.DeserializeToObject<List<Person>>("D://listOfPersons.xml");
                foreach (var person in persons)
                {
                    Persons.Add(person);
                }
            }
            else
            {
                Persons.Add(new Person("aaaa", "bbbb", "1231232"));
                Persons.Add(new Person("aaaa", "bbbb", "1231232"));
                Persons.Add(new Person("aaaa", "bbbb", "1231232"));
            }

            AddPersonCommand = new RelayCommand(AddPerson);
            DeletePersonCommand = new RelayCommand(DeletePerson, CanModifyPerson);
            EditPersonCommand = new RelayCommand(EditPerson, CanModifyPerson);
        }

        private void AddPerson()
        {
            Person newPerson = new Person();
            PersonWindow addPersonWindow = new PersonWindow("Add new person");
            PersonWindowViewModel viewModel = (PersonWindowViewModel)addPersonWindow.DataContext;
            addPersonWindow.ShowDialog();

            if (viewModel.IsOkPressed)
            { 
                newPerson.FirstName = viewModel.FirstName;
                newPerson.LastName = viewModel.LastName;
                newPerson.PersonalNumber = viewModel.PersonalNumber;

                Persons.Add(newPerson);
            }
        }

        private void EditPerson()
        {
            if (SelectedPerson != null)
            {
                var editPersonWindow = new PersonWindow("Edit person");
                PersonWindowViewModel viewModel = (PersonWindowViewModel)editPersonWindow.DataContext;

                viewModel.FirstName = SelectedPerson.FirstName;
                viewModel.LastName = SelectedPerson.LastName;
                viewModel.PersonalNumber = SelectedPerson.PersonalNumber;

                editPersonWindow.ShowDialog();

                if (viewModel.IsOkPressed)
                {
                    SelectedPerson.FirstName = viewModel.FirstName;
                    SelectedPerson.LastName = viewModel.LastName;
                    SelectedPerson.PersonalNumber = viewModel.PersonalNumber;
                }
            }
        }

        private void DeletePerson()
        {
            if (SelectedPerson != null)
            {
                Persons.Remove(SelectedPerson);
            }
        }

        private bool CanModifyPerson()
        {
            return SelectedPerson != null;
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
