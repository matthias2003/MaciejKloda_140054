using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using List3.Commands;
using System.Windows.Input;

namespace List3.ViewModels
{
    public class PersonWindowViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public bool IsOkPressed { get; private set; } = false;

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
    }
}
