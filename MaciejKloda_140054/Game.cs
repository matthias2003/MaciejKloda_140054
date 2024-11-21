using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;

namespace MaciejKloda_140054
{
    internal class Game
    {
        private ObservableCollection<string> _tab;

        public ObservableCollection<string> tab
        {
            get { return _tab; }
            set
            {
                _tab = value;
                OnPropertyChanged("tab");
                this.CheckWinner();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Game()
        {
            tab = new ObservableCollection<string>();
            for (int i = 0; i < 9; i++)
            tab.Add("");
        }

        public void CheckWinner()
        {
            if (tab.Count() == 9) {
                int[][] winCombs =
                [
                    [0, 1, 2],
                    [3, 4, 5],
                    [6, 7, 8],
                    [0, 3, 6], 
                    [1, 4, 7],
                    [2, 5, 8], 
                    [0, 4, 8], 
                    [2, 4, 6]
                ];

                foreach (var combo in winCombs)
                {
                    if (tab[combo[0]] == tab[combo[1]] &&
                        tab[combo[1]] == tab[combo[2]] &&
                        !string.IsNullOrEmpty(tab[combo[0]]))
                    {
                        MessageBox.Show("Game won by: " + tab[combo[0]]);
                        for (int i = 0; i < 9; i++)
                        {
                            tab[i] = "";
                        }
                    } else if (tab.Count(field => !string.IsNullOrEmpty(field)) == 9)
                    {
                        MessageBox.Show("Tie");
                        for (int i = 0; i < 9; i++)
                        {
                           tab[i] = "";
                        }
                    }
                }
            }
        }
    }
}
