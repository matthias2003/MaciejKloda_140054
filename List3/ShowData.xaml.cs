using System.Collections.Generic;
using System.Windows;
using Lista3;

namespace List3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class ShowData : Window
    {
        List<Person> listOfPersons = new List<Person>();
        public ShowData()
        {
            InitializeComponent();
            listOfPersons.Add(new Person("aaaa", "bbbb","1231232"));
            listOfPersons.Add(new Person("aaaa", "bbbb", "1231232"));
            listOfPersons.Add(new Person("aaaa", "bbbb","1231232"));
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
            else {
                MessageBox.Show("Please choose person to view details");
                return;
            }
        }
    }
}
