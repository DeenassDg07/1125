using _1125.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _1125.ViewModel
{
    internal class EditingAddingWindowViewModel
    {
        public ICommand OpenImage {  get; set; }

        public EditingAddingWindowViewModel()
        {
            OpenImage = new CommandVM(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
            }, () => true);
        }
    }
}
