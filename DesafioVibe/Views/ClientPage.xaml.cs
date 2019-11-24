using System;
using System.Collections.Generic;
using DesafioVibe.ViewModels;
using DesafioVibe.Webservice;
using Xamarin.Forms;

namespace DesafioVibe.Views
{
    public partial class ClientPage : ContentPage
    {
        ClientViewModel clientViewModel;
        public ClientPage()
        {
            clientViewModel = new ClientViewModel();
            InitializeComponent();
            BindingContext = clientViewModel;
        }
    }
}
