using System;
using System.ComponentModel;
using DesafioVibe.Webservice;

namespace DesafioVibe.ViewModels
{
    public class ClientDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        RestService _restService;
        ClientResponse _client;

        public ClientDetailViewModel(ClientResponse client)
        {
            _restService = new RestService();
            _client = client;
            GetInfo();
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }

        private string cpf;
        public string CPF
        {
            get { return cpf; }
            set
            {
                cpf = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CPF"));
            }
        }

        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Id"));
            }
        }

        private string special;
        public string Special
        {
            get { return special; }
            set
            {
                cpf = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Special"));
            }
        }

        private string imgUrl;
        public string ImgUrl
        {
            get { return imgUrl; }
            set
            {
                imgUrl = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ImgUrl"));
            }
        }

        private string company;
        public string Company
        {
            get { return company; }
            set
            {
                company = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Company"));
            }
        }

        private string addressFull;
        public string AddressFull
        {
            get { return addressFull; }
            set
            {
                addressFull = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AddressFull"));
            }
        }

        private string addressComplement;
        public string AddressComplement
        {
            get { return addressComplement; }
            set
            {
                addressComplement = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AddressComplement"));
            }
        }

        private string addressCity;
        public string AddressCity
        {
            get { return addressCity; }
            set
            {
                addressCity = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AddressCity"));
            }
        }

        private async void GetInfo()
        {
            name = _client.Name;
            cpf = _client.CPF;
            id = _client.Id;
            special = _client.IsSpecial ? "Sim" : "Não";

            ClientDetailResponse clientDetailResponse = await _restService.GetDetailedClientInfo(_client.Id);
            ImgUrl = clientDetailResponse.ImgUrl;
            Company = clientDetailResponse.Company;
            AddressFull = $"{clientDetailResponse.Address.Street}, {clientDetailResponse.Address.Number}";
            AddressComplement = clientDetailResponse.Address.Complement;
            AddressCity = clientDetailResponse.Address.City;
        }
        
    }
}
