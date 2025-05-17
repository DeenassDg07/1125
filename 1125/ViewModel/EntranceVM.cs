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
        public ICommand Registration { get; set; }

        public EntranceVM()
        {
            Registration = new CommandVM(() =>
                {
                    RegistrationWindow registrationWindow = new RegistrationWindow();
                    registrationWindow.Show();
                    close?.Invoke();
                    registrationWindow.ShowDialog();
                }, () => true);
        }
        public EntranceVM(bool canRegister)
        {
            CanRegister = canRegister;
        }
        public bool CanRegister { get; }
        
        Action close;
        internal void SetClose(Action close)
        {
            this.close = close;
        }
    }
}


