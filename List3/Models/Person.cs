using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace List3
{
    [XmlRoot(ElementName = "Persons")]
    public class Person : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _personalNumber;

       

        [XmlAttribute("FirstName")]
        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }

        }

        [XmlAttribute("LastName")]
        public string LastName
        {
            get { return _lastName; }
            set 
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        [XmlAttribute("PersonalNumber")]
        public string PersonalNumber
        {
            get { return _personalNumber; }
            set 
            { 
                _personalNumber = value;
                OnPropertyChanged(nameof(PersonalNumber));
            }
        }
        public Person()
        {

        }

        public Person(Person person)
        {
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.PersonalNumber = person.PersonalNumber;
        }
        public Person(string firstName, string lastName, string personalNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _personalNumber = personalNumber;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
