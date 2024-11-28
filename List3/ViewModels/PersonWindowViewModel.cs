using List3.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace List3.ViewModels
{
    public class PersonWindowViewModel : INotifyPropertyChanged
    {
        private bool _isOkPressed;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public bool IsOkPressed
        {
            get => _isOkPressed;
            private set
            {
                _isOkPressed = value;
                OnPropertyChanged("IsOkPressed");
            }
        }

        public PersonWindowViewModel()
        {
            SaveCommand = new RelayCommand(Save, CanSave);
            CancelCommand = new RelayCommand(Cancel);
        }
        private void Save()
        {
            IsOkPressed = true;
        }

        private bool CanSave()
        {
            return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(PersonalNumber);
        }

        private void Cancel()
        {
            IsOkPressed = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
