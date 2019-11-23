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
    public class SignupViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        RestService _restService;

        public SignupViewModel()
        {
            _restService = new RestService();
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

        private string birthday;
        public string Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Birthday"));
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

        public Command SignupCommand
        {
            get
            {
                return new Command(Signup);
            }
        }

        private async void Signup()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(CPF) || string.IsNullOrEmpty(Birthday) || string.IsNullOrEmpty(Password))
                await Application.Current.MainPage.DisplayAlert("Há Valores Vazios", "Por favor, verifique se todos os campos estão preenchidos.", "OK");
            else
            {
                MD5Helper md5 = new MD5Helper();
                UserModel user = new UserModel
                {
                    nome = Name,
                    cpf = new string(CPF.Where(char.IsDigit).ToArray()),
                    nascimento = DateTimeOffset.Parse(Birthday).ToString("s"),
                    senha = md5.CreateMD5(Password)
                };
                LoginResponse signupResponse = await _restService.SignUserUp(user);

                if (signupResponse.StatusCode == 200)
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso!", "Cadastro bem-sucedido.", "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Falha no login.", signupResponse.Message, "OK");
                }
            }
        }
    }
}