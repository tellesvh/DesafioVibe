using System;
using System.Collections.Generic;
using DesafioVibe.ViewModels;
using Xamarin.Forms;

namespace DesafioVibe.Views
{
    public partial class SignupPage : ContentPage
    {
        SignupViewModel signupViewModel;
        public SignupPage()
        {
            signupViewModel = new SignupViewModel();

            InitializeComponent();

            Name.Completed += (object sender, EventArgs e) =>
            {
                CPF.Focus();
            };

            CPF.Completed += (object sender, EventArgs e) =>
            {
                Birthday.Focus();
            };

            Birthday.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                signupViewModel.SignupCommand.Execute(null);
            };

            BindingContext = signupViewModel;
        }
    }
}
