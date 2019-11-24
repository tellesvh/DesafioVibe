using System;
using System.Collections.Generic;
using DesafioVibe.ViewModels;
using DesafioVibe.Webservice;
using Xamarin.Forms;

namespace DesafioVibe.Views
{
    public partial class ClientDetailPage : ContentPage
    {
        ClientDetailViewModel clientDetailViewModel;
        public ClientDetailPage(ClientResponse client)
        {
            clientDetailViewModel = new ClientDetailViewModel(client);
            InitializeComponent();
            BindingContext = clientDetailViewModel;
        }
    }
}