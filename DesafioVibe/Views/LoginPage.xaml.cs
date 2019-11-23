using System;
using System.Collections.Generic;
using DesafioVibe.ViewModels;
using Xamarin.Forms;

namespace DesafioVibe.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel loginViewModel;
        public LoginPage()
        {
            loginViewModel = new LoginViewModel();

            InitializeComponent();

            CPF.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                loginViewModel.LoginCommand.Execute(null);
            };

            BindingContext = loginViewModel;
        }
    }
}
