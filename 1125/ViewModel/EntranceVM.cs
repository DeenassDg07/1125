using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using _1125.Model;
using _1125.View;
using _1125.VMTools;

namespace _1125.ViewModel
{
    internal class EntranceVM : BaseVM
    {
        private User currentUser;
        public User CurrentUser
        {
            get => currentUser;
            set
            {
                currentUser = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanRegister));
            }
        }
        public bool CanRegister => CurrentUser?.Role == "user";

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 

        public ICommand Registration { get; set; }
        public EntranceVM()


        {
            Registration = new CommandVM(() =>
            {
                RegistrationWindow registrationWindow = new RegistrationWindow();
                close?.Invoke();
                registrationWindow.ShowDialog();
            }, () => true);
        }
        Action close;
        internal void SetClose(Action close)
        {
            this.close = close;
        }
    }
}


