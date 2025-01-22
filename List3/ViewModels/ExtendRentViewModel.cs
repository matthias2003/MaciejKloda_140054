using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
            SaveCommand = new RelayCommand(Save, CanSave);
            CancelCommand = new RelayCommand(Cancel);
        }
        private void Save()
        {
            IsOkPressed = true;
        }

        private bool CanSave()
        {
            return ExtendedEndDate != DateTime.MinValue;
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
