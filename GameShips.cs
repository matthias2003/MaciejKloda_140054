using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

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

            _PlayerOne.CollectionChanged += PlayerOne_CollectionChanged;
            _PlayerTwo.CollectionChanged += PlayerTwo_CollectionChanged;
        }

        private void PlayerOne_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CheckWinner(_PlayerOne, "Player Two");
        }

        private void PlayerTwo_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CheckWinner(_PlayerTwo, "Player One");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var eventHandler = PropertyChanged;
            if (eventHandler != null) eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CheckWinner(ObservableCollection<int> tab, string opponentName)
        {
            bool hasRemainingShips = tab.Contains(1);

            if (!hasRemainingShips)
            {
                MessageBox.Show($"The Winner is {opponentName}!");
                ResetGame();
            }
        }

        public void ResetGame()
        {
            _PlayerOne.CollectionChanged -= PlayerOne_CollectionChanged;
            _PlayerTwo.CollectionChanged -= PlayerTwo_CollectionChanged;

            for (int i = 0; i < 25; i++)
            {
                PlayerOne[i] = 0;
                PlayerTwo[i] = 0;
            }

            _PlayerOne.CollectionChanged += PlayerOne_CollectionChanged;
            _PlayerTwo.CollectionChanged += PlayerTwo_CollectionChanged;
        }
    }
}
