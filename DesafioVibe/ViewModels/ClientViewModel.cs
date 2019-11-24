using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DesafioVibe.Views;
using DesafioVibe.Webservice;
using MonkeyCache.LiteDB;
using Xamarin.Forms;

namespace DesafioVibe.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        RestService _restService;

        private ObservableCollection<ClientResponse> clients;
        public ObservableCollection<ClientResponse> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
            }
        }

        public ClientViewModel()
        {
            _restService = new RestService();
            GetClientList();
            Clients = new ObservableCollection<ClientResponse>();

        }

        public Command OpenProfileCommand
        {
            get
            {
                return new Command(OpenProfile);
            }
        }

        private void OpenProfile()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ProfilePage());
        }

        private async void GetClientList()
        {
            List<ClientResponse> clientResponse = await _restService.GetClientList();
            foreach (ClientResponse client in clientResponse)
                Clients.Add(client);
        }
    }
}
