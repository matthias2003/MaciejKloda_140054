using System.ComponentModel;
using System.Xml.Serialization;

namespace List3.Models
{
    [XmlRoot(ElementName = "Cars")]
    public class Car : INotifyPropertyChanged
    {
        private string _brand;
        private string _model;
        private string _vinNumber;

        [XmlAttribute("Brand")]
        public string Brand
        {
            get { return _brand; }
            set 
            {
                _brand = value;
                OnPropertyChanged("Brand");
            }
        }

        [XmlAttribute("Model")]
        public string Model
        {
            get { return _model; }
            set 
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }

        [XmlAttribute("VinNumber")]
        public string VinNumber
        {
            get { return _vinNumber; }
            set 
            {
                _vinNumber = value;
                OnPropertyChanged("VinNumber");
            }
        }
        public Car()
        {

        }

        public Car(Car car)
        {
            this.Brand = car.Brand;
            this.Model = car.Model;
            this.VinNumber = car.VinNumber;
        }
        public Car(string brand, string model, string vinNumber)
        {
            _brand = brand;
            _model = model;
            _vinNumber = vinNumber;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
