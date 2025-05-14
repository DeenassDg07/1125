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

        //private Client selectedClient;
        //private ObservableCollection<Client> clients = new();

        //public ObservableCollection<Client> Clients
        //{
        //    get => clients;
        //    set
        //    {
        //        clients = value;
        //        Signal();
        //    }
        //}
        //public Client SelectedClient
        //{
        //    get => selectedClient;
        //    set
        //    {
        //        selectedClient = value;
        //        Signal();
        //    }
        //}
        //public CommandVM UpdateClient { get; set; }
        //public CommandVM RemoveClient { get; set; }
        //public CommandVM AddClient { get; set; }
        public ICommand OpenLogin { get; set; }

        public MainVM(MainWindow mainWindow)
        {
            OpenLogin = new CommandVM(() =>
            {
                EntranceWindow entranceWindow = new EntranceWindow();
                mainWindow.Hide();
                entranceWindow.ShowDialog();
            }, () => true);
        }

        //private void SelectAll()
        //{
        //    Clients = new ObservableCollection<Client>(ClientsDB.GetDb().SelectAll());
        //}

    }
}

