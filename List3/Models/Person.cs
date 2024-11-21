using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace List3
{
    [XmlRoot(ElementName = "Persons")]
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private string _personalNumber;

        [XmlAttribute("FirstName")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [XmlAttribute("LastName")]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [XmlAttribute("PersonalNumber")]
        public string PersonalNumber
        {
            get { return _personalNumber; }
            set { _personalNumber = value; }
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
    }
}
