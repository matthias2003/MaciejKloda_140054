using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace List3.Models
{
    public class Rental : INotifyPropertyChanged
    {
        private int _id;
        private int _carId;
        private string _customerName;
        private DateTime _rentalStartDate;
        private DateTime _rentalEndDate;
        public int Id 
        {
            get
            { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public int CarId
        {
            get
            { return _carId; }
            set
            {
                _carId = value;
                OnPropertyChanged("CarId");
            }
        }

        public string CustomerName
        {
            get
            { return _customerName; }
            set
            {
                _customerName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        public DateTime RentalStartDate
        {
            get
            { return _rentalStartDate; }
            set
            {
                _rentalStartDate = value;
                OnPropertyChanged("RentalStartDate");
            }
        }

        public DateTime RentalEndDate
        {
            get
            { return _rentalEndDate; }
            set
            {
                _rentalEndDate = value;
                OnPropertyChanged("RentalEndDate");
            }
        }

        [JsonPropertyName("car")]
        public Car Car { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
