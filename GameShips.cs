using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MaciejKloda_140054
{
    internal class GameShips
    {
        private ObservableCollection<int> _PlayerOne = new ObservableCollection<int>{};
        private ObservableCollection<int> _PlayerTwo = new ObservableCollection<int>{};

        public ObservableCollection<int> PlayerOne
        {
            get
            {
                return _PlayerOne;
            }
            set
            {
               _PlayerOne = value;
               OnPropertyChanged("PersonId");
            }
        }

        public ObservableCollection<int> PlayerTwo
        {
            get
            {
                return _PlayerTwo;
            }
            set
            {
                _PlayerTwo = value;
                OnPropertyChanged("PersonId");
            }
        }

        public GameShips(int[] PersonOne, int[] PersonTwo)
        {
            foreach (int _person in PersonOne)
            {
                _PlayerOne.Add(_person);
            }

            foreach (int _person in PersonTwo)
            {
                _PlayerTwo.Add(_person);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var eventHanlder = PropertyChanged;
            if (eventHanlder != null) eventHanlder(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
