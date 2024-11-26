using List3;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using List3.Commands;


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
            var newPerson = new Person();
            var addPersonWindow = new PersonWindow("Add new person");
            addPersonWindow.DataContext = newPerson;

            if (addPersonWindow.ShowDialog() == true)
            {
                Persons.Add(newPerson);
            }
        }

        private void EditPerson()
        {
            if (SelectedPerson != null)
            {
                var editedPerson = new Person
                {
                    FirstName = SelectedPerson.FirstName,
                    LastName = SelectedPerson.LastName,
                    PersonalNumber = SelectedPerson.PersonalNumber
                };

                var editPersonWindow = new PersonWindow("Edit person");
                editPersonWindow.DataContext = editedPerson;

                if (editPersonWindow.ShowDialog() == true)
                {
                    SelectedPerson.FirstName = editedPerson.FirstName;
                    SelectedPerson.LastName = editedPerson.LastName;
                    SelectedPerson.PersonalNumber = editedPerson.PersonalNumber;
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
