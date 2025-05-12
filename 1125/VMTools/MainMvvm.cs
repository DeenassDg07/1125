using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace _1125.VMTools
//{
    //internal class MainMvvm : BaseVM
    //{
        
//        private Client selectedClient;
//        private ObservableCollection<Client> clients = new();

//        public ObservableCollection<Client> Clients
//        {
//            get => clients;
//            set
//            {
//                clients = value;
//                Signal();
//            }
//        }
//        public Client SelectedClient
//        {
//            get => selectedClient;
//            set
//            {
//                selectedClient = value;
//                Signal();
//            }
//        }
//        public CommandVM UpdateClient { get; set; }
//        public CommandVM RemoveClient { get; set; }
//        public CommandVM AddClient { get; set; }

//        public MainMvvm()
//        {
//            SelectAll();

//            UpdateClient = new CommandVM(() =>
//            {
//                if (ClientsDB.GetDb().Update(SelectedClient))
//                    MessageBox.Show("Успешно");
//            }, () => SelectedClient != null);

//            RemoveClient = new CommandVM(() =>
//            {
//                ClientsDB.GetDb().Remove(SelectedClient);
//                SelectAll();
//            }, () => SelectedClient != null);

//            AddClient = new CommandVM(() =>
//            {
//                new WinAddClient().ShowDialog();
//                SelectAll();
//            }, () => true);
//        }

//        private void SelectAll()
//        {
//            Clients = new ObservableCollection<Client>(ClientsDB.GetDb().SelectAll());
//        }

//    }
//}

