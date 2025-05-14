using _1125.Model;
using _1125.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _1125.VMTools
{
    internal class MainVM : BaseVM
    {
        public ICommand OpenLogin { get; set; }
        public ICommand Category { get; set; }
        public ICommand Registration { get; set; }
        public ICommand Products { get; set; }

        public MainVM(MainWindow mainWindow)
        {
            Products = new CommandVM(() =>
            {
                ProductsWindow productsWindow = new ProductsWindow();
                mainWindow.Hide();
                productsWindow.ShowDialog();
            }, () => true);

            Category = new CommandVM(() =>
            {
                CategoryWindow categoryWindow = new CategoryWindow();
                mainWindow.Hide();
                categoryWindow.ShowDialog();
            }, () => true);

            OpenLogin = new CommandVM(() =>
            {
                EntranceWindow entranceWindow = new EntranceWindow();
                mainWindow.Hide();
                entranceWindow.ShowDialog();
            }, () => true);
            
            Registration = new CommandVM(() =>
            {
                RegistrationWindow registrationWindow = new RegistrationWindow();
                mainWindow.Hide();
                registrationWindow.ShowDialog();
            }, () => true);
        }
    }
}

