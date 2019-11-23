using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DesafioVibe.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Password.Text))
            {
                DisplayAlert("Valores Vazios", "Por favor, verifique se todos os campos estão preenchidos.", "OK");
            } else
            {
                // Fazer requisição
                if (Email.Text == "abc@gmail.com" && Password.Text == "1234")
                {
                    DisplayAlert("Login bem sucedido!", "", "OK");
                    Navigation.PushAsync(new WelcomePage());
                }
                else
                    DisplayAlert("Falha no login.", "Por favor, entre tente novamente.", "OK");
            }
        }
    }
}
