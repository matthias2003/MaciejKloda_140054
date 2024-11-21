using List3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace List3.ViewModels
{
    public class ShowDataViewModel
    {
        public List<Person> listOfPersons = new List<Person>();
        public ShowDataViewModel()
        {
            InitializeComponent();
            if (File.Exists("D://listOfPersons.xml"))
            {
                listOfPersons = Serialization.DeserializeToObject<List<Person>>("D://listOfPersons.xml");
            }
            else
            {
                listOfPersons.Add(new Person("aaaa", "bbbb", "1231232"));
                listOfPersons.Add(new Person("aaaa", "bbbb", "1231232"));
                listOfPersons.Add(new Person("aaaa", "bbbb", "1231232"));
            }
            PersonDataGrid.ItemsSource = listOfPersons;
        }

        private void Button_Click_AddPerson(object sender, RoutedEventArgs e)
        {
            PersonWindow addPerson = new PersonWindow("Add new person");
            Person newPerson = new Person();
            addPerson.DataContext = newPerson;
            addPerson.ShowDialog();
            if (addPerson.IsOkPressed)
            {
                listOfPersons.Add(newPerson);
                PersonDataGrid.Items.Refresh();
            }
        }

        private void Button_Click_Properties(object sender, RoutedEventArgs e)
        {
            if (PersonDataGrid.SelectedItem != null)
            {
                PersonWindow personPropertiesWindow = new PersonWindow("Show properties of person");
                Person propertiesPerson = new Person((Person)PersonDataGrid.SelectedItem);
                personPropertiesWindow.DataContext = propertiesPerson;
                personPropertiesWindow.ShowDialog();

                if (personPropertiesWindow.IsOkPressed)
                {
                    int index = listOfPersons.IndexOf((Person)PersonDataGrid.SelectedItem);
                    listOfPersons[index] = propertiesPerson;
                    PersonDataGrid.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please choose person to view details");
                return;
            }
        }


        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (PersonDataGrid.SelectedItem != null)
            {
                Person selectedPerson = (Person)PersonDataGrid.SelectedItem;
                listOfPersons.Remove(selectedPerson);
                PersonDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please choose person to delete");
                return;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serialization.SerializeToXml<List<Person>>(listOfPersons, "D://listOfPersons.xml");
        }
    }
}
