using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using DesafioVibe.Views;
using DesafioVibe.Webservice;
using DesafioVibe.Models;
using System.Linq;
using DesafioVibe.Util;
using MonkeyCache.LiteDB;

namespace DesafioVibe.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        RestService _restService;

        public LoginViewModel()
        {
            _restService = new RestService();
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

        private async void Login()
        {
            if (string.IsNullOrEmpty(CPF) || string.IsNullOrEmpty(Password))
                await Application.Current.MainPage.DisplayAlert("Valores Vazios", "Por favor, verifique se todos os campos estão preenchidos.", "OK");
            else
            {
                MD5Helper md5 = new MD5Helper();
                LoginModel login = new LoginModel
                {
                    cpf = new string(CPF.Where(char.IsDigit).ToArray()),
                    senha = md5.CreateMD5(Password)
                };
                LoginResponse loginResponse = await _restService.LogUserIn(login);

                if (loginResponse.StatusCode == 200)
                {
                    Barrel.Current.Add(Constants.USER_KEY, loginResponse.Key, TimeSpan.Zero);
                    Barrel.Current.Add(Constants.USER_CPF, new string(CPF.Where(char.IsDigit).ToArray()), TimeSpan.Zero);
                    await Application.Current.MainPage.Navigation.PushAsync(new WelcomePage());
                } else
                {
                    await Application.Current.MainPage.DisplayAlert("Falha no login.", loginResponse.Message, "OK");
                }
            }
        }
    }
}
