using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using List3.Commands;

namespace Lista3.ViewModels
{
    internal class ExtendRentViewModel : INotifyPropertyChanged
    {
        public bool _isOkPressed;
        private DateTime _extendedEndDate;
        public bool IsOkPressed
        {
            get => _isOkPressed;
            set
            {
                _isOkPressed = value;
                OnPropertyChanged("IsOkPressed");
            }
        }

        public DateTime ExtendedEndDate
        {
            get => _extendedEndDate;
            set
            {
                _extendedEndDate = value;
                OnPropertyChanged("ExtendedEndDate");
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public ExtendRentViewModel()
        {
            ExtendedEndDate = DateTime.Today;
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }
        private void Save()
        {
            IsOkPressed = true;
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
