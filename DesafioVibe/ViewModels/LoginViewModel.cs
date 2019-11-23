using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using DesafioVibe.Views;

namespace DesafioVibe.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
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

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }

        private void Login()
        {
            if (string.IsNullOrEmpty(CPF) || string.IsNullOrEmpty(Password))
                Application.Current.MainPage.DisplayAlert("Valores Vazios", "Por favor, verifique se todos os campos estão preenchidos.", "OK");
            else
            {
                // TODO Fazer requisição
                if (CPF == "950" && Password == "12345")
                {
                    // Application.Current.MainPage.DisplayAlert("Login bem sucedido!", "", "OK");
                    Application.Current.MainPage.Navigation.PushAsync(new WelcomePage());
                }
                else
                    Application.Current.MainPage.DisplayAlert("Falha no login.", "Por favor, entre tente novamente.", "OK");
            }
        }
    }
}
