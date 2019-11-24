using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DesafioVibe.Views;
using DesafioVibe.Webservice;
using MonkeyCache.LiteDB;
using Xamarin.Forms;
using Plugin.Connectivity;

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

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsListRefreshing"));
            }
        }

        public ClientViewModel()
        {
            _restService = new RestService();
            Clients = new ObservableCollection<ClientResponse>();
            GetClientList();
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

        public Command RefreshListCommand
        {
            get
            {
                return new Command(RefreshList);
            }
        }

        private async void GetClientList()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                List<ClientResponse> cacheClients = Barrel.Current.Get<List<ClientResponse>>(Constants.CLIENTS);
                foreach (ClientResponse client in cacheClients)
                    Clients.Add(client);
                Device.BeginInvokeOnMainThread(async () => await Application.Current.MainPage.DisplayAlert("Atenção", "Você não está conectado à internet, portanto, esta listagem é offline. Recarregue a lista puxando-a para cima.", "OK"));      
            }
            else
            {
                List<ClientResponse> clientResponse = await _restService.GetClientList();
                Barrel.Current.Add(Constants.CLIENTS, clientResponse, TimeSpan.Zero);
                foreach (ClientResponse client in clientResponse)
                    Clients.Add(client);
            }
        }

        private async void RefreshList()
        {
            IsRefreshing = true;

            if (!CrossConnectivity.Current.IsConnected)
            {
                await Application.Current.MainPage.DisplayAlert("Atenção", "Você não está conectado à internet. Não é possível atualizar a lista.", "OK");
            }
            else
            {
                List<ClientResponse> clientResponse = await _restService.GetClientList();
                if (clientResponse.Count > 0)
                {
                    Barrel.Current.Add(Constants.CLIENTS, clientResponse, TimeSpan.Zero);
                    Clients.Clear();
                    foreach (ClientResponse client in clientResponse)
                        Clients.Add(client);
                }
                
            }

            IsRefreshing = false;
        }
    }
}
