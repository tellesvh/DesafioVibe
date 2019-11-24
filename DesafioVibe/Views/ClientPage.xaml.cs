using System;
using System.Collections.Generic;
using DesafioVibe.Webservice;
using Xamarin.Forms;

namespace DesafioVibe.Views
{
    public partial class ClientPage : ContentPage
    {
        RestService _restService;

        public ClientPage()
        {
            InitializeComponent();
            _restService = new RestService();
            GetInfo();
        }

        private void btnProfileClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }

        private async void GetInfo()
        {
            List<ClientResponse> userResponse = await _restService.GetClientList();
        }
    }
}
